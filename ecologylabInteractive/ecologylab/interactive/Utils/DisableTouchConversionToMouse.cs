﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace ecologylab.interactive.Utils
{
    /// <summary>
    /// As long as this object exists all mouse events created from a touch event for legacy support will be disabled.
    /// </summary>
    public class DisableTouchConversionToMouse : IDisposable
    {
        static readonly LowLevelMouseProc hookCallback = HookCallback;
        static IntPtr hookId = IntPtr.Zero;

        public DisableTouchConversionToMouse()
        {
            hookId = SetHook(hookCallback);
        }

        static IntPtr SetHook(LowLevelMouseProc proc)
        {
            var moduleHandle = UnsafeNativeMethods.GetModuleHandle(null);

            var setHookResult = UnsafeNativeMethods.SetWindowsHookEx(WH_MOUSE_LL, proc, moduleHandle, 0);
            if (setHookResult == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
            return setHookResult;
        }

        delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var info = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                var extraInfo = (uint)info.dwExtraInfo.ToInt32();
                if ((extraInfo & MOUSEEVENTF_FROMTOUCH) == MOUSEEVENTF_FROMTOUCH)
                {
                    return new IntPtr(1);
                }
            }

            return UnsafeNativeMethods.CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        bool disposed;

        public void Dispose()
        {
            if (disposed) return;

            UnsafeNativeMethods.UnhookWindowsHookEx(hookId);
            disposed = true;
            GC.SuppressFinalize(this);
        }

        ~DisableTouchConversionToMouse()
        {
            Dispose();
        }

        #region Interop

        // ReSharper disable InconsistentNaming
        // ReSharper disable MemberCanBePrivate.Local
        // ReSharper disable FieldCanBeMadeReadOnly.Local

        const uint MOUSEEVENTF_FROMTOUCH = 0xFF515700;
        const int WH_MOUSE_LL = 14;

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {

            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [SuppressUnmanagedCodeSecurity]
        static class UnsafeNativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod,
                uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
                IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);
        }

        // ReSharper restore InconsistentNaming
        // ReSharper restore FieldCanBeMadeReadOnly.Local
        // ReSharper restore MemberCanBePrivate.Local

        #endregion
    }
}

//
//  NamedStyle.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using Simpl.Serialization.Types.Element;


namespace Ecologylab.BigSemantics.MetaMetadataNS.Textformat 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	public class NamedStyle : ElementState, IMappable<String>
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String name;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Boolean underline;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Int32 fontSize;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Int32 alignment;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Int32 faceIndex;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Int32 fontStyle;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Int32 strokeStyle;

		public NamedStyle()
		{ }

		public String Name
		{
			get{return name;}
			set{name = value;}
		}

		public Boolean Underline
		{
			get{return underline;}
			set{underline = value;}
		}

		public Int32 FontSize
		{
			get{return fontSize;}
			set{fontSize = value;}
		}

		public Int32 Alignment
		{
			get{return alignment;}
			set{alignment = value;}
		}

		public Int32 FaceIndex
		{
			get{return faceIndex;}
			set{faceIndex = value;}
		}

		public Int32 FontStyle
		{
			get{return fontStyle;}
			set{fontStyle = value;}
		}

		public Int32 StrokeStyle
		{
			get{return strokeStyle;}
			set{strokeStyle = value;}
		}

		public String Key()
		{
            return name;
		}
	}
}

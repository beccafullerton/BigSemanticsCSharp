//
//  MetadataFieldDescriptor.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using Simpl.Serialization.Attributes;
using Simpl.Serialization;
using System.Reflection;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.metadata 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	public class MetadataFieldDescriptor : FieldDescriptor
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String mmName;

        public MetadataFieldDescriptor(MetadataClassDescriptor classDescriptor, FieldInfo fieldInfo, Int16 annotationType) : base(classDescriptor, fieldInfo, annotationType)
        { 
            MmName = DeriveMmName();
        }

        public MetadataFieldDescriptor(MetadataClassDescriptor declaringClassDescriptor, FieldDescriptor wrappedFD, String wrapperTag)
            : base(declaringClassDescriptor, wrappedFD, wrapperTag)
        {
            //MmName = DeriveMmName();
        }

		public String MmName
		{
			get{return mmName;}
			set{mmName = value;}
		}


	    private String DeriveMmName()
        {
            String result	= null;
		
            FieldInfo thatField = this.Field;
            foreach (CustomAttributeData cad in thatField.GetCustomAttributesData())
            {
                if (cad.Constructor.DeclaringType.Name.Equals("mm_name"))
                {
                    result = (String) cad.ConstructorArguments[0].Value;
                }
            }

            if (result == null)
            {
                result = "";//TODO FIXME XMLTools.GetXmlTagName(thatField.Name, null);
                //if (!this.IsScalar)
                    //System.Console.WriteLine("Missing @mm_name annotation for " + thatField + "\tusing " + result);
            }

            
            return result;
        }
	}
}

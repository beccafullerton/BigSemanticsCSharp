//
//  Run.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 02/09/11.
//  Copyright 2011 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using Simpl.Serialization.Attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;

namespace ecologylab.semantics.generated.library 
{
	/// <summary>
	/// This is a generated code. DO NOT edit or modify it.
	/// @author MetadataCompiler
	/// </summary>
	[SimplInherit]
	[SimplDescriptorClasses(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	public class Run : Metadata
	{
		/// <summary>
		/// 
		/// </summary>
		[SimplComposite]
		[MmName("style_info")]
		private StyleInfo styleInfo;

		public Run()
		{ }

		public StyleInfo StyleInfo
		{
			get{return styleInfo;}
			set{styleInfo = value;}
		}
	}
}

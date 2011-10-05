//
//  TextRun.cs
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
	/// Base class for representing plain text as part of hypertext
	/// This is a generated code. DO NOT edit or modify it.
	/// @author MetadataCompiler
	/// </summary>
	[SimplDescriptorClasses(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[SimplInherit]
	public class TextRun : Run
	{
		/// <summary>
		/// The plain text string
		/// </summary>
		[SimplScalar]
		private MetadataString text;

		public TextRun()
		{ }

		public MetadataString Text
		{
			get{return text;}
			set{text = value;}
		}
	}
}

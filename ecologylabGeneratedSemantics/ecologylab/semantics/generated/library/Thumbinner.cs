//
//  Thumbinner.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 04/01/11.
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
	[SimplDescriptorClasses(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[SimplInherit]
	public class Thumbinner : Metadata
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private MetadataString thumbImgCaption;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private MetadataParsedURL thumbImgSrc;

		public Thumbinner()
		{ }

		public MetadataString ThumbImgCaption
		{
			get{return thumbImgCaption;}
			set{thumbImgCaption = value;}
		}

		public MetadataParsedURL ThumbImgSrc
		{
			get{return thumbImgSrc;}
			set{thumbImgSrc = value;}
		}
	}
}

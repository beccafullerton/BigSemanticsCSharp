//
//  Bookmark.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/04/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;

namespace ecologylab.semantics.generated.library 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class Bookmark : Metadata
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private MetadataString title;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private MetadataParsedURL link;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private MetadataParsedURL pic;

		public Bookmark()
		{ }

		public MetadataString Title
		{
			get{return title;}
			set{title = value;}
		}

		public MetadataParsedURL Link
		{
			get{return link;}
			set{link = value;}
		}

		public MetadataParsedURL Pic
		{
			get{return pic;}
			set{pic = value;}
		}
	}
}

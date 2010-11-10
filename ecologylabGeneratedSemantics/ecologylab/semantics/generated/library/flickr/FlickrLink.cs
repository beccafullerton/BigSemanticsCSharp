//
//  FlickrLink.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/10/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;

namespace ecologylab.semantics.generated.library.flickr 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class FlickrLink : Metadata
	{
		/// <summary>
		/// flickr_image_detail
		/// </summary>
		[simpl_scalar]
		private MetadataParsedURL link;

		/// <summary>
		/// flickr_image_detail
		/// </summary>
		[simpl_scalar]
		private MetadataString title;

		public FlickrLink()
		{ }

		public MetadataParsedURL Link
		{
			get{return link;}
			set{link = value;}
		}

		public MetadataString Title
		{
			get{return title;}
			set{title = value;}
		}
	}
}
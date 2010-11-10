//
//  BingImageSearchResult.cs
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

namespace ecologylab.semantics.generated.library.search 
{
	/// <summary>
	/// Bing image search result.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class BingImageSearchResult : ImageInSearchResult
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[xml_tag("mms:Thumbnail")]
		[simpl_composite]
		[mm_name("thumbnail")]
		private ImageInSearchResult thumbnail;

		public BingImageSearchResult()
		{ }

		public ImageInSearchResult Thumbnail
		{
			get{return thumbnail;}
			set{thumbnail = value;}
		}
	}
}
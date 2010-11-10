//
//  FlickrImageDetail.cs
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
using ecologylab.semantics.metadata.builtins;

namespace ecologylab.semantics.generated.library.flickr 
{
	/// <summary>
	/// A Flickr Image result page
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class FlickrImageDetail : Document
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_composite]
		[mm_name("flickr_image")]
		private FlickrImage flickrImage;

		public FlickrImageDetail()
		{ }

		public FlickrImage FlickrImage
		{
			get{return flickrImage;}
			set{flickrImage = value;}
		}
	}
}
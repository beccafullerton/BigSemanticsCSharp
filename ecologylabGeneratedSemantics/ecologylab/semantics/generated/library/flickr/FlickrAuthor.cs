//
//  FlickrAuthor.cs
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
	/// All flickr photos of a particular user
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class FlickrAuthor : Document
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_collection("flickr_link")]
		[xml_tag("flickr_link_set")]
		[mm_name("flickr_link_set")]
		private List<FlickrLink> flickrLinkSet;

		public FlickrAuthor()
		{ }

		public List<FlickrLink> FlickrLinkSet
		{
			get{return flickrLinkSet;}
			set{flickrLinkSet = value;}
		}
	}
}
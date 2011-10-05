//
//  FlickrAuthor.cs
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
using ecologylab.semantics.metadata.builtins;

namespace ecologylab.semantics.generated.library.flickr 
{
	/// <summary>
	/// All flickr photos of a particular user
	/// This is a generated code. DO NOT edit or modify it.
	/// @author MetadataCompiler
	/// </summary>
	[SimplDescriptorClasses(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[SimplInherit]
	public class FlickrAuthor : Document
	{
		/// <summary>
		/// Collection of all images of a user
		/// </summary>
		[SimplCollection("flickr_link")]
		[SimplTag("flickr_link_set")]
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

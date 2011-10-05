//
//  FlickrSearchTwo.cs
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
	/// The flickr search class
	/// This is a generated code. DO NOT edit or modify it.
	/// @author MetadataCompiler
	/// </summary>
	[SimplDescriptorClasses(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[SimplInherit]
	public class FlickrSearchTwo : Document
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplCollection("flickr_image")]
		[SimplTag("flickr_results")]
		[mm_name("flickr_results")]
		private List<FlickrImage> flickrResults;

		public FlickrSearchTwo()
		{ }

		public List<FlickrImage> FlickrResults
		{
			get{return flickrResults;}
			set{flickrResults = value;}
		}
	}
}

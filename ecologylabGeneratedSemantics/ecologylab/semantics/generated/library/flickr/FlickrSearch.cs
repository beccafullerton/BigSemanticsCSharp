//
// FlickrSearch.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 11/07/11.
// Copyright 2011 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using ecologylab.collections;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.flickr 
{
	/// <summary>
	/// The flickr search class
	/// </summary>
	[SimplInherit]
	public class FlickrSearch : CompoundDocument
	{
		public FlickrSearch()
		{ }

		public FlickrSearch(MetaMetadataCompositeField mmd) : base(mmd) { }

	}
}

//
// Rss22.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 10/21/11.
// Copyright 2011 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using ecologylab.collections;
using ecologylab.semantics.generated.library.rss;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.rss 
{
	/// <summary>
	/// A news feed, yucky style.
	/// </summary>
	[SimplInherit]
	[SimplTag("rss_2_2")]
	public class Rss22 : CompoundDocument
	{
		[SimplCollection("item")]
		[SimplNoWrap]
		[MmName("items")]
		private List<Item> items;

		public Rss22()
		{ }

		public List<Item> Items
		{
			get{return items;}
			set{items = value;}
		}
	}
}

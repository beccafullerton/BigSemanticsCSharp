//
// Item.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2012 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
using Simpl.Fundamental.Net;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using ecologylab.collections;
using ecologylab.semantics.generated.library.rss;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.rss 
{
	/// <summary>
	/// One item in a news feed.
	/// </summary>
	[SimplInherit]
	public class Item : YahooMediaRss
	{
		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlLeaf})]
		private MetadataParsedURL link;

		[SimplCollection("category")]
		[SimplNoWrap]
		[MmName("categories")]
		private List<ecologylab.semantics.metadata.scalar.MetadataString> categories;

		public Item()
		{ }

		public Item(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataParsedURL Link
		{
			get{return link;}
			set
			{
				if (this.link != value)
				{
					this.link = value;
					this.RaisePropertyChanged( () => this.Link );
				}
			}
		}

		public List<ecologylab.semantics.metadata.scalar.MetadataString> Categories
		{
			get{return categories;}
			set
			{
				if (this.categories != value)
				{
					this.categories = value;
					this.RaisePropertyChanged( () => this.Categories );
				}
			}
		}
	}
}

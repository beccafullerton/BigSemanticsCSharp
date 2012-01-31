//
// WikipediaPageType.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2012 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using ecologylab.collections;
using ecologylab.semantics.generated.library.wikipedia;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.wikipedia 
{
	/// <summary>
	/// An article on wikipedia
	/// </summary>
	[SimplInherit]
	public class WikipediaPageType : CompoundDocument
	{
		/// <summary>
		/// Paragraphs in the article.
		/// </summary>
		[SimplCollection("paragraph")]
		[MmName("paragraphs")]
		private List<Paragraph> paragraphs;

		/// <summary>
		/// Wikipedia Categories
		/// </summary>
		[SimplCollection("category")]
		[MmName("categories")]
		private List<Category> categories;

		[SimplCollection("thumbinner")]
		[MmName("thumbinners")]
		private List<Thumbinner> thumbinners;

		public WikipediaPageType()
		{ }

		public WikipediaPageType(MetaMetadataCompositeField mmd) : base(mmd) { }


		public List<Paragraph> Paragraphs
		{
			get{return paragraphs;}
			set
			{
				if (this.paragraphs != value)
				{
					this.paragraphs = value;
					this.RaisePropertyChanged( () => this.Paragraphs );
				}
			}
		}

		public List<Category> Categories
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

		public List<Thumbinner> Thumbinners
		{
			get{return thumbinners;}
			set
			{
				if (this.thumbinners != value)
				{
					this.thumbinners = value;
					this.RaisePropertyChanged( () => this.Thumbinners );
				}
			}
		}
	}
}

//
// WikipediaPageType.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 10/20/11.
// Copyright 2011 Interface Ecology Lab. 
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

		public List<Paragraph> Paragraphs
		{
			get{return paragraphs;}
			set{paragraphs = value;}
		}

		public List<Category> Categories
		{
			get{return categories;}
			set{categories = value;}
		}

		public List<Thumbinner> Thumbinners
		{
			get{return thumbinners;}
			set{thumbinners = value;}
		}

    [SimplCollection("hypertext_para")]
    [SimplTag("hypertext_paras")]
    [MmName("hypertext_paras")]
    private List<HypertextPara> hypertextParas;

    public List<HypertextPara> HypertextParas
    {
      get { return hypertextParas; }
      set { hypertextParas = value; }
    }

    [SimplComposite]
    [MmName("style_info")]
    private HypertextPara introPara;

    public HypertextPara IntroPara
    {
      get { return introPara; }
      set { introPara = value; }
    }
	}
}

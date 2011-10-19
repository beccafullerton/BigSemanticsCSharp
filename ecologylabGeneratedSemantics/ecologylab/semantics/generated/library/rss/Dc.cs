//
// Dc.cs
// s.im.pl serialization
//
// Generated by DotNetTranslator on 10/19/11.
// Copyright 2011 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
using Simpl.Fundamental.Net;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using ecologylab.collections;
using ecologylab.semantics.generated.library;
using ecologylab.semantics.generated.library.artwork;
using ecologylab.semantics.generated.library.bibManaging;
using ecologylab.semantics.generated.library.british_cartoon_archive;
using ecologylab.semantics.generated.library.buzz;
using ecologylab.semantics.generated.library.camera;
using ecologylab.semantics.generated.library.creativeWork;
using ecologylab.semantics.generated.library.dlese;
using ecologylab.semantics.generated.library.fastflip;
using ecologylab.semantics.generated.library.flickr;
using ecologylab.semantics.generated.library.gaurdian_comic;
using ecologylab.semantics.generated.library.globe_cartoon;
using ecologylab.semantics.generated.library.googleBooks;
using ecologylab.semantics.generated.library.gps;
using ecologylab.semantics.generated.library.hotel;
using ecologylab.semantics.generated.library.icdl;
using ecologylab.semantics.generated.library.imdb;
using ecologylab.semantics.generated.library.misc;
using ecologylab.semantics.generated.library.nsdl;
using ecologylab.semantics.generated.library.opml;
using ecologylab.semantics.generated.library.patents;
using ecologylab.semantics.generated.library.political_cartoon;
using ecologylab.semantics.generated.library.products;
using ecologylab.semantics.generated.library.publication;
using ecologylab.semantics.generated.library.rss;
using ecologylab.semantics.generated.library.scholarlyPublication;
using ecologylab.semantics.generated.library.scienceDirect;
using ecologylab.semantics.generated.library.search;
using ecologylab.semantics.generated.library.sfu_cartoon_archive;
using ecologylab.semantics.generated.library.slashdot;
using ecologylab.semantics.generated.library.truman_library_1948_campaign_cartoons;
using ecologylab.semantics.generated.library.urbanspoon;
using ecologylab.semantics.generated.library.uva;
using ecologylab.semantics.generated.library.wikipedia;
using ecologylab.semantics.metadata;

using ecologylab.semantics.metadata.scalar;

namespace ecologylab.semantics.generated.library.rss 
{
	[SimplInherit]
	public class Dc : CompoundDocument
	{
		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlLeaf})]
		[SimplTag("dc:creator")]
		private MetadataString dcCreator;

		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlLeaf})]
		[SimplTag("dc:subject")]
		private MetadataString dcSubject;

		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlLeaf})]
		[SimplTag("dc:description")]
		private MetadataString dcDescription;

		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlLeaf})]
		[SimplTag("dc:title")]
		private MetadataString dcTitle;

		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlLeaf})]
		[SimplTag("dc:date")]
		private MetadataDate dcDate;

		public Dc()
		{ }

		public MetadataString DcCreator
		{
			get{return dcCreator;}
			set{dcCreator = value;}
		}

		public MetadataString DcSubject
		{
			get{return dcSubject;}
			set{dcSubject = value;}
		}

		public MetadataString DcDescription
		{
			get{return dcDescription;}
			set{dcDescription = value;}
		}

		public MetadataString DcTitle
		{
			get{return dcTitle;}
			set{dcTitle = value;}
		}

		public MetadataDate DcDate
		{
			get{return dcDate;}
			set{dcDate = value;}
		}
	}
}

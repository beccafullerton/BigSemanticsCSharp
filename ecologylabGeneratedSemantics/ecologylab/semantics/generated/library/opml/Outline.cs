//
// Outline.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 10/20/11.
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
using ecologylab.semantics.generated.library.opml;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.opml 
{
	[SimplInherit]
	public class Outline : Metadata
	{
		[SimplScalar]
		private MetadataString text;

		[SimplScalar]
		private MetadataString title;

		[SimplScalar]
		[SimplTag("htmlUrl")]
		private MetadataParsedURL htmlUrl;

		[SimplCollection("outline")]
		[SimplNoWrap]
		[MmName("outlines")]
		private List<Outline> outlines;

		[SimplScalar]
		[SimplTag("xmlUrl")]
		private MetadataParsedURL xmlUrl;

		[SimplScalar]
		private MetadataString type;

		public Outline()
		{ }

		public MetadataString Text
		{
			get{return text;}
			set{text = value;}
		}

		public MetadataString Title
		{
			get{return title;}
			set{title = value;}
		}

		public MetadataParsedURL HtmlUrl
		{
			get{return htmlUrl;}
			set{htmlUrl = value;}
		}

		public List<Outline> Outlines
		{
			get{return outlines;}
			set{outlines = value;}
		}

		public MetadataParsedURL XmlUrl
		{
			get{return xmlUrl;}
			set{xmlUrl = value;}
		}

		public MetadataString Type
		{
			get{return type;}
			set{type = value;}
		}
	}
}

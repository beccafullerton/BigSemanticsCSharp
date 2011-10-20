//
// GoogleScholarSearchResult.cs
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
using ecologylab.semantics.generated.library.search;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.search 
{
	/// <summary>
	/// A google scholar search result
	/// </summary>
	[SimplInherit]
	public class GoogleScholarSearchResult : SearchResult
	{
		[SimplScalar]
		private MetadataParsedURL documentLink;

		[SimplScalar]
		private MetadataInteger citations;

		[SimplScalar]
		private MetadataParsedURL citationsLink;

		[SimplScalar]
		private MetadataParsedURL relatedArticlesLink;

		[SimplScalar]
		private MetadataInteger versions;

		[SimplScalar]
		private MetadataParsedURL versionsLink;

		public GoogleScholarSearchResult()
		{ }

		public MetadataParsedURL DocumentLink
		{
			get{return documentLink;}
			set{documentLink = value;}
		}

		public MetadataInteger Citations
		{
			get{return citations;}
			set{citations = value;}
		}

		public MetadataParsedURL CitationsLink
		{
			get{return citationsLink;}
			set{citationsLink = value;}
		}

		public MetadataParsedURL RelatedArticlesLink
		{
			get{return relatedArticlesLink;}
			set{relatedArticlesLink = value;}
		}

		public MetadataInteger Versions
		{
			get{return versions;}
			set{versions = value;}
		}

		public MetadataParsedURL VersionsLink
		{
			get{return versionsLink;}
			set{versionsLink = value;}
		}
	}
}

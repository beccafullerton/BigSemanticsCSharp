//
// CiteseerxSummary.cs
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
using ecologylab.semantics.generated.library.bibManaging;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.bibManaging 
{
	/// <summary>
	/// Summary page from CiteSeerX.
	/// </summary>
	[SimplInherit]
	public class CiteseerxSummary : CiteseerxRecord
	{
		[SimplScalar]
		private MetadataParsedURL citationPage;

		/// <summary>
		/// Papers that cite the same works.
		/// </summary>
		[SimplScalar]
		private MetadataParsedURL activeBibliographyPage;

		/// <summary>
		/// Papers that are cited by the same works.
		/// </summary>
		[SimplScalar]
		private MetadataParsedURL cocitationPage;

		public CiteseerxSummary()
		{ }

		public MetadataParsedURL CitationPage
		{
			get{return citationPage;}
			set{citationPage = value;}
		}

		public MetadataParsedURL ActiveBibliographyPage
		{
			get{return activeBibliographyPage;}
			set{activeBibliographyPage = value;}
		}

		public MetadataParsedURL CocitationPage
		{
			get{return cocitationPage;}
			set{cocitationPage = value;}
		}
	}
}

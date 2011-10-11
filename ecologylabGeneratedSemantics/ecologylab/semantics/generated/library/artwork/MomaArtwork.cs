//
// MomaArtwork.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 10/11/11.
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
using ecologylab.semantics.generated.library.artwork;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.artwork 
{
	[SimplInherit]
	public class MomaArtwork : Artwork
	{
		[SimplScalar]
		private MetadataString status;

		[SimplComposite]
		[MmName("moma_deparment")]
		private CompoundDocument momaDeparment;

		[SimplComposite]
		[MmName("moma_classification")]
		private CompoundDocument momaClassification;

		[SimplScalar]
		private MetadataParsedURL permalink;

		[SimplScalar]
		private MetadataParsedURL databaseLink;

		[SimplScalar]
		private MetadataString momaId;

		[SimplScalar]
		private MetadataParsedURL imageUrl;

		[SimplComposite]
		[MmName("temp_field_value_holder")]
		private TempFieldValueHolder tempFieldValueHolder;

		public MomaArtwork()
		{ }

		public MetadataString Status
		{
			get{return status;}
			set{status = value;}
		}

		public CompoundDocument MomaDeparment
		{
			get{return momaDeparment;}
			set{momaDeparment = value;}
		}

		public CompoundDocument MomaClassification
		{
			get{return momaClassification;}
			set{momaClassification = value;}
		}

		public MetadataParsedURL Permalink
		{
			get{return permalink;}
			set{permalink = value;}
		}

		public MetadataParsedURL DatabaseLink
		{
			get{return databaseLink;}
			set{databaseLink = value;}
		}

		public MetadataString MomaId
		{
			get{return momaId;}
			set{momaId = value;}
		}

		public MetadataParsedURL ImageUrl
		{
			get{return imageUrl;}
			set{imageUrl = value;}
		}

		public TempFieldValueHolder TempFieldValueHolder
		{
			get{return tempFieldValueHolder;}
			set{tempFieldValueHolder = value;}
		}
	}
}

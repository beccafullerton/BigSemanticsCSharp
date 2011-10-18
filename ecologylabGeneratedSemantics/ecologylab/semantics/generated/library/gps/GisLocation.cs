//
// GisLocation.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 10/11/11.
// Copyright 2011 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using ecologylab.collections;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.gps 
{
	[SimplInherit]
	public class GisLocation : Metadata
	{
		[SimplScalar]
		private MetadataDouble latitude;

		[SimplScalar]
		private MetadataDouble longitude;

		[SimplScalar]
		private MetadataDouble altitude;

		[SimplScalar]
		private MetadataString satellites;

		public GisLocation()
		{ }

		public MetadataDouble Latitude
		{
			get{return latitude;}
			set{latitude = value;}
		}

		public MetadataDouble Longitude
		{
			get{return longitude;}
			set{longitude = value;}
		}

		public MetadataDouble Altitude
		{
			get{return altitude;}
			set{altitude = value;}
		}

		public MetadataString Satellites
		{
			get{return satellites;}
			set{satellites = value;}
		}
	}
}
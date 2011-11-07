//
// Artwork.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 11/07/11.
// Copyright 2011 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
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
	/// <summary>
	/// Artwork class
	/// </summary>
	[SimplInherit]
	public class Artwork : CompoundDocument
	{
		/// <summary>
		/// Set of artists.
		/// </summary>
		[SimplCollection("artist")]
		[MmName("artists")]
		private List<Artist> artists;

		/// <summary>
		/// Medium on which the work is done.
		/// </summary>
		[SimplScalar]
		private MetadataString medium;

		/// <summary>
		/// Abstract of the work.
		/// </summary>
		[SimplScalar]
		[SimplTag("abstract")]
		private MetadataString abstractField;

		/// <summary>
		/// Year the work was created.
		/// </summary>
		[SimplScalar]
		private MetadataString year;

		[SimplScalar]
		private MetadataString dimensions;

		public Artwork()
		{ }

		public Artwork(MetaMetadataCompositeField mmd) : base(mmd) { }


		public List<Artist> Artists
		{
			get{return artists;}
			set{artists = value;}
		}

		public MetadataString Medium
		{
			get{return medium;}
			set{medium = value;}
		}

		public MetadataString AbstractField
		{
			get{return abstractField;}
			set{abstractField = value;}
		}

		public MetadataString Year
		{
			get{return year;}
			set{year = value;}
		}

		public MetadataString Dimensions
		{
			get{return dimensions;}
			set{dimensions = value;}
		}
	}
}

//
//  Artwork.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 04/01/11.
//  Copyright 2011 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;

namespace ecologylab.semantics.generated.library.artwork 
{
	/// <summary>
	/// Artwork class
	/// This is a generated code. DO NOT edit or modify it.
	/// @author MetadataCompiler
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class Artwork : Document
	{
		/// <summary>
		/// Set of artists.
		/// </summary>
		[simpl_collection("artist")]
		[xml_tag("artists")]
		[mm_name("artists")]
		private List<Artist> artists;

		/// <summary>
		/// Abstract of the work.
		/// </summary>
		[simpl_scalar]
		[xml_tag("abstract")]
		private MetadataString abstractField;

		/// <summary>
		/// Medium on which the work is done.
		/// </summary>
		[simpl_scalar]
		private MetadataString medium;

		/// <summary>
		/// Year the work was created.
		/// </summary>
		[simpl_scalar]
		private MetadataString year;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private MetadataString dimensions;

		public Artwork()
		{ }

		public List<Artist> Artists
		{
			get{return artists;}
			set{artists = value;}
		}

		public MetadataString AbstractField
		{
			get{return abstractField;}
			set{abstractField = value;}
		}

		public MetadataString Medium
		{
			get{return medium;}
			set{medium = value;}
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

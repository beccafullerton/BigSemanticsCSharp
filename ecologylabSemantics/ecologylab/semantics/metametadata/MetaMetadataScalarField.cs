//
//  MetaMetadataScalarField.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.serialization.types;

namespace ecologylab.semantics.metametadata 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_inherit]
	[xml_tag("scalar")]
	public class MetaMetadataScalarField : MetaMetadataField
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private ScalarType scalarType;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_composite]
		private RegexFilter filter;

		public MetaMetadataScalarField()
		{ }

		public ScalarType ScalarTypeP
		{
			get{return scalarType;}
			set{scalarType = value;}
		}

		public RegexFilter Filter
		{
			get{return filter;}
			set{filter = value;}
		}
	}
}

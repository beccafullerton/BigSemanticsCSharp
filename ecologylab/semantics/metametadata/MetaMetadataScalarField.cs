//
//  MetaMetadataScalarField.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using Simpl.Serialization.Attributes;
using Simpl.Serialization.Attributes;
using Simpl.Serialization.Types;
using ecologylab.semantics.metadata.scalar.types;


namespace ecologylab.semantics.metametadata 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[SimplInherit]
	[SimplTag("scalar")]
    [SimplDescriptorClasses(new[] { typeof(MetaMetadataClassDescriptor), typeof(MetaMetadataFieldDescriptor) })]
	public class MetaMetadataScalarField : MetaMetadataField
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>

        [SimplScalar]
		private MetadataScalarType scalarType;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplComposite]
		private RegexFilter filter;

        [SimplScalar]
	    private Hint hint;

		public MetaMetadataScalarField()
		{ }

        public MetadataScalarType ScalarTypeP
		{
			get{return scalarType;}
			set{scalarType = value;}
		}

		public RegexFilter Filter
		{
			get{return filter;}
			set{filter = value;}
		}

	    public override string GetTypeName()
	    {
            throw new MetaMetadataException("no mmd name for scalar fields!");
	    }
	}
}
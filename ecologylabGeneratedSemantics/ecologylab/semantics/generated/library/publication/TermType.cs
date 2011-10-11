//
// TermType.cs
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
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.publication 
{
	[SimplInherit]
	public class TermType : Document
	{
		[SimplScalar]
		[SimplCompositeAsScalar]
		private MetadataString term;

		[SimplScalar]
		private MetadataInteger frequency;

		public TermType()
		{ }

		public MetadataString Term
		{
			get{return term;}
			set{term = value;}
		}

		public MetadataInteger Frequency
		{
			get{return frequency;}
			set{frequency = value;}
		}
	}
}

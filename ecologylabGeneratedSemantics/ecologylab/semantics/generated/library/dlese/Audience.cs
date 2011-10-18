//
// Audience.cs
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

namespace ecologylab.semantics.generated.library.dlese 
{
	[SimplInherit]
	public class Audience : Metadata
	{
		[SimplScalar]
		[SimplTag("gradeRange")]
		private MetadataString gradeRange;

		public Audience()
		{ }

		public MetadataString GradeRange
		{
			get{return gradeRange;}
			set{gradeRange = value;}
		}
	}
}
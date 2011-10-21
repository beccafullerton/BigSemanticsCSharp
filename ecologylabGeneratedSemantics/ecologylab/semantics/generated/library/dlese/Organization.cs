//
// Organization.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 10/21/11.
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
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.dlese 
{
	[SimplInherit]
	public class Organization : Metadata
	{
		[SimplScalar]
		[SimplTag("instEmail")]
		private MetadataString email;

		[SimplScalar]
		[SimplTag("instName")]
		private MetadataString name;

		public Organization()
		{ }

		public MetadataString Email
		{
			get{return email;}
			set{email = value;}
		}

		public MetadataString Name
		{
			get{return name;}
			set{name = value;}
		}
	}
}

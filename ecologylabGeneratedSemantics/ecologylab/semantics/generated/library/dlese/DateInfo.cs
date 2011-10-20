//
// DateInfo.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 10/20/11.
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
	public class DateInfo : Metadata
	{
		[SimplScalar]
		private MetadataDate created;

		[SimplScalar]
		private MetadataDate accessioned;

		public DateInfo()
		{ }

		public MetadataDate Created
		{
			get{return created;}
			set{created = value;}
		}

		public MetadataDate Accessioned
		{
			get{return accessioned;}
			set{accessioned = value;}
		}
	}
}

//
// Subject.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 11/07/11.
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
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.publication 
{
	[SimplInherit]
	public class Subject : Metadata
	{
		[SimplScalar]
		private MetadataParsedURL location;

		[SimplScalar]
		[SimplCompositeAsScalar]
		private MetadataString subject;

		public Subject()
		{ }

		public Subject(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataParsedURL Location
		{
			get{return location;}
			set{location = value;}
		}

		public MetadataString SubjectProp
		{
			get{return subject;}
			set{subject = value;}
		}
	}
}

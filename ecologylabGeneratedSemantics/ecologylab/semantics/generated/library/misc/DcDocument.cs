//
// DcDocument.cs
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
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.misc 
{
	[SimplInherit]
	public class DcDocument : CompoundDocument
	{
		[SimplScalar]
		private MetadataString subject;

		public DcDocument()
		{ }

		public MetadataString Subject
		{
			get{return subject;}
			set{subject = value;}
		}
	}
}

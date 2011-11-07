//
// Head.cs
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
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.opml 
{
	[SimplInherit]
	public class Head : Metadata
	{
		[SimplScalar]
		private MetadataString title;

		public Head()
		{ }

		public Head(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataString Title
		{
			get{return title;}
			set{title = value;}
		}
	}
}

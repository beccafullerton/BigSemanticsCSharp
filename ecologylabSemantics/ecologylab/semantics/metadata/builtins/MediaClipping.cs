//
// MediaClipping.cs
// s.im.pl serialization
//
// Generated by DotNetTranslator on 10/19/11.
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

namespace ecologylab.semantics.metadata.builtins 
{
	[SimplInherit]
    [SimplDescriptorClasses(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	public class MediaClipping : Clipping
	{

		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlAttribute})]
		private MetadataString caption;

		[SimplComposite]
		[SimplWrap]
		[SimplScope("repository_media")]
		private ClippableDocument media;

		public MediaClipping()
		{ }

		public MetadataString Caption
		{
			get{return caption;}
			set{caption = value;}
		}

		public ClippableDocument Media
		{
			get{return media;}
			set{media = value;}
		}
	}
}

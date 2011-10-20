//
// Rss.cs
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
using ecologylab.semantics.generated.library.rss;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.rss 
{
	/// <summary>
	/// A news feed.
	/// </summary>
	[SimplInherit]
	public class Rss : Document
	{
		[SimplComposite]
		[MmName("channel")]
		private Channel channel;

		public Rss()
		{ }

		public Channel Channel
		{
			get{return channel;}
			set{channel = value;}
		}
	}
}

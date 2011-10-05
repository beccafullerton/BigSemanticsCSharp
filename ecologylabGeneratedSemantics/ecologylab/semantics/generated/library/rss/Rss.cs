//
//  Rss.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 04/01/11.
//  Copyright 2011 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using Simpl.Serialization.Attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;

namespace ecologylab.semantics.generated.library.rss 
{
	/// <summary>
	/// A news feed.
	/// This is a generated code. DO NOT edit or modify it.
	/// @author MetadataCompiler
	/// </summary>
	[SimplDescriptorClasses(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[SimplInherit]
	public class Rss : Document
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplComposite]
		[mm_name("channel")]
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

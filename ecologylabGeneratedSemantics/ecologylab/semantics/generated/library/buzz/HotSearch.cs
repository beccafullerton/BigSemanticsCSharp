//
//  HotSearch.cs
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

namespace ecologylab.semantics.generated.library.buzz 
{
	/// <summary>
	/// This is a generated code. DO NOT edit or modify it.
	/// @author MetadataCompiler
	/// </summary>
	[SimplDescriptorClasses(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[SimplInherit]
	public class HotSearch : Metadata
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private MetadataString search;

		public HotSearch()
		{ }

		public MetadataString Search
		{
			get{return search;}
			set{search = value;}
		}
	}
}

//
//  Model.cs
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

namespace ecologylab.semantics.generated.library.uva 
{
	/// <summary>
	/// This is a generated code. DO NOT edit or modify it.
	/// @author MetadataCompiler
	/// </summary>
	[SimplDescriptorClasses(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[SimplInherit]
	public class Model : Metadata
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplCollection("topic_cluster")]
		[SimplTag("topic_clusters")]
		[mm_name("topic_clusters")]
		private List<TopicCluster> topicClusters;

		public Model()
		{ }

		public List<TopicCluster> TopicClusters
		{
			get{return topicClusters;}
			set{topicClusters = value;}
		}
	}
}

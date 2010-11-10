//
//  Model.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/04/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;

namespace ecologylab.semantics.generated.library.uva 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class Model : Metadata
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_collection("topic_cluster")]
		[xml_tag("topic_clusters")]
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

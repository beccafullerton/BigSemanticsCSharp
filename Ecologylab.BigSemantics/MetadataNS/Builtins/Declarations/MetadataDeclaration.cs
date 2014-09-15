//
// MetadataDeclaration.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2014 Interface Ecology Lab. 
//


using Ecologylab.BigSemantics.MetaMetadataNS;
using Ecologylab.BigSemantics.MetadataNS;
using Ecologylab.BigSemantics.MetadataNS.Builtins;
using Ecologylab.BigSemantics.MetadataNS.Scalar;
using Ecologylab.Collections;
using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecologylab.BigSemantics.MetadataNS.Builtins.Declarations 
{
	/// <summary>
	/// The Metadata Class
	/// </summary>
	[SimplDescriptorClasses(new Type[] {typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor)})]
	[SimplInherit]
	public class MetadataDeclaration
	{
		/// <summary>
		/// Stores the name of the meta-metadata, and is used on restoring from XML.
		/// </summary>
		[SimplScalar]
		private MetadataString metaMetadataName;

		[SimplCollection]
		[SimplScope("repository_metadata")]
		[MmName("mixins")]
		[SemanticsMixin]
		private List<Metadata> mixins;

		[SimplCollection]
		[SimplScope("repository_metadata")]
		[MmName("linked_metadata_list")]
		private List<Metadata> linkedMetadataList;

		public MetadataDeclaration()
		{ }

		public MetadataString MetaMetadataName
		{
			get{return metaMetadataName;}
			set
			{
				if (this.metaMetadataName != value)
				{
					this.metaMetadataName = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}

		public List<Metadata> Mixins
		{
			get{return mixins;}
			set
			{
				if (this.mixins != value)
				{
					this.mixins = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}

		public List<Metadata> LinkedMetadataList
		{
			get{return linkedMetadataList;}
			set
			{
				if (this.linkedMetadataList != value)
				{
					this.linkedMetadataList = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}
	}
}
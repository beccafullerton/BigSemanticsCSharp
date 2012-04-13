//
// InformationCompositionDeclaration.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2012 Interface Ecology Lab. 
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

namespace ecologylab.semantics.metadata.builtins.declarations 
{
	[SimplInherit]
	public class InformationCompositionDeclaration : Document
	{
		[SimplCollection]
		[SimplScope("repository_no_annotations")]
		[MmName("metadata")]
		private List<Metadata> metadata;

		/// <summary>
		/// User annotations.
		/// </summary>
		[SimplCollection("annotation")]
		[MmName("annotations")]
		private List<Annotation> annotations;

		/// <summary>
		/// for compatability w old compositions -- do not use!
		/// </summary>
		[SimplCollection]
		[SimplScope("repository_clippings")]
		[MmName("clippings")]
		private List<Clipping> clippings;

		/// <summary>
		/// for compatability w old compositions -- do not use!
		/// </summary>
		[SimplCollection]
		[SimplScope("repository_media")]
		[MmName("media")]
		private List<Metadata> media;

		[SimplScalar]
		private MetadataFloat version;

		[SimplScalar]
		private MetadataFloat metadataVersion;

		public InformationCompositionDeclaration()
		{ }

		public InformationCompositionDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public List<Metadata> Metadata
		{
			get{return metadata;}
			set
			{
				if (this.metadata != value)
				{
					this.metadata = value;
					this.RaisePropertyChanged( () => this.Metadata );
				}
			}
		}

		public List<Annotation> Annotations
		{
			get{return annotations;}
			set
			{
				if (this.annotations != value)
				{
					this.annotations = value;
					this.RaisePropertyChanged( () => this.Annotations );
				}
			}
		}

		public List<Clipping> Clippings
		{
			get{return clippings;}
			set
			{
				if (this.clippings != value)
				{
					this.clippings = value;
					this.RaisePropertyChanged( () => this.Clippings );
				}
			}
		}

		public List<Metadata> Media
		{
			get{return media;}
			set
			{
				if (this.media != value)
				{
					this.media = value;
					this.RaisePropertyChanged( () => this.Media );
				}
			}
		}

		public MetadataFloat Version
		{
			get{return version;}
			set
			{
				if (this.version != value)
				{
					this.version = value;
					this.RaisePropertyChanged( () => this.Version );
				}
			}
		}

		public MetadataFloat MetadataVersion
		{
			get{return metadataVersion;}
			set
			{
				if (this.metadataVersion != value)
				{
					this.metadataVersion = value;
					this.RaisePropertyChanged( () => this.MetadataVersion );
				}
			}
		}
	}
}

//
// MediaClippingDeclaration.cs
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
	public class MediaClippingDeclaration<ME> : Clipping where ME : ClippableDocument<ME>
	{
		/// <summary>
		/// The caption of the image.
		/// </summary>
		[SimplScalar]
		private MetadataString caption;

		[SimplComposite]
		[SimplWrap]
		[SimplScope("repository_media")]
		[MmName("media")]
		private ME media;

		public MediaClippingDeclaration()
		{ }

		public MediaClippingDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataString Caption
		{
			get{return caption;}
			set
			{
				if (this.caption != value)
				{
					this.caption = value;
					this.RaisePropertyChanged( () => this.Caption );
				}
			}
		}

		public ME Media
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
	}
}

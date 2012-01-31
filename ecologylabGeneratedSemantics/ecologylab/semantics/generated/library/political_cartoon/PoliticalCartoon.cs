//
// PoliticalCartoon.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2012 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
using Simpl.Fundamental.Net;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using ecologylab.collections;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.political_cartoon 
{
	/// <summary>
	/// This MMD was initially generated by the browser authoring tool
	/// </summary>
	[SimplInherit]
	public class PoliticalCartoon : Document
	{
		/// <summary>
		/// MyComment
		/// </summary>
		[SimplScalar]
		private MetadataString cartoonist;

		/// <summary>
		/// Link to the jpg of the cartoon
		/// </summary>
		[SimplScalar]
		private MetadataParsedURL cartoonImg;

		public PoliticalCartoon()
		{ }

		public PoliticalCartoon(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataString Cartoonist
		{
			get{return cartoonist;}
			set
			{
				if (this.cartoonist != value)
				{
					this.cartoonist = value;
					this.RaisePropertyChanged( () => this.Cartoonist );
				}
			}
		}

		public MetadataParsedURL CartoonImg
		{
			get{return cartoonImg;}
			set
			{
				if (this.cartoonImg != value)
				{
					this.cartoonImg = value;
					this.RaisePropertyChanged( () => this.CartoonImg );
				}
			}
		}
	}
}

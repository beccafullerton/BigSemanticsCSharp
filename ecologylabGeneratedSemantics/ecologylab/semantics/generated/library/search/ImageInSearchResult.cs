//
// ImageInSearchResult.cs
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

namespace ecologylab.semantics.generated.library.search 
{
	/// <summary>
	/// Def of an image in a Bing image search result.
	/// </summary>
	[SimplInherit]
	public class ImageInSearchResult : Image
	{
		[SimplScalar]
		[SimplTag("mms:ContentType")]
		private MetadataString contentType;

		[SimplScalar]
		private MetadataParsedURL referrerUrl;

		[SimplScalar]
		[SimplTag("mms:FileSize")]
		private MetadataInteger fileSize;

		public ImageInSearchResult()
		{ }

		public ImageInSearchResult(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataString ContentType
		{
			get{return contentType;}
			set
			{
				if (this.contentType != value)
				{
					this.contentType = value;
					this.RaisePropertyChanged( () => this.ContentType );
				}
			}
		}

		public MetadataParsedURL ReferrerUrl
		{
			get{return referrerUrl;}
			set
			{
				if (this.referrerUrl != value)
				{
					this.referrerUrl = value;
					this.RaisePropertyChanged( () => this.ReferrerUrl );
				}
			}
		}

		public MetadataInteger FileSize
		{
			get{return fileSize;}
			set
			{
				if (this.fileSize != value)
				{
					this.fileSize = value;
					this.RaisePropertyChanged( () => this.FileSize );
				}
			}
		}
	}
}

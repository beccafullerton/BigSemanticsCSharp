//
// AuthorPhotos.cs
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
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.flickr 
{
	[SimplInherit]
	public class AuthorPhotos : Metadata
	{
		[SimplScalar]
		private MetadataParsedURL authorPhotostreamLink;

		[SimplScalar]
		private MetadataString authorPhotostream;

		[SimplScalar]
		private MetadataParsedURL photosThatDayLink;

		[SimplScalar]
		private MetadataParsedURL photosThatMonthLink;

		[SimplScalar]
		private MetadataParsedURL photosThatYearLink;

		[SimplScalar]
		private MetadataString photosThatDay;

		[SimplScalar]
		private MetadataString photosThatMonth;

		[SimplScalar]
		private MetadataString photosThatYear;

		public AuthorPhotos()
		{ }

		public AuthorPhotos(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataParsedURL AuthorPhotostreamLink
		{
			get{return authorPhotostreamLink;}
			set
			{
				if (this.authorPhotostreamLink != value)
				{
					this.authorPhotostreamLink = value;
					this.RaisePropertyChanged( () => this.AuthorPhotostreamLink );
				}
			}
		}

		public MetadataString AuthorPhotostream
		{
			get{return authorPhotostream;}
			set
			{
				if (this.authorPhotostream != value)
				{
					this.authorPhotostream = value;
					this.RaisePropertyChanged( () => this.AuthorPhotostream );
				}
			}
		}

		public MetadataParsedURL PhotosThatDayLink
		{
			get{return photosThatDayLink;}
			set
			{
				if (this.photosThatDayLink != value)
				{
					this.photosThatDayLink = value;
					this.RaisePropertyChanged( () => this.PhotosThatDayLink );
				}
			}
		}

		public MetadataParsedURL PhotosThatMonthLink
		{
			get{return photosThatMonthLink;}
			set
			{
				if (this.photosThatMonthLink != value)
				{
					this.photosThatMonthLink = value;
					this.RaisePropertyChanged( () => this.PhotosThatMonthLink );
				}
			}
		}

		public MetadataParsedURL PhotosThatYearLink
		{
			get{return photosThatYearLink;}
			set
			{
				if (this.photosThatYearLink != value)
				{
					this.photosThatYearLink = value;
					this.RaisePropertyChanged( () => this.PhotosThatYearLink );
				}
			}
		}

		public MetadataString PhotosThatDay
		{
			get{return photosThatDay;}
			set
			{
				if (this.photosThatDay != value)
				{
					this.photosThatDay = value;
					this.RaisePropertyChanged( () => this.PhotosThatDay );
				}
			}
		}

		public MetadataString PhotosThatMonth
		{
			get{return photosThatMonth;}
			set
			{
				if (this.photosThatMonth != value)
				{
					this.photosThatMonth = value;
					this.RaisePropertyChanged( () => this.PhotosThatMonth );
				}
			}
		}

		public MetadataString PhotosThatYear
		{
			get{return photosThatYear;}
			set
			{
				if (this.photosThatYear != value)
				{
					this.photosThatYear = value;
					this.RaisePropertyChanged( () => this.PhotosThatYear );
				}
			}
		}
	}
}

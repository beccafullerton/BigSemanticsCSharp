//
// CameraSettings.cs
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

namespace ecologylab.semantics.generated.library.camera 
{
	/// <summary>
	/// Mixin: Image description from EXIF image metadata.
	/// </summary>
	[SimplInherit]
	public class CameraSettings : Metadata
	{
		[SimplScalar]
		private MetadataString subjectDistance;

		[SimplScalar]
		private MetadataString exposureTime;

		[SimplScalar]
		private MetadataFloat aperture;

		[SimplScalar]
		private MetadataFloat shutterSpeed;

		[SimplScalar]
		private MetadataString model;

		[SimplScalar]
		private MetadataString orientation;

		[SimplScalar]
		private MetadataInteger resolution;

		public CameraSettings()
		{ }

		public CameraSettings(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataString SubjectDistance
		{
			get{return subjectDistance;}
			set
			{
				if (this.subjectDistance != value)
				{
					this.subjectDistance = value;
					this.RaisePropertyChanged( () => this.SubjectDistance );
				}
			}
		}

		public MetadataString ExposureTime
		{
			get{return exposureTime;}
			set
			{
				if (this.exposureTime != value)
				{
					this.exposureTime = value;
					this.RaisePropertyChanged( () => this.ExposureTime );
				}
			}
		}

		public MetadataFloat Aperture
		{
			get{return aperture;}
			set
			{
				if (this.aperture != value)
				{
					this.aperture = value;
					this.RaisePropertyChanged( () => this.Aperture );
				}
			}
		}

		public MetadataFloat ShutterSpeed
		{
			get{return shutterSpeed;}
			set
			{
				if (this.shutterSpeed != value)
				{
					this.shutterSpeed = value;
					this.RaisePropertyChanged( () => this.ShutterSpeed );
				}
			}
		}

		public MetadataString Model
		{
			get{return model;}
			set
			{
				if (this.model != value)
				{
					this.model = value;
					this.RaisePropertyChanged( () => this.Model );
				}
			}
		}

		public MetadataString Orientation
		{
			get{return orientation;}
			set
			{
				if (this.orientation != value)
				{
					this.orientation = value;
					this.RaisePropertyChanged( () => this.Orientation );
				}
			}
		}

		public MetadataInteger Resolution
		{
			get{return resolution;}
			set
			{
				if (this.resolution != value)
				{
					this.resolution = value;
					this.RaisePropertyChanged( () => this.Resolution );
				}
			}
		}
	}
}

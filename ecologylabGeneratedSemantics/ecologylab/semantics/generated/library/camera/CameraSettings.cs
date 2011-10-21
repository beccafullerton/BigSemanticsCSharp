//
// CameraSettings.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 10/21/11.
// Copyright 2011 Interface Ecology Lab. 
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

		public MetadataString SubjectDistance
		{
			get{return subjectDistance;}
			set{subjectDistance = value;}
		}

		public MetadataString ExposureTime
		{
			get{return exposureTime;}
			set{exposureTime = value;}
		}

		public MetadataFloat Aperture
		{
			get{return aperture;}
			set{aperture = value;}
		}

		public MetadataFloat ShutterSpeed
		{
			get{return shutterSpeed;}
			set{shutterSpeed = value;}
		}

		public MetadataString Model
		{
			get{return model;}
			set{model = value;}
		}

		public MetadataString Orientation
		{
			get{return orientation;}
			set{orientation = value;}
		}

		public MetadataInteger Resolution
		{
			get{return resolution;}
			set{resolution = value;}
		}
	}
}

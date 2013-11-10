//
// WebVideo.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2013 Interface Ecology Lab. 
//


using Ecologylab.Collections;
using Ecologylab.Semantics.Generated.Library.PrimitivesNS;
using Ecologylab.Semantics.MetaMetadataNS;
using Ecologylab.Semantics.MetadataNS;
using Ecologylab.Semantics.MetadataNS.Builtins;
using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecologylab.Semantics.MetadataNS.Builtins 
{
	[SimplInherit]
	public class WebVideo : Video
	{
		[SimplComposite]
		[MmName("provider")]
		private MediaProvider provider;

		public WebVideo()
		{ }

		public WebVideo(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MediaProvider Provider
		{
			get{return provider;}
			set
			{
				if (this.provider != value)
				{
					this.provider = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}
	}
}

//
// ImageClippingDeclaration.cs
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
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.metadata.builtins.declarations 
{
	[SimplInherit]
	public class ImageClippingDeclaration : MediaClipping<Image>
	{
		public ImageClippingDeclaration()
		{ }

		public ImageClippingDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }

	}
}

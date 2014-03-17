//
// AssignPrimaryLinkDeclaration.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2014 Interface Ecology Lab. 
//


using Ecologylab.Collections;
using Ecologylab.Semantics.MetaMetadataNS;
using Ecologylab.Semantics.MetadataNS.Builtins;
using Ecologylab.Semantics.MetadataNS.Scalar;
using Simpl.Fundamental.Generic;
using Simpl.Fundamental.Net;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecologylab.Semantics.MetadataNS.Builtins.Declarations 
{
	[SimplInherit]
	public class AssignPrimaryLinkDeclaration : CreativeAct
	{
		[SimplScalar]
		private MetadataParsedURL location;

		public AssignPrimaryLinkDeclaration()
		{ }

		public AssignPrimaryLinkDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataParsedURL Location
		{
			get{return location;}
			set
			{
				if (this.location != value)
				{
					this.location = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}
	}
}

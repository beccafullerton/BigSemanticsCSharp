//
// AssignPrimaryLinkDeclaration.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2015 Interface Ecology Lab. 
//


using Ecologylab.BigSemantics.MetaMetadataNS;
using Ecologylab.BigSemantics.MetadataNS.Builtins;
using Ecologylab.BigSemantics.MetadataNS.Scalar;
using Ecologylab.Collections;
using Simpl.Fundamental.Generic;
using Simpl.Fundamental.Net;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecologylab.BigSemantics.MetadataNS.Builtins.Declarations 
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

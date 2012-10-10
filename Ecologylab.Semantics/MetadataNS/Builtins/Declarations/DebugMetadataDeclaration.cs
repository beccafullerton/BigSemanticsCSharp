//
// DebugMetadataDeclaration.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2012 Interface Ecology Lab. 
//


using Ecologylab.Collections;
using Ecologylab.Semantics.MetaMetadataNS;
using Ecologylab.Semantics.MetadataNS;
using Ecologylab.Semantics.MetadataNS.Builtins;
using Ecologylab.Semantics.MetadataNS.Scalar;
using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ecologylab.Semantics.MetadataNS.Builtins.Declarations 
{
	[SimplInherit]
	public class DebugMetadataDeclaration : Metadata
	{
		[SimplScalar]
		private MetadataStringBuilder newTermVector;

		public DebugMetadataDeclaration()
		{ }

		public DebugMetadataDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataStringBuilder NewTermVector
		{
			get{return newTermVector;}
			set
			{
				if (this.newTermVector != value)
				{
					this.newTermVector = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}
	}
}
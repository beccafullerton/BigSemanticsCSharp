//
// CurateLinkDeclaration.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2015 Interface Ecology Lab. 
//


using Ecologylab.BigSemantics.MetaMetadataNS;
using Ecologylab.BigSemantics.MetadataNS;
using Ecologylab.BigSemantics.MetadataNS.Builtins;
using Ecologylab.Collections;
using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecologylab.BigSemantics.MetadataNS.Builtins.Declarations 
{
	[SimplInherit]
	public class CurateLinkDeclaration : CreativeAct
	{
		[SimplComposite]
		[SimplWrap]
		[SimplScope("repository_documents")]
		[MmName("document")]
		private Document document;

		public CurateLinkDeclaration()
		{ }

		public CurateLinkDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public Document Document
		{
			get{return document;}
			set
			{
				if (this.document != value)
				{
					this.document = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}
	}
}

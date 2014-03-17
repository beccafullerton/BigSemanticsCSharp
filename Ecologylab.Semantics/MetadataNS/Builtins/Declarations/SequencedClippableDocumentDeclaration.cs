//
// SequencedClippableDocumentDeclaration.cs
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
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecologylab.Semantics.MetadataNS.Builtins.Declarations 
{
	[SimplInherit]
	public class SequencedClippableDocumentDeclaration : ClippableDocument
	{
		/// <summary>
		/// duration of media in milliseconds.
		/// </summary>
		[SimplScalar]
		private MetadataInteger duration;

		[SimplScalar]
		private MetadataString fileFormat;

		public SequencedClippableDocumentDeclaration()
		{ }

		public SequencedClippableDocumentDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataInteger Duration
		{
			get{return duration;}
			set
			{
				if (this.duration != value)
				{
					this.duration = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}

		public MetadataString FileFormat
		{
			get{return fileFormat;}
			set
			{
				if (this.fileFormat != value)
				{
					this.fileFormat = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}
	}
}

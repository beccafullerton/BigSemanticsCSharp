//
// TextClippingDeclaration.cs
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
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.metadata.builtins.declarations 
{
	[SimplInherit]
	public class TextClippingDeclaration : Clipping
	{
		[SimplScalar]
		private MetadataString text;

		public TextClippingDeclaration()
		{ }

		public TextClippingDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataString Text
		{
			get{return text;}
			set
			{
				if (this.text != value)
				{
					this.text = value;
					this.RaisePropertyChanged( () => this.Text );
				}
			}
		}
	}
}

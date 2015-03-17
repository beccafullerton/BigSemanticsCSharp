//
// ClippableDocumentDeclaration.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2015 Interface Ecology Lab. 
//


using Ecologylab.BigSemantics.MetaMetadataNS;
using Ecologylab.BigSemantics.MetadataNS;
using Ecologylab.BigSemantics.MetadataNS.Builtins;
using Ecologylab.BigSemantics.MetadataNS.Scalar;
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
	public class ClippableDocumentDeclaration : Document
	{
		/// <summary>
		/// Clippings based on this.
		/// </summary>
		[SimplCollection]
		[SimplOtherTags(new String[] {"clippings"})]
		[SimplScope("repository_clippings")]
		[MmName("clippings_this_is_in")]
		private List<IClipping<Metadata>> clippingsThisIsIn;

		[SimplScalar]
		private MetadataInteger width;

		[SimplScalar]
		private MetadataInteger height;

		public ClippableDocumentDeclaration()
		{ }

		public ClippableDocumentDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public List<IClipping<Metadata>> ClippingsThisIsIn
		{
			get{return clippingsThisIsIn;}
			set
			{
				if (this.clippingsThisIsIn != value)
				{
					this.clippingsThisIsIn = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}

		public MetadataInteger Width
		{
			get{return width;}
			set
			{
				if (this.width != value)
				{
					this.width = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}

		public MetadataInteger Height
		{
			get{return height;}
			set
			{
				if (this.height != value)
				{
					this.height = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}
	}
}

//
// ImageDeclaration.cs
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
	/// <summary>
	/// The Image Base Class
	/// </summary>
	[SimplInherit]
	public class ImageDeclaration : ClippableDocument<Image>
	{
		[SimplScalar]
		private MetadataDate creationDate;

		public ImageDeclaration()
		{ }

		public ImageDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataDate CreationDate
		{
			get{return creationDate;}
			set
			{
				if (this.creationDate != value)
				{
					this.creationDate = value;
					this.RaisePropertyChanged( () => this.CreationDate );
				}
			}
		}
	}
}

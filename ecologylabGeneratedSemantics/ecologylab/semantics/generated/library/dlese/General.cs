//
// General.cs
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
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library.dlese 
{
	[SimplInherit]
	public class General : Metadata
	{
		[SimplScalar]
		private MetadataString title;

		[SimplCollection("subject")]
		[MmName("subjects")]
		private List<ecologylab.semantics.metadata.scalar.MetadataString> subjects;

		[SimplScalar]
		private MetadataString description;

		[SimplScalar]
		private MetadataString language;

		public General()
		{ }

		public General(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataString Title
		{
			get{return title;}
			set
			{
				if (this.title != value)
				{
					this.title = value;
					this.RaisePropertyChanged( () => this.Title );
				}
			}
		}

		public List<ecologylab.semantics.metadata.scalar.MetadataString> Subjects
		{
			get{return subjects;}
			set
			{
				if (this.subjects != value)
				{
					this.subjects = value;
					this.RaisePropertyChanged( () => this.Subjects );
				}
			}
		}

		public MetadataString Description
		{
			get{return description;}
			set
			{
				if (this.description != value)
				{
					this.description = value;
					this.RaisePropertyChanged( () => this.Description );
				}
			}
		}

		public MetadataString Language
		{
			get{return language;}
			set
			{
				if (this.language != value)
				{
					this.language = value;
					this.RaisePropertyChanged( () => this.Language );
				}
			}
		}
	}
}

//
// CompoundDocumentDeclaration.cs
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

namespace ecologylab.semantics.metadata.builtins.declarations 
{
	[SimplInherit]
	public class CompoundDocumentDeclaration : Document
	{
		/// <summary>
		/// For debugging. Type of the structure recognized by information extraction.
		/// </summary>
		[SimplScalar]
		private MetadataString pageStructure;

		/// <summary>
		/// The search query
		/// </summary>
		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlLeaf})]
		private MetadataString query;

		/// <summary>
		/// Clippings that this document contains.
		/// </summary>
		[SimplCollection]
		[SimplScope("repository_clippings")]
		[MmName("clippings")]
		private List<Clipping> clippings;

		[SimplComposite]
		[MmName("root_document")]
		private CompoundDocument rootDocument;

		public CompoundDocumentDeclaration()
		{ }

		public CompoundDocumentDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataString PageStructure
		{
			get{return pageStructure;}
			set
			{
				if (this.pageStructure != value)
				{
					this.pageStructure = value;
					this.RaisePropertyChanged( () => this.PageStructure );
				}
			}
		}

		public MetadataString Query
		{
			get{return query;}
			set
			{
				if (this.query != value)
				{
					this.query = value;
					this.RaisePropertyChanged( () => this.Query );
				}
			}
		}

		public List<Clipping> Clippings
		{
			get{return clippings;}
			set
			{
				if (this.clippings != value)
				{
					this.clippings = value;
					this.RaisePropertyChanged( () => this.Clippings );
				}
			}
		}

		public CompoundDocument RootDocument
		{
			get{return rootDocument;}
			set
			{
				if (this.rootDocument != value)
				{
					this.rootDocument = value;
					this.RaisePropertyChanged( () => this.RootDocument );
				}
			}
		}
	}
}

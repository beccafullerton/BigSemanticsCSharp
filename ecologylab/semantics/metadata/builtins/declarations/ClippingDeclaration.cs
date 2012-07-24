//
// ClippingDeclaration.cs
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
	public class ClippingDeclaration : Metadata
	{
		[SimplScalar]
		private MetadataString context;

		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlLeafCdata})]
		private MetadataString contextHtml;

		[SimplScalar]
		private MetadataString xpath;

		[SimplComposite]
		[SimplWrap]
		[SimplScope("repository_documents")]
		[MmName("source_doc")]
		private Document sourceDoc;

		[SimplComposite]
		[SimplWrap]
		[SimplScope("repository_documents")]
		[MmName("outlink")]
		private Document outlink;

		public ClippingDeclaration()
		{ }

		public ClippingDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public MetadataString Context
		{
			get{return context;}
			set
			{
				if (this.context != value)
				{
					this.context = value;
					this.RaisePropertyChanged( () => this.Context );
				}
			}
		}

		public MetadataString ContextHtml
		{
			get{return contextHtml;}
			set
			{
				if (this.contextHtml != value)
				{
					this.contextHtml = value;
					this.RaisePropertyChanged( () => this.ContextHtml );
				}
			}
		}

		public MetadataString Xpath
		{
			get{return xpath;}
			set
			{
				if (this.xpath != value)
				{
					this.xpath = value;
					this.RaisePropertyChanged( () => this.Xpath );
				}
			}
		}

		public Document SourceDoc
		{
			get{return sourceDoc;}
			set
			{
				if (this.sourceDoc != value)
				{
					this.sourceDoc = value;
					this.RaisePropertyChanged( () => this.SourceDoc );
				}
			}
		}

		public Document Outlink
		{
			get{return outlink;}
			set
			{
				if (this.outlink != value)
				{
					this.outlink = value;
					this.RaisePropertyChanged( () => this.Outlink );
				}
			}
		}
	}
}

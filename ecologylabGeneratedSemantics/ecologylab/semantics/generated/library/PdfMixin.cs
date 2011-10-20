//
// PdfMixin.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator on 10/20/11.
// Copyright 2011 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using ecologylab.collections;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.generated.library 
{
	/// <summary>
	/// For metadata fields extracted by the PDF parser
	/// </summary>
	[SimplInherit]
	public class PdfMixin : Metadata
	{
		/// <summary>
		/// The author of the pdf document
		/// </summary>
		[SimplScalar]
		private MetadataString author;

		/// <summary>
		/// Summary of the pdf document
		/// </summary>
		[SimplScalar]
		private MetadataString summary;

		/// <summary>
		/// Key Words of the document
		/// </summary>
		[SimplScalar]
		private MetadataString pdfKeywordsString;

		/// <summary>
		/// Subject of the document
		/// </summary>
		[SimplScalar]
		private MetadataString subject;

		[SimplScalar]
		private MetadataString trapped;

		[SimplScalar]
		private MetadataString modified;

		/// <summary>
		/// Contents of the document
		/// </summary>
		[SimplScalar]
		private MetadataString contents;

		/// <summary>
		/// Creation date of the document
		/// </summary>
		[SimplScalar]
		private MetadataString creationdate;

		public PdfMixin()
		{ }

		public MetadataString Author
		{
			get{return author;}
			set{author = value;}
		}

		public MetadataString Summary
		{
			get{return summary;}
			set{summary = value;}
		}

		public MetadataString PdfKeywordsString
		{
			get{return pdfKeywordsString;}
			set{pdfKeywordsString = value;}
		}

		public MetadataString Subject
		{
			get{return subject;}
			set{subject = value;}
		}

		public MetadataString Trapped
		{
			get{return trapped;}
			set{trapped = value;}
		}

		public MetadataString Modified
		{
			get{return modified;}
			set{modified = value;}
		}

		public MetadataString Contents
		{
			get{return contents;}
			set{contents = value;}
		}

		public MetadataString Creationdate
		{
			get{return creationdate;}
			set{creationdate = value;}
		}
	}
}

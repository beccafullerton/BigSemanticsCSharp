//
//  WikipediaPageType.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/04/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;

namespace ecologylab.semantics.generated.library 
{
	/// <summary>
	/// An article on wikipedia
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class WikipediaPageType : Document
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_collection("paragraph")]
		[xml_tag("paragraphs")]
		[mm_name("paragraphs")]
		private List<Paragraph> paragraphs;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_collection("category")]
		[xml_tag("categories")]
		[mm_name("categories")]
		private List<Category> categories;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_collection("thumbinner")]
		[xml_tag("thumbinners")]
		[mm_name("thumbinners")]
		private List<Thumbinner> thumbinners;

		public WikipediaPageType()
		{ }

		public List<Paragraph> Paragraphs
		{
			get{return paragraphs;}
			set{paragraphs = value;}
		}

		public List<Category> Categories
		{
			get{return categories;}
			set{categories = value;}
		}

		public List<Thumbinner> Thumbinners
		{
			get{return thumbinners;}
			set{thumbinners = value;}
		}
	}
}

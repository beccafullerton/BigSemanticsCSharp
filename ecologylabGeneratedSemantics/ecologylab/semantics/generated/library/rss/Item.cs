//
//  Item.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/10/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;

namespace ecologylab.semantics.generated.library.rss 
{
	/// <summary>
	/// One item in a news feed.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class Item : YahooMediaRss
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		[simpl_hints(new Hint[] { Hint.XML_LEAF })]
		private MetadataParsedURL link;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[xml_tag("guid")]
		[simpl_scalar]
		[simpl_hints(new Hint[] { Hint.XML_LEAF })]
		private MetadataParsedURL location;

		public Item()
		{ }

		public MetadataParsedURL Link
		{
			get{return link;}
			set{link = value;}
		}

		public MetadataParsedURL Location
		{
			get{return location;}
			set{location = value;}
		}
	}
}
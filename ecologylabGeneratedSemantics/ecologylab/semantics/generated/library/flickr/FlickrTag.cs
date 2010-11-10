//
//  FlickrTag.cs
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

namespace ecologylab.semantics.generated.library.flickr 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class FlickrTag : Metadata
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private MetadataString tagName;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private MetadataParsedURL tagLink;

		public FlickrTag()
		{ }

		public MetadataString TagName
		{
			get{return tagName;}
			set{tagName = value;}
		}

		public MetadataParsedURL TagLink
		{
			get{return tagLink;}
			set{tagLink = value;}
		}
	}
}
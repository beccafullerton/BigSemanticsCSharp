//
//  Header.cs
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

namespace ecologylab.semantics.generated.library.nsdl 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class Header : Metadata
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[xml_tag("resourceIdentifier")]
		[simpl_scalar]
		private MetadataParsedURL resourceIdentifier;

		public Header()
		{ }

		public MetadataParsedURL ResourceIdentifier
		{
			get{return resourceIdentifier;}
			set{resourceIdentifier = value;}
		}
	}
}
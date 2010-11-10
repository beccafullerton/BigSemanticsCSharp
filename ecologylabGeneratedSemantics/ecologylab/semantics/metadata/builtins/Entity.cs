//
//  Entity.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/10/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.serialization.types.element;
using ecologylab.semantics.metadata;

namespace ecologylab.semantics.metadata.builtins 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class Entity : Metadata, Mappable
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		[simpl_hints(new Hint[] { Hint.XML_LEAF })]
		private MetadataString gist;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		[simpl_hints(new Hint[] { Hint.XML_LEAF })]
		private MetadataParsedURL location;

		public Entity()
		{ }

		public MetadataString Gist
		{
			get{return gist;}
			set{gist = value;}
		}

		public MetadataParsedURL Location
		{
			get{return location;}
			set{location = value;}
		}

		public Object key()
		{
			throw new NotImplementedException();
		}
	}
}
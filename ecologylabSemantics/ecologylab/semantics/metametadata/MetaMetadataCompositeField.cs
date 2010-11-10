//
//  MetaMetadataCompositeField.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 10/10/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.serialization;
using ecologylab.serialization.types;
using ecologylab.semantics.actions;
using ecologylab.semantics.connectors;
using ecologylab.semantics.metametadata;
using ecologylab.net;
using ecologylab.textformat;

namespace ecologylab.semantics.metametadata 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_inherit]
	[xml_tag("composite")]
	public class MetaMetadataCompositeField : MetaMetadataNestedField
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public String type;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public Boolean entity;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public String userAgentName;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public String userAgentString;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public String parser;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_collection]
		[simpl_scope("semantic_action_translation_scope")]
		public List<SemanticAction> semanticActions;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_collection("def_var")]
		[simpl_nowrap]
		public List<DefVar> defVars;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public Boolean reloadPageFirstTime;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public Boolean rejectCookies;

		public MetaMetadataCompositeField()
		{ }
	}
}
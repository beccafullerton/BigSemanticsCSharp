//
//  BasicSite.cs
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

namespace ecologylab.io 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[xml_tag("site")]
	public class BasicSite : ElementState
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public String domain;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public Single minDownloadInterval;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		public Boolean ignoreSemanticBoost;

		public BasicSite()
		{ }
	}
}
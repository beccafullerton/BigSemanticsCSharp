//
//  AndCondition.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 10/10/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylabFundamental.ecologylab.attributes;
using ecologylabFundamental.ecologylab.serialization;
using ecologylabFundamental.ecologylab.serialization.types;
using ecologylab.semantics.actions;
using ecologylab.semantics.connectors;
using ecologylab.semantics.metametadata;
using ecologylab.net;
using ecologylab.textformat;

namespace ecologylab.semantics.actions 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_inherit]
	[xml_tag("and")]
	public class AndCondition : Condition
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_collection]
		[simpl_scope("condition_scope")]
		[simpl_nowrap]
		public List<Condition> checks;

		public AndCondition()
		{ }
	}
}

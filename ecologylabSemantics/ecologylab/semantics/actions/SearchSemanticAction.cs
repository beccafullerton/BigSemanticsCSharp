//
//  SearchSemanticAction.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using Simpl.Serialization.Attributes;

namespace ecologylab.semantics.actions 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[SimplInherit]
	[SimplTag("search")]
    public class SearchSemanticAction : SemanticAction 
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String engine;

		public SearchSemanticAction()
		{ }

		public String Engine
		{
			get{return engine;}
			set{engine = value;}
		}
	}
}

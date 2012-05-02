//
//  ChooseSemanticAction.cs
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
	[SimplTag("choose")]
    public class ChooseSemanticAction : SemanticAction
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplNoWrap]
		[SimplCollection("case")]
        private List<IfSemanticAction> cases;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplComposite]
        private Otherwise otherwise;

		public ChooseSemanticAction()
		{ }

        public List<IfSemanticAction> Cases
		{
			get{return cases;}
			set{cases = value;}
		}

		public Otherwise Otherwise
		{
			get{return otherwise;}
			set{otherwise = value;}
		}
	}
}
//
//  SingleSourceRelatedness.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 04/02/11.
//  Copyright 2011 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.serialization;

namespace wixplorer.concept 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	public class SingleSourceRelatedness : ElementState
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String source;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_map]
		private Map<String, Concept> targets;

		public SingleSourceRelatedness()
		{ }

		public String Source
		{
			get{return source;}
			set{source = value;}
		}

		public Map<String, Concept> Targets
		{
			get{return targets;}
			set{targets = value;}
		}
	}
}

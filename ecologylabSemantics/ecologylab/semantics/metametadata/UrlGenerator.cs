//
// UrlGenerator.cs
// s.im.pl serialization
//
// Generated by DotNetTranslator on 10/14/11.
// Copyright 2011 Interface Ecology Lab. 
//


using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using ecologylab.collections;
using ecologylab.serialization;

namespace ecologylab.semantics.metametadata 
{
	[SimplInherit]
	public class UrlGenerator : ElementState
	{
		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlAttribute})]
		private String type;

		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlAttribute})]
		private String engine;

		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlAttribute})]
		private String useId;

		[SimplScalar]
		[SimplHints(new Hint[] {Hint.XmlAttribute})]
		private String pattern;

		public UrlGenerator()
		{ }

		public String Type
		{
			get{return type;}
			set{type = value;}
		}

		public String Engine
		{
			get{return engine;}
			set{engine = value;}
		}

		public String UseId
		{
			get{return useId;}
			set{useId = value;}
		}

		public String Pattern
		{
			get{return pattern;}
			set{pattern = value;}
		}
	}
}

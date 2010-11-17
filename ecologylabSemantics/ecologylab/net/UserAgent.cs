//
//  UserAgent.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.serialization;
using ecologylab.serialization.types.element;

namespace ecologylab.net 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	public class UserAgent : ElementState, Mappable
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String name;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[xml_tag("string")]
		[simpl_scalar]
		private String userAgentString;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[xml_tag("default")]
		[simpl_scalar]
		private Boolean defaultAgent;

		public UserAgent()
		{ }

		public String Name
		{
			get{return name;}
			set{name = value;}
		}

		public String UserAgentString
		{
			get{return userAgentString;}
			set{userAgentString = value;}
		}

		public Boolean DefaultAgent
		{
			get{return defaultAgent;}
			set{defaultAgent = value;}
		}

		public Object key()
		{
			throw new NotImplementedException();
		}
	}
}

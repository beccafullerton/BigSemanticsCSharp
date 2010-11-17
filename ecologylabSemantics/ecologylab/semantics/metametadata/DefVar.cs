//
//  DefVar.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.serialization;
using ecologylab.serialization.types;

namespace ecologylab.semantics.metametadata 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	public class DefVar : ElementState
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String name;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String xpath;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String type;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String contextNode;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private ScalarType scalarType;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String value;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String comment;

		public DefVar()
		{ }

		public String Name
		{
			get{return name;}
			set{name = value;}
		}

		public String Xpath
		{
			get{return xpath;}
			set{xpath = value;}
		}

		public String Type
		{
			get{return type;}
			set{type = value;}
		}

		public String ContextNode
		{
			get{return contextNode;}
			set{contextNode = value;}
		}

		public ScalarType ScalarTypeP
		{
			get{return scalarType;}
			set{scalarType = value;}
		}

		public String Value
		{
			get{return value;}
			set{this.value = value;}
		}

		public String Comment
		{
			get{return comment;}
			set{comment = value;}
		}
	}
}

//
//  MetaMetadataSelector.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using Simpl.Fundamental.Net;
using Simpl.Serialization.Attributes;
using Simpl.Serialization;
using Simpl.Serialization.Types.Element;
using Ecologylab.BigSemantics.MetaMetadataNS.Net;

namespace Ecologylab.BigSemantics.MetaMetadataNS 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[SimplInherit]
	public class MetaMetadataSelector : ElementState, IMappable<String>
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String name;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String prefName;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String defaultPref;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private ParsedUri urlStripped;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private ParsedUri urlPathTree;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private System.Text.RegularExpressions.Regex urlRegex;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String domain;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplCollection("mime_type")]
		[SimplNoWrap]
		private List<String> mimeTypes;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplCollection("suffix")]
		[SimplNoWrap]
		private List<String> suffixes;

        public static MetaMetadataSelector NULL_SELECTOR = new MetaMetadataSelector();

		public MetaMetadataSelector()
		{ }

        #region Properties
        
        public String Name
		{
			get{return name;}
			set{name = value;}
		}

		public String PrefName
		{
			get{return prefName;}
			set{prefName = value;}
		}

		public String DefaultPref
		{
			get{return defaultPref;}
			set{defaultPref = value;}
		}

		public ParsedUri UrlStripped
		{
			get{return urlStripped;}
			set{urlStripped = value;}
		}

		public ParsedUri UrlPathTree
		{
			get{return urlPathTree;}
			set{urlPathTree = value;}
		}

		public System.Text.RegularExpressions.Regex UrlRegex
		{
			get{return urlRegex;}
			set{urlRegex = value;}
		}

		public String Domain
		{
			get{return domain;}
			set{domain = value;}
		}

		public List<String> MimeTypes
		{
			get{return mimeTypes;}
			set{mimeTypes = value;}
		}

		public List<String> Suffixes
		{
			get{return suffixes;}
			set{suffixes = value;}
		}
        #endregion
        
        public String Key()
		{
            return name;
		}
	}
}

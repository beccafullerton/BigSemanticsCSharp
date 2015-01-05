//
//  BasicSite.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using Simpl.Serialization.Attributes;
using Simpl.Serialization;
using Simpl.Serialization.Types.Element;


namespace Ecologylab.BigSemantics.MetaMetadataNS.IO 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[SimplTag("site")]
	public class BasicSite : ElementState, IMappable<String>
	{
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String domain;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Single minDownloadInterval;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Boolean ignoreSemanticBoost;

		public BasicSite()
		{ }

		public String Domain
		{
			get{return domain;}
			set{domain = value;}
		}

		public Single MinDownloadInterval
		{
			get{return minDownloadInterval;}
			set{minDownloadInterval = value;}
		}

		public Boolean IgnoreSemanticBoost
		{
			get{return ignoreSemanticBoost;}
			set{ignoreSemanticBoost = value;}
		}

		public String Key()
		{
            return domain;
		}
	}
}

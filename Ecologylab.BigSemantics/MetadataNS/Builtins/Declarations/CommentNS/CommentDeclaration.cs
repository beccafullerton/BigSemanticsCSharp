//
// CommentDeclaration.cs
// s.im.pl serialization
//
// Generated by MetaMetadataDotNetTranslator.
// Copyright 2015 Interface Ecology Lab. 
//


using Ecologylab.BigSemantics.MetaMetadataNS;
using Ecologylab.BigSemantics.MetadataNS;
using Ecologylab.BigSemantics.MetadataNS.Builtins;
using Ecologylab.BigSemantics.MetadataNS.Builtins.PersonNS;
using Ecologylab.BigSemantics.MetadataNS.Scalar;
using Ecologylab.Collections;
using Simpl.Fundamental.Generic;
using Simpl.Serialization;
using Simpl.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecologylab.BigSemantics.MetadataNS.Builtins.Declarations.CommentNS 
{
	[SimplInherit]
	public class CommentDeclaration : RichDocument
	{
		[SimplComposite]
		[MmName("author")]
		private Person author;

		/// <summary>
		/// How long this comment has been there.
		/// </summary>
		[SimplScalar]
		private MetadataString time;

		/// <summary>
		/// How many votes this comment has got.
		/// </summary>
		[SimplScalar]
		private MetadataInteger count;

		public CommentDeclaration()
		{ }

		public CommentDeclaration(MetaMetadataCompositeField mmd) : base(mmd) { }


		public Person Author
		{
			get{return author;}
			set
			{
				if (this.author != value)
				{
					this.author = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}

		public MetadataString Time
		{
			get{return time;}
			set
			{
				if (this.time != value)
				{
					this.time = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}

		public MetadataInteger Count
		{
			get{return count;}
			set
			{
				if (this.count != value)
				{
					this.count = value;
					// TODO we need to implement our property change notification mechanism.
				}
			}
		}
	}
}

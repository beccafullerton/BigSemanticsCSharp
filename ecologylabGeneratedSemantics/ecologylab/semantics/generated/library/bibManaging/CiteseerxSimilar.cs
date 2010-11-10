//
//  CiteseerxSimilar.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/10/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.semantics.metadata.scalar;
using ecologylab.semantics.metadata;

namespace ecologylab.semantics.generated.library.bibManaging 
{
	/// <summary>
	/// Citation or co-citation page from CiteSeerX.
	/// </summary>
	[simpl_descriptor_classes(new Type[] { typeof(MetadataClassDescriptor), typeof(MetadataFieldDescriptor) })]
	[simpl_inherit]
	public class CiteseerxSimilar : CiteseerxRecord
	{
		public CiteseerxSimilar()
		{ }
	}
}
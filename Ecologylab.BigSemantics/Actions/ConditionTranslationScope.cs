﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simpl.Serialization;
using Ecologylab.BigSemantics.Actions;

namespace Ecologylab.BigSemantics.Actions
{
    public class ConditionTranslationScope
    {
        public static readonly String ConditionScope = "condition_scope";

	    private static readonly	Type[] Classes = {
		    typeof(Condition),
		    typeof(AndCondition),
		    typeof(OrCondition),
		    typeof(NotCondition),
		    typeof(NotNull),
		    typeof(Null)
	    };

	    public static SimplTypesScope Get()
	    {
		    return SimplTypesScope.Get(ConditionScope, Classes);
	    }
    }
}

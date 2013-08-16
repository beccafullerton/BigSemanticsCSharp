﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecologylab.Semantics.MetaMetadataNS;
using Ecologylab.Semantics.MetadataNS.Builtins.Declarations;
using Ecologylab.Semantics.MetadataNS.Scalar;

namespace Ecologylab.Semantics.MetadataNS.Builtins
{
    public class CreativeAct : CreativeActDeclaration
    {
        public enum CreativeAction
        {
            CurateClipping = 1,
            CurateLink = 2,
            AnnotateArtifact = 3,
            Note = 4,
            Sketch = 5,
            Upload = 6,
            Edit = 7
        }

        public CreativeAct() { }

        public CreativeAct(MetaMetadataCompositeField mmd) : base(mmd) { }

        public new CreativeAction Action
        {
            get { return (CreativeAction) base.Action.Value; }
            set
            {
                if (base.Action == null)
                    base.Action = new MetadataInteger();
                base.Action.Value = (int) value;
            }

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simpl.Fundamental.Net;
using ecologylab.semantics.collecting;
using ecologylab.semantics.metadata.builtins;
using ecologylab.semantics.metametadata;

namespace ecologylab.semantics.documentparsers
{
  class FieldParserBase : DocumentParser
  {
      public override void Parse(SemanticsSessionScope semanticsSessionScope, ParsedUri puri, MetaMetadata metaMetadata)
      {
          throw new NotImplementedException();
      }
  }
}
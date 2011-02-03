﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ecologylab.net;
using System.IO;

namespace ecologylab.semantics.metadata.scalar
{

    public interface IMetadataScalar
    {
        Object Value
        {
            get;
            set;
        }
    }

    abstract public class MetadataScalarBase<T> : IMetadataScalar
    {
        public T value;
        public static String VALUE_FIELD_NAME	    = "value";

        public MetadataScalarBase()
        {
        
        }

        public MetadataScalarBase(object value)
        {
            this.value = (T) value;
        }

        public object Value
        {
            get { return value; }
            set { this.value = (T)value; }
        }

        public override String ToString()
        {
            return value == null ? "null" : value.ToString();
        }
    }

    public class MetadataString : MetadataScalarBase<String>
    {
        public MetadataString(){}

        //The termvector stuff goes here !


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public MetadataString(object value):base(value)
        {}

    }
    public class MetadataInteger : MetadataScalarBase<int>
    {
        public MetadataInteger(){}
        public MetadataInteger(object value):base(value)
        {}

    }
    public class MetadataParsedURL : MetadataScalarBase<ParsedUri>
    {
        public MetadataParsedURL(){}
        public MetadataParsedURL(object value):base(value)
        {}

    }
    public class MetadataDate : MetadataScalarBase<DateTime>
    {
        public MetadataDate(){}
        public MetadataDate(object value):base(value)
        {}
    }
    public class MetadataStringBuilder : MetadataScalarBase<StringBuilder>
    {
        public MetadataStringBuilder(){}
        public MetadataStringBuilder(object value):base(value)
        {}
    }

    public class MetadataFile : MetadataScalarBase<FileStream>
    {
        public MetadataFile() { }
        public MetadataFile(object value)
            : base(value)
        { }
    }

}

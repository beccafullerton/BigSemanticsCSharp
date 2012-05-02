//
//  MetaMetadataField.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Simpl.Fundamental.Generic;
using Simpl.Serialization.Attributes;
using Simpl.Serialization;
using Simpl.Serialization.Types;
using Simpl.Serialization.Types.Element;
using ecologylab.semantics.metadata;


using System.Text.RegularExpressions;
using ecologylabSemantics.ecologylab.semantics.metametadata;

namespace ecologylab.semantics.metametadata 
{
	[SimplInherit]
    [SimplDescriptorClasses(new[] { typeof(MetaMetadataClassDescriptor), typeof(MetaMetadataFieldDescriptor)})]
	public abstract class MetaMetadataField : ElementState, IMappable<String>, IEnumerable<MetaMetadataField>
    {
        #region Variables

        private static readonly List<MetaMetadataField> EMPTY_COLLECTION        = new List<MetaMetadataField>(0);
        private static readonly IEnumerator<MetaMetadataField> EMPTY_ITERATOR   = EMPTY_COLLECTION.GetEnumerator();
        
        /// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String name;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
        [MmDontInherit]
		private String comment;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String tag;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String xpath;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String contextNode;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplMap]
		// [SimplClasses(new Type[] { typeof(MetaMetadataField), typeof(MetaMetadataScalarField), typeof(MetaMetadataCompositeField), typeof(MetaMetadataCollectionField) })]
		[SimplScope(MetaMetadataFieldTranslationScope.NAME)]
		[SimplNoWrap]
		protected DictionaryList<String, MetaMetadataField> kids;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Boolean hide;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Boolean alwaysShow;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String style;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Single layer;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String navigatesTo;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String shadows;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String label;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Boolean isFacet;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private Boolean ignoreInTermVector;

        /// <summary>
        /// 
        ///  The name of natural id if this field is used as one.
        /// </summary>
        [SimplScalar]
        private String asNaturalId;

        /// <summary>
        /// 
        ///  schema.org microdata item_prop name.
        /// </summary>
        [SimplScalar]
	    private String schemaOrgItemprop;

        [SimplScalar]
	    private String fieldParserKey;

        protected MetadataClassDescriptor metadataClassDescriptor;

	    private bool fieldsSortedForDisplay = false;

	    protected Type metadataClass;

	    protected MetadataFieldDescriptor metadataFieldDescriptor;

	    private HashSet<String> nonDisplayedFieldNames = new HashSet<String>();

        private String _displayedLabel = null;

        private bool _bindFieldDescriptorsFinished;
       
        /**
	    * from which field this one inherits. could be null if this field is declared for the first time.
	    */
        private MetaMetadataField inheritedField = null;

	    protected bool inheritFinished;

        /**
         * in which meta-metadata this field is declared.
         */
        private MetaMetadata declaringMmd = null;

        private MetadataFieldDescriptorProxy _fieldDescriptorProxy;
	

        public MetaMetadataRepository Repository { get; set; }

        #endregion
        
        public MetaMetadataField()
		{  
            _fieldDescriptorProxy = new MetadataFieldDescriptorProxy(this); 
        }

        protected void SortForDisplay()
        {

            DictionaryList<String, MetaMetadataField> childMetaMetadata = Kids;
            if (childMetaMetadata != null)
            {
                childMetaMetadata.ValuesInList.Sort(delegate(MetaMetadataField f1, MetaMetadataField f2) { return -Math.Sign(f1.Layer - f2.Layer); });
            }

            fieldsSortedForDisplay = true;

        }

        public DictionaryList<String, MetaMetadataField> InitializeChildMetaMetadata()
        {
            this.kids = new DictionaryList<string, MetaMetadataField>();
            return this.kids;
        }


        internal virtual bool GetClassAndBindDescriptors(SimplTypesScope metadataTScope)
        {
            return true;
        }

        public int GetFieldType()
        {
            if (metadataFieldDescriptor != null)
                return metadataFieldDescriptor.FdType;
            Type thisType = GetType();
            if (thisType == typeof(MetaMetadataCompositeField))
                return FieldTypes.CompositeElement;
            if (thisType == typeof(MetaMetadataCollectionField))
            {
                MetaMetadataCollectionField coll = (MetaMetadataCollectionField)this;
                if (coll.ChildScalarType != null)
                    return FieldTypes.CollectionScalar;
                else
                    return FieldTypes.CollectionElement;
            }
            else
                return FieldTypes.Scalar;
        }

        internal Type GetMetadataClass(SimplTypesScope metadataTScope)
        {
            Type result = metadataClass;
		    if (result == null)
		    {
			    MetadataClassDescriptor descriptor = this.MetadataClassDescriptor;
			    result= (descriptor == null ? null : descriptor.DescribedClass);
                metadataClass = result;
		    }
            return result;
        }

//        internal void InheritNonDefaultAttributes(MetaMetadataField inheritFrom)
//        {
//            ClassDescriptor classDescriptor = ClassDescriptor;
//
//            foreach (FieldDescriptor fieldDescriptor in classDescriptor.AttributeFieldDescriptors)
//            {
//                ScalarType scalarType = null;//TODO FIXME fieldDescriptor.GetScalarType();
//                try
//                {
//                    if (scalarType != null && scalarType.IsDefaultValue(fieldDescriptor.Field, this)
//                            && !scalarType.IsDefaultValue(fieldDescriptor.Field, inheritFrom))
//                    {
//                        Object value = fieldDescriptor.Field.GetValue(inheritFrom);
//                        fieldDescriptor.Field.SetValue(this, value);
//                        //Console.WriteLine("inherit\t" + this.Name + "." + fieldDescriptor.FieldName + "\t= " + value);
//                    }
//                }
//                catch (Exception e)
//                {
//                    // TODO Auto-generated catch block
//                    Console.WriteLine("inherit\t" + this.Name + "." + fieldDescriptor.Name + " Failed, ignore it.\n" + e);
//                }
//            }
//
//        }

        public String GetTagForTranslationScope()
        {
            return Tag ?? Name;
        }

        #region Properties
        
        public String Name
		{
			get{return name;}
			set{name = value;}
		}

		public String Comment
		{
			get{return comment;}
			set{comment = value;}
		}

		public virtual String Tag
		{
			get{return tag;}
			set{tag = value;}
		}

		public String Xpath
		{
			get{return xpath;}
			set{xpath = value;}
		}

		public String ContextNode
		{
			get{return contextNode;}
			set{contextNode = value;}
		}

        public DictionaryList<String, MetaMetadataField> Kids
		{
			get { return kids ?? (kids = new DictionaryList<string, MetaMetadataField>()); }
            set{kids = value;}
		}

		public Boolean Hide
		{
			get{return hide;}
			set{hide = value;}
		}

		public Boolean AlwaysShow
		{
			get{return alwaysShow;}
			set{alwaysShow = value;}
		}

		public String Style
		{
			get{return style;}
			set{style = value;}
		}

		public Single Layer
		{
			get{return layer;}
			set{layer = value;}
		}

		public String NavigatesTo
		{
			get{return navigatesTo;}
			set{navigatesTo = value;}
		}

		public String Shadows
		{
			get{return shadows;}
			set{shadows = value;}
		}

		public String Label
		{
			get{return label;}
			set{label = value;}
		}

		public Boolean IsFacet
		{
			get{return isFacet;}
			set{isFacet = value;}
		}

		public Boolean IgnoreInTermVector
		{
			get{return ignoreInTermVector;}
			set{ignoreInTermVector = value;}
		}

	    public String FieldParserKey
	    {
            get { return fieldParserKey; }
            set { fieldParserKey = value; }
	    }

        public Boolean HasChildren()
        {
            return kids != null && kids.Count > 0;
        }

//        public String Type
//        {
//            get { return null; }
//        }

        public MetadataClassDescriptor MetadataClassDescriptor
        {
            get { return metadataClassDescriptor; }
            set
            {
                metadataClassDescriptor = value;
                metadataClass = value.DescribedClass;
            }
        }

        #endregion
        public String Key()
		{
            return name;
		}

        public MetadataFieldDescriptor MetadataFieldDescriptor 
        {
            get { return metadataFieldDescriptor; } 
            set{ metadataFieldDescriptor = value; } 
        }

	    public MetaMetadataField InheritedField
	    {
	        get { return inheritedField; }
	        set { inheritedField = value; }
	    }

	    public MetaMetadata DeclaringMmd
	    {
	        get { return declaringMmd; }
	        set { declaringMmd = value; }
	    }

	    public HashSet<string> NonDisplayedFieldNames
	    {
	        get { return nonDisplayedFieldNames; }
	        set { nonDisplayedFieldNames = value; }
	    }

	    public string AsNaturalId
	    {
	        get { return asNaturalId; }
	        set { asNaturalId = value; }
	    }

	    public Type MetadataClass
	    {
	        get
	        {
	            if (metadataClass == null && MetadataClassDescriptor != null)
	                metadataClass = MetadataClassDescriptor.DescribedClass;
                return metadataClass;
	        }
	    }

	    public MetaMetadataField LookupChild(String name)
        {
            MetaMetadataField result;
            kids.TryGetValue(name, out result);
            return result;
        }

        public IEnumerator<MetaMetadataField> GetEnumerator()
        {
            return (kids != null) ? kids.Values.GetEnumerator() : EMPTY_ITERATOR;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public String GetDisplayedLabel()
        {
            String result = _displayedLabel;
            if (result == null)
            {
                if (label != null)
                    result = label;
                else
                    result = name.Replace("_", " ");

                _displayedLabel = result;
            }
            return result;
        }

        public bool IsChildFieldDisplayed(String childName)
        {
            return NonDisplayedFieldNames == null ? true : !NonDisplayedFieldNames.Contains(childName);
        }

        /**
         * get the type name of this field, in terms of meta-metadata.
         * 
         * TODO redefining this.
         * 
         * @return the type name.
         */
        abstract public String GetTypeName();

	    public void InheritAttributes(MetaMetadataField inheritFrom)
        {
            var classDescriptor = ClassDescriptor.GetClassDescriptor(this);

            foreach (MetaMetadataFieldDescriptor fieldDescriptor in classDescriptor.AllFieldDescriptors)
            {
                if (fieldDescriptor.IsInheritable)
                {
                    ScalarType scalarType = fieldDescriptor.ScalarType;
                    try
                    {
                        if (scalarType != null
                                && scalarType.IsDefaultValue(fieldDescriptor.Field, this)
                                && !scalarType.IsDefaultValue(fieldDescriptor.Field, inheritFrom))
                        {
                            Object value = fieldDescriptor.Field.GetValue(inheritFrom);
                            fieldDescriptor.Field.SetValue(this, value);
                            Debug.WriteLine("inherit\t" + this.Name + "." + fieldDescriptor.Name + "\t= " + value);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(inheritFrom.Name + " doesn't have field " + fieldDescriptor.Name + ", ignore it.");
                        //					e.printStackTrace();
                    }
                }
            }
        }


        public MetadataFieldDescriptor BindMetadataFieldDescriptor(SimplTypesScope metadataTScope, MetadataClassDescriptor metadataClassDescriptor)
        {
            MetadataFieldDescriptor metadataFieldDescriptor = this.metadataFieldDescriptor;
            if (metadataFieldDescriptor == null)
            {
                metadataFieldDescriptor = this.metadataFieldDescriptor;
                String fieldName = this.GetFieldName(false);
                if (metadataFieldDescriptor == null)
                {
                    FieldDescriptor fd = metadataClassDescriptor.GetFieldDescriptorByFieldName(fieldName);
                    metadataFieldDescriptor = (MetadataFieldDescriptor) fd;
                    if (metadataFieldDescriptor != null)
                    {
                        // FIXME is the following "if" statement still useful? I never see the condition is
                        // true. can we remove it? -- yin 7/26/2011
                        // if we don't have a field, then this is a wrapped collection, so we need to get the
                        // wrapped field descriptor
                        if (metadataFieldDescriptor.Field == null)
                        {
                            FieldDescriptor wfd = metadataFieldDescriptor.WrappedFd;
                            metadataFieldDescriptor = (MetadataFieldDescriptor) wfd;
                        }

                        this.metadataFieldDescriptor = metadataFieldDescriptor;

                        if (this.metadataFieldDescriptor != null)
                        	CustomizeFieldDescriptor(metadataTScope, _fieldDescriptorProxy);
                        if (this.metadataFieldDescriptor != metadataFieldDescriptor)
                        {
                            String tagName = this.metadataFieldDescriptor.TagName;
                            int fieldType = this.metadataFieldDescriptor.FdType;
                            if (fieldType == FieldTypes.CollectionElement || fieldType == FieldTypes.MapElement)
                                tagName = this.metadataFieldDescriptor.CollectionOrMapTagName;
                            metadataClassDescriptor.AllFieldDescriptorsByTagNames.Put(tagName,
                                                                                      this.metadataFieldDescriptor);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Ignoring <" + fieldName +
                                    "> because no corresponding MetadataFieldDescriptor can be found.");
                }
            }
            return metadataFieldDescriptor;
        }

        private void CustomizeFieldDescriptor(SimplTypesScope metadataTScope, MetadataFieldDescriptorProxy fieldDescriptorProxy)
	    {
	        fieldDescriptorProxy.SetTagName(Tag ?? Name);
	    }

	    private string GetFieldName(bool capitalized)
	    {
            if (capitalized)
                return GetCapFieldName();

	        string result = _fieldNameInCSharp;

            if(result == null)
            {
                result = XmlTools.FieldNameFromElementName(Name);
                _fieldNameInCSharp = result;
            }

	        return _fieldNameInCSharp;

	    }

        private String _fieldNameInCSharp = null;
        private String _capFieldNameInCSharp = null;

        public String GetCapFieldName()
        {
            String rst = _capFieldNameInCSharp;
            if (rst == null)
            {
                rst = XmlTools.CamelCaseFromXMLElementName(Name, true);
                _capFieldNameInCSharp = rst;
            }
            return _capFieldNameInCSharp;
        }

        private String _toString = null;

        public override string ToString()
        {
            String result = _toString;
		    if (result == null)
		    {
			    result = this.GetType().ToString() + ParentString() + "<" + this.Name + ">";
			    _toString = result;
		    }
		    return result;
        }

        public String ParentString()
	    {
		    String result = "";
	
		    ElementState parent = this.Parent;
		    while (parent is MetaMetadataField)
		    {
			    MetaMetadataField pf = (MetaMetadataField) parent;
			    result = "<" + pf.Name + ">";
			    parent = parent.Parent;
		    }
		    return result;
	    }

	    /**
	     * this class encapsulate the clone-on-write behavior of metadata field descriptor associated
	     * with this field.
	     * 
	     * @author quyin
	     *
	     */
        protected internal class MetadataFieldDescriptorProxy
        {
            private MetaMetadataField outer;
            
            public MetadataFieldDescriptorProxy(MetaMetadataField outer)
            {
                this.outer = outer;
            }

            private void CloneFieldDescriptorOnWrite()
		    {
			    if (outer.MetadataFieldDescriptor.DescriptorClonedFrom == null)
				    outer.MetadataFieldDescriptor = outer.MetadataFieldDescriptor.Clone();
		    }

            public void SetTagName(String newTagName)
		    {
			    if (newTagName != null && !newTagName.Equals(outer.MetadataFieldDescriptor.TagName))
			    {
				    CloneFieldDescriptorOnWrite();
				    outer.MetadataFieldDescriptor.TagName = newTagName;
			    }
		    }

            public void SetElementClassDescriptor(MetadataClassDescriptor metadataClassDescriptor)
		    {
			    if (metadataClassDescriptor != outer.MetadataFieldDescriptor.ElementClassDescriptor)
			    {
				    CloneFieldDescriptorOnWrite();
				    outer.MetadataFieldDescriptor.ElementClassDescriptor = metadataClassDescriptor;
			    }
		    }

            public void SetCollectionOrMapTagName(String childTag)
		    {
			    if (childTag != null && !childTag.Equals(outer.MetadataFieldDescriptor.CollectionOrMapTagName))
			    {
				    CloneFieldDescriptorOnWrite();
				   outer.MetadataFieldDescriptor.CollectionOrMapTagName = childTag;
			    }
		    }

            public void SetWrapped(bool wrapped)
		    {
			    if (wrapped != outer.MetadataFieldDescriptor.IsWrapped)
			    {
				    CloneFieldDescriptorOnWrite();
				    outer.MetadataFieldDescriptor.IsWrapped = wrapped;
			    }
		    }

        }
    }
    
	
	

}
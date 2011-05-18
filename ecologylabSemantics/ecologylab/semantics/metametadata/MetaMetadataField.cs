//
//  MetaMetadataField.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.serialization;
using ecologylab.serialization.types.element;
using ecologylab.semantics.metadata;
using ecologylab.generic;
using ecologylab.serialization.types;
using System.Text.RegularExpressions;

namespace ecologylab.semantics.metametadata 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	[simpl_inherit]
	public class MetaMetadataField : ElementState, Mappable, IEnumerable<MetaMetadataField>
    {
        #region Variables

        private static readonly List<MetaMetadataField> EMPTY_COLLECTION        = new List<MetaMetadataField>(0);
        private static readonly IEnumerator<MetaMetadataField> EMPTY_ITERATOR   = EMPTY_COLLECTION.GetEnumerator();
        
        /// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String name;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String comment;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String tag;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String xpath;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String contextNode;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[xml_tag("extends")]
		[simpl_scalar]
		protected String extendsAttribute;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_map]
		[simpl_classes(new Type[] { typeof(MetaMetadataField), typeof(MetaMetadataScalarField), typeof(MetaMetadataCompositeField), typeof(MetaMetadataCollectionField) })]
		[simpl_nowrap]
		protected DictionaryList<String, MetaMetadataField> kids;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private Boolean hide;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private Boolean alwaysShow;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String style;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private Single layer;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String navigatesTo;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String shadows;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String label;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private Boolean isFacet;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private Boolean ignoreInTermVector;

        protected MetadataClassDescriptor metadataClassDescriptor;

        protected bool inheritMetaMetadataFinished = false;

        private bool fieldsSortedForDisplay = false;

        private Type metadataClass;

        MetadataFieldDescriptor metadataFieldDescriptor;

        HashSet<String> nonDisplayedFieldNames = new HashSet<String>();

        private String _displayedLabel = null;

        private bool _bindFieldDescriptorsFinished;

        #endregion
        
        public MetaMetadataField()
		{ }

        protected void SortForDisplay()
        {

            DictionaryList<String, MetaMetadataField> childMetaMetadata = Kids;
            if (childMetaMetadata != null)
            {
                childMetaMetadata.Values.Sort(delegate(MetaMetadataField f1, MetaMetadataField f2) { return -Math.Sign(f1.Layer - f2.Layer); });
            }

            fieldsSortedForDisplay = true;

        }

        public DictionaryList<String, MetaMetadataField> InitializeChildMetaMetadata()
        {
            this.kids = new DictionaryList<string, MetaMetadataField>();
            return this.kids;
        }

        protected void InheritForField(MetaMetadataField fieldToInheritFrom)
        {
            String fieldName = fieldToInheritFrom.Name;
            // this is for the case when meta_metadata has no meta_metadata fields of its own. It just
            // inherits from super class.

            DictionaryList<String, MetaMetadataField> childMetaMetadata = Kids;
            if (childMetaMetadata == null)
            {
                childMetaMetadata = InitializeChildMetaMetadata();
            }

            // *do not* override fields in here with fields from super classes.

            MetaMetadataField fieldToInheritTo;
            childMetaMetadata.TryGetValue(fieldName, out fieldToInheritTo);

            if (fieldToInheritTo is MetaMetadataCollectionField)
		    {
			    MetaMetadataCompositeField childComposite = ((MetaMetadataCollectionField) fieldToInheritTo).getMetaMetadataCompositeField();
			    if (childComposite != null)
			    {
                    MetaMetadataCompositeField inheritedChildComposite = ((MetaMetadataCollectionField)fieldToInheritFrom).getMetaMetadataCompositeField();
				
				    if (MetaMetadataCollectionField.UNRESOLVED_NAME == childComposite.Name)
				    {
					    fieldToInheritTo.kids.Remove(MetaMetadataCollectionField.UNRESOLVED_NAME);
					    childComposite.InheritNonDefaultAttributes(inheritedChildComposite);
					    childComposite.Name = inheritedChildComposite.Name;
					    fieldToInheritTo.kids.Add(childComposite.Name, childComposite);
				    }
			    }
		    }

            if (fieldToInheritTo == null)
            {
                childMetaMetadata.Add(fieldName, fieldToInheritFrom);
                fieldToInheritTo = fieldToInheritFrom;
            }
            else
            {
                fieldToInheritTo.InheritNonDefaultAttributes(fieldToInheritFrom);
            }

            DictionaryList<String, MetaMetadataField> inheritedChildMetaMetadata = fieldToInheritFrom.Kids;
            if (inheritedChildMetaMetadata != null)
            {
                foreach (MetaMetadataField grandChildMetaMetadataField in inheritedChildMetaMetadata.Values)
                {
                    fieldToInheritTo.InheritForField(grandChildMetaMetadataField);
                }
            }
        }

        #region binders

        internal virtual bool GetClassAndBindDescriptors(TranslationScope metadataTScope)
        {
            return true;
        }

        /**
	     * Obtain a map of FieldDescriptors for this class, with the field names as key, but with the
	     * mixins field removed. Use lazy evaluation, caching the result by class name.
	     * 
	     * @param metadataTScope
	     *          TODO
	     * 
	     * @return A map of FieldDescriptors, with the field names as key, but with the mixins field
	     *         removed.
	     */
	    protected bool BindClassDescriptor(Type metadataClass, TranslationScope metadataTScope)
	    {
		    MetadataClassDescriptor metadataClassDescriptor = this.metadataClassDescriptor;
		    if (metadataClassDescriptor == null)
		    {
                lock (this)
                {
				    metadataClassDescriptor = this.metadataClassDescriptor;
				    if (metadataClassDescriptor == null)
				    {
                        metadataClassDescriptor = (MetadataClassDescriptor)ClassDescriptor.GetClassDescriptor(metadataClass);

                        if (metadataClassDescriptor != null)
                        {
                            BindMetadataFieldDescriptors(metadataTScope, metadataClassDescriptor);
                            this.metadataClassDescriptor = metadataClassDescriptor;
                        }
                        else
                            return false;
				    }
                }
		    }
            return true;
	    }

        private void BindMetadataFieldDescriptors(TranslationScope metadataTScope, MetadataClassDescriptor metadataClassDescriptor)
        {
            if (Kids == null && _bindFieldDescriptorsFinished)
                return;

            List<MetaMetadataField> nonBindingFields = new List<MetaMetadataField>();

            foreach (MetaMetadataField thatChild in Kids.Values)
		    {
			    bool binded = thatChild.bindMetadataFieldDescriptor(metadataTScope, metadataClassDescriptor);

                if (binded)
                {
                    if (thatChild is MetaMetadataScalarField)
                    {
                        MetaMetadataScalarField scalar = (MetaMetadataScalarField)thatChild;
                        if (scalar.Filter != null)
                        {
                            MetadataFieldDescriptor fd = scalar.MetadataFieldDescriptor;
                            fd.RegexPattern = scalar.Filter.RegexPattern;
                            fd.RegexReplacement = scalar.Filter.Replace;
                        }
                    }

                    if (thatChild.hide)
                        nonDisplayedFieldNames.Add(thatChild.name);
                    if (thatChild.shadows != null)
                        nonDisplayedFieldNames.Add(thatChild.shadows);

                    // recursive descent
                    if (thatChild.HasChildren() && !thatChild.GetClassAndBindDescriptors(metadataTScope))
                        nonBindingFields.Add(thatChild);
                }
                else
                    nonBindingFields.Add(thatChild);

                _bindFieldDescriptorsFinished = true;
		    }

            foreach (MetaMetadataField field in nonBindingFields)
                Kids.Remove(field.Name);
        }

        public Boolean HasChildren()
        {
            return kids != null && kids.Count > 0;
        }

        protected virtual bool bindMetadataFieldDescriptor(TranslationScope metadataTScope, MetadataClassDescriptor metadataClassDescriptor)
        {
            String fieldName = this.GetFieldNameInCamelCase(false);// TODO -- is this the correct tag?
            MetadataFieldDescriptor = (MetadataFieldDescriptor)metadataClassDescriptor.getFieldDescriptorByFieldName(fieldName);

            if (MetadataFieldDescriptor != null)
            {
                return true;
            }
            else
            {
                if(!MetaMetadataRepository.stopTheConsoleDumping)
                    Console.WriteLine("Ignoring <" + fieldName + "> because no corresponding MetadataFieldDescriptor can be found.");
                return false;
            }

        }

        private String _fieldNameInJava = null;
        private String _capFieldNameInJava = null;

        private String getCapFieldNameInCamelCase()
        {
            String rst = _capFieldNameInJava;
            if (rst == null)
            {
                rst = XMLTools.CamelCaseFromXMLElementName(Name, true);
                _capFieldNameInJava = rst;
            }
            return _capFieldNameInJava;
        }

        protected String GetFieldNameInCamelCase(bool capitalized)
        {
            if (capitalized)
                return getCapFieldNameInCamelCase();

            String rst = _fieldNameInJava;
            if (rst == null)
            {
                rst = XMLTools.FieldNameFromElementName(this.Name);
                _fieldNameInJava = rst;
            }
            return _fieldNameInJava;
        }

        #endregion

        internal Type GetMetadataClass(TranslationScope metadataTScope)
        {
            Type result = metadataClass;

            if (result == null)
            {
                String tagForTS = GetTagForTranslationScope();
                result = metadataTScope.GetClassByTag(tagForTS);
                if (result == null)
                {
                    if (typeof(MetaMetadataCompositeField).IsAssignableFrom(this.GetType()))
                    {
                        MetaMetadataCompositeField mmCF = ((MetaMetadataCompositeField)this);
                        String tagToUse = mmCF.GetTypeOrName();
                        
                        result = metadataTScope.GetClassByTag(tagToUse);
                    }
                    if(result == null && ExtendsAttribute != null)
                        result = metadataTScope.GetClassByTag(ExtendsAttribute);
                }
                if (result != null)
                    metadataClass = result;
                else if (!MetaMetadataRepository.stopTheConsoleDumping)
                    Console.WriteLine("Can't resolve metadata for " + this.Name + " using " + tagForTS);
            }
            return result;
        }

        internal void InheritNonDefaultAttributes(MetaMetadataField inheritFrom)
        {
            ClassDescriptor classDescriptor = ClassDescriptor;

            foreach (FieldDescriptor fieldDescriptor in classDescriptor.AttributeFieldDescriptors)
            {
                ScalarType scalarType = fieldDescriptor.GetScalarType();
                try
                {
                    if (scalarType != null && scalarType.IsDefaultValue(fieldDescriptor.Field, this)
                            && !scalarType.IsDefaultValue(fieldDescriptor.Field, inheritFrom))
                    {
                        Object value = fieldDescriptor.Field.GetValue(inheritFrom);
                        fieldDescriptor.Field.SetValue(this, value);
                        //Console.WriteLine("inherit\t" + this.Name + "." + fieldDescriptor.FieldName + "\t= " + value);
                    }
                }
                catch (Exception e)
                {
                    // TODO Auto-generated catch block
                    Console.WriteLine("inherit\t" + this.Name + "." + fieldDescriptor.FieldName + " Failed, ignore it.\n" + e);
                }
            }

        }

        private String GetTagForTranslationScope()
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

		public String Tag
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

		public String ExtendsAttribute
		{
			get{return extendsAttribute;}
			set{extendsAttribute = value;}
		}

		public DictionaryList<String, MetaMetadataField> Kids
		{
			get{return kids;}
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

        public String Type
        {
            get { return null; }
        }

        public MetadataClassDescriptor MetadataClassDescriptor
        {
            get { return metadataClassDescriptor; }
        }

        #endregion
        public Object key()
		{
            return name;
		}

        public MetadataFieldDescriptor MetadataFieldDescriptor 
        {
            get { return metadataFieldDescriptor; } 
            set{ metadataFieldDescriptor = value; } 
        }

        public MetaMetadataField LookupChild(String name)
        {
            MetaMetadataField result = null;
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
            return nonDisplayedFieldNames == null ? true : !nonDisplayedFieldNames.Contains(childName);
        }
    }
}

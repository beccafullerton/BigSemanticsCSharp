//
//  MetaMetadataCompositeField.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ecologylab.Semantics.Actions;
using Ecologylab.Semantics.MetadataNS;
using Ecologylab.Semantics.Namesandnums;
using Simpl.Fundamental.Collections;
using Simpl.Fundamental.Generic;
using Simpl.Serialization.Attributes;
using Simpl.Serialization;

namespace Ecologylab.Semantics.MetaMetadataNS 
{
    [SimplInherit]
    [SimplTag("composite")]
    public class MetaMetadataCompositeField : MetaMetadataNestedField
    {
        #region Serializable Members

        [SimplScalar] private String type;

        [SimplScalar] private Boolean entity;

        [SimplScalar] private String userAgentName;

        [SimplScalar] private String userAgentString;

        [SimplScalar] private String parser;

        [SimplScalar] private Boolean wrap;

        [SimplCollection] [SimplScope("semantic_action_translation_scope")] private List<SemanticOperation> semanticActions;

        [SimplCollection("def_var")] [SimplNoWrap] private List<DefVar> defVars;

        [SimplScalar] private Boolean reloadPageFirstTime;

        [SimplTag("extends")] [SimplScalar] [MmDontInherit] private string extendsAttribute;

        #endregion

        #region Runtime Members

        private MMSelectorType mmSelectorType = MMSelectorType.DEFAULT;

        #endregion

        public MetaMetadataCompositeField()
        {
        }

        public MetaMetadataCompositeField(String name, DictionaryList<String, MetaMetadataField> kids)
        {
            this.Name = name;
            this.Kids = new DictionaryList<String, MetaMetadataField>();
            if (kids != null)
                this.Kids.PutAll(kids);
        }

        protected override string GetMetaMetadataTagToInheritFrom()
        {
            if (Entity)
                return DocumentParserTagNames.Entity;
            else if (type != null)
                return type;
            else
                return null;
        }

        protected override bool InheritMetaMetadataHelper(InheritanceHandler inheritanceHandler)
        {
            inheritanceHandler.Push(this);

            bool inhertedIsInheriting = false;
            // init
            MetaMetadataRepository repository = Repository;

            // determine the structure we should inherit from
            MetaMetadata inheritedMmd = FindOrGenerateInheritedMetaMetadata(repository, inheritanceHandler);
            if (inheritedMmd != null)
            {
                if (inheritedMmd.InheritInProcess)
                {
                    inhertedIsInheriting = true;

                    // if inheriting from the root mmd, we need to clone and keep the environment right now.
					InheritanceHandler inheritanceHandlerToUse = inheritanceHandler.clone();
					inheritanceHandler.Pop(this);

                    //inheritedMmd.InheritFinished += (sender, e) => InheritFromTopLevelMetaMetadata(inheritedMmd, repository);
                    this.AddInheritanceFinishHandler(inheritedMmd, InheritMetaMetadataFinished, inheritanceHandlerToUse);
                }
                else
                {
                    inheritedMmd.InheritMetaMetadata(null); //edit
                    InheritFromTopLevelMetaMetadata(inheritedMmd, repository, inheritanceHandler);
                }
            }
            if (!inhertedIsInheriting)
            {
                inhertedIsInheriting = InheritFromSuperField(repository, inheritanceHandler);
            }

            // for the root meta-metadata, this may happend
            if (inheritedMmd == null && SuperField == null)
                InheritFrom(repository, null, inheritanceHandler);

            return !inhertedIsInheriting;

        }

        private bool InheritFromSuperField(MetaMetadataRepository repository, InheritanceHandler inheritanceHandler)
        {
            bool inhertedIsInheriting = false;
            MetaMetadataCompositeField inheritedField = (MetaMetadataCompositeField)SuperField;
            if (inheritedField != null)
            {
                inheritedField.Repository = repository;
                if (inheritedField.InheritInProcess)
                {
                    inhertedIsInheriting = true;

                    // if inheriting from the root mmd, we need to clone and keep the environment right now.
                    InheritanceHandler inheritanceHandlerToUse = inheritanceHandler.clone();
                    inheritanceHandler.Pop(this);

                    //inheritedField.InheritFinished += (sender, e) => InheritFrom(repository, inheritedField);
                    this.AddInheritanceFinishHandler(inheritedField, InheritFieldFinished, inheritanceHandlerToUse);
                }
                else
                {
                    inheritedField.InheritMetaMetadata(inheritanceHandler);
                    InheritFromCompositeField(inheritedField, repository, inheritanceHandler);
                }
            }
            return inhertedIsInheriting;
        }

        private void InheritFieldFinished(MetaMetadataNestedField sender, EventArgs e)
        {
            MetaMetadataCompositeField inheritedField = (MetaMetadataCompositeField) _waitingToInheritFrom.Pop();
            //InheritFromCompositeField(inheritedField, Repository);

            if (_waitingToInheritFrom.Count == 0)
                FinishInheritance();
        }

        private void InheritMetaMetadataFinished(MetaMetadataNestedField sender, EventArgs e)
        {   
            MetaMetadata inheritedMmd = (MetaMetadata) _waitingToInheritFrom.Pop();
            InheritanceHandler inheritanceHandler = _waitingToInheritFromInheritanceHandler.Pop();
            
            InheritFromTopLevelMetaMetadata(inheritedMmd, Repository, inheritanceHandler);

            InheritFromSuperField(Repository, inheritanceHandler);

            if (_waitingToInheritFrom.Count == 0)
                FinishInheritance();
        }

        private void InheritFromCompositeField(MetaMetadataCompositeField inheritedField, MetaMetadataRepository repository, InheritanceHandler inheritanceHandler)
        {

            InheritFrom(repository, inheritedField, inheritanceHandler);
        }

        private void InheritFromTopLevelMetaMetadata(MetaMetadata inheritedMmd, MetaMetadataRepository repository, InheritanceHandler inheritanceHandler)
        {
            InheritNonFieldElements(inheritedMmd, inheritanceHandler);
            InheritFrom(repository, inheritedMmd, inheritanceHandler);
        }

        protected virtual void InheritFrom(MetaMetadataRepository repository,
                                                       MetaMetadataCompositeField inheritedStructure,
                                                       InheritanceHandler inheritanceHandler)
        {
            
            // init nested fields inside this
            var subfields = Kids.Values;
            foreach (MetaMetadataField f in subfields)
                if (f is MetaMetadataNestedField)
                {
                    f.Repository = (repository);
                    MetaMetadataNestedField nested = (MetaMetadataNestedField) f;
                    if (nested.PackageName == null)
                        nested.PackageName = PackageName;
                    nested.Scope = Scope;
                }

            // inherit fields with attributes from inheritedStructure
            // if inheritedStructure == null, this must be the root meta-metadata
            if (inheritedStructure != null)
            {
                var inheritedStructSubfields = inheritedStructure.Kids.Values;
                foreach (MetaMetadataField field in inheritedStructSubfields)
                {
                    if (field is MetaMetadataNestedField)
                    {
                        ((MetaMetadataNestedField)field).InheritMetaMetadata(inheritanceHandler);
                    }
                    string fieldName = field.Name;
                    MetaMetadataField fieldLocal;
                    kids.TryGetValue(fieldName, out fieldLocal);

                    if (fieldLocal == null && inheritanceHandler.IsUsingGenerics(field))
                    {
                        // if the super field is using generics, we will need to re-evaluate generic type vars
                        fieldLocal = (MetaMetadataField) Activator.CreateInstance(field.GetType());
                        
                        //Prepare Child Field For Inheritance
                        fieldLocal.Repository = (repository);
                        if (fieldLocal is MetaMetadataNestedField)
                        {
                            MetaMetadataNestedField nested = (MetaMetadataNestedField)fieldLocal;
                            if (nested.PackageName == null)
                                nested.PackageName = PackageName;
                            nested.Scope = Scope;
                        }
                    }
                    if (fieldLocal != null)
                    {
                        Debug.WriteLine("inheriting field: " + fieldLocal + " <= " + field);
                        if (field.GetType() != fieldLocal.GetType())
                            Debug.WriteLine("local field " + fieldLocal + " hides field " + fieldLocal +
                                            " with the same name in super mmd type!");
                        // debug("inheriting field " + fieldLocal + " from " + field);
                        if (field != fieldLocal)
                            fieldLocal.SuperField = field;
                        fieldLocal.DeclaringMmd = field.DeclaringMmd;
                        fieldLocal.InheritAttributes(field);
                        if (fieldLocal is MetaMetadataNestedField)
                            ((MetaMetadataNestedField)fieldLocal).PackageName =
                                ((MetaMetadataNestedField)field).PackageName;
                    }
                }
            }

            // recursively call inheritMetaMetadata() on nested fields
            foreach (MetaMetadataField f in subfields)
            {
                // a new field is defined inside this mmd
                if (f.DeclaringMmd == this && f.SuperField == null)
                    SetNewMetadataClass(true);

                // recursively call this method on nested fields
                f.Repository = repository;
                if (f is MetaMetadataNestedField)
                {
                    MetaMetadataNestedField f1 = (MetaMetadataNestedField) f;
                    f1.InheritMetaMetadata(inheritanceHandler);
                    if (f1.IsNewMetadataClass())
                        SetNewMetadataClass(true);

                    MetaMetadataNestedField f0 = (MetaMetadataNestedField) f.SuperField;
                    if (f0 != null && f0.GetTypeName() != f1.GetTypeName())
                    {
                        // inherited field w changing base type (polymorphic case)
                        f1.InheritMetaMetadata(inheritanceHandler);
                        MetaMetadata mmd0 = f0.TypeMmd;
                        MetaMetadata mmd1 = f1.TypeMmd;
                        if (mmd1.IsDerivedFrom(mmd0))
                            SetNewMetadataClass(true);
                        else
                            throw new MetaMetadataException("incompatible types: " + mmd0 + " => " + mmd1);
                    }
                }
            }

            // clone fields only declared in inheritedStructure.
            // must clone them after recursively calling inheritMetaMetadata(), so that their nested
            // structures (which may be inherited too) can be cloned.
            if (inheritedStructure != null)
            {
                var inheritedStructSubfields = inheritedStructure.Kids.Values;
                foreach (MetaMetadataField field in inheritedStructSubfields)
                {
                    string fieldName = field.Name;
                    MetaMetadataField fieldLocal;
                    kids.TryGetValue(fieldName, out fieldLocal);

                    if (fieldLocal == null)
                    {
                        //					MetaMetadataField clonedField = (MetaMetadataField) field.clone();
                        //					clonedField.setParent(this);
                        //					this.getChildMetaMetadata().put(fieldName, clonedField);
                        kids.Put(fieldName, field);
                    }
                }
            }

            
        }

        protected virtual void InheritNonFieldElements(MetaMetadata inheritedMmd, InheritanceHandler inheritanceHandler)
        {
            Scope = new MmdScope(Scope, inheritedMmd.Scope);
        }

        protected virtual MetaMetadata FindOrGenerateInheritedMetaMetadata(MetaMetadataRepository repository, InheritanceHandler inheritanceHandler)
        {
            MetaMetadata inheritedMmd = this.TypeMmd;
            if (inheritedMmd == null)
            {
                MmdScope mmdScope = this.Scope;
                String inheritedMmdName = Type ?? Name;

                if (ExtendsAttribute != null)
                {
                    // determine new type name
                    if (inheritedMmdName == null)
                        throw new MetaMetadataException("attribute 'name' must be specified: " + this);
                    if (inheritanceHandler.ResolveMmdName(inheritedMmdName) != null)
                        // currently we don't encourage re-using existing name. however, in the future, when package names are available, we can change this.
                        throw new MetaMetadataException("meta-metadata '" + inheritedMmdName + "' already exists! please use another name to prevent name collision. hint: use 'tag' to change the tag if needed.");

                    // determine from which meta-metadata to inherit
                    inheritedMmd = inheritanceHandler.ResolveMmdName(ExtendsAttribute);
                    if (ExtendsAttribute == null || inheritedMmd == null)
                        throw new MetaMetadataException("super type not specified or recognized: " + this + ", super type name: " + ExtendsAttribute);
                    
                    // generate inline mmds and put it into current scope
                    MetaMetadata generatedMmd = this.GenerateMetaMetadata(inheritedMmdName, inheritedMmd);
                    mmdScope.Put(inheritedMmdName, generatedMmd);
                    mmdScope.Put(generatedMmd.Name, generatedMmd);

                    // recursively do inheritance on generated mmd
                    generatedMmd.InheritMetaMetadata(null); // this will set generateClassDescriptor to true if necessary

                    MakeThisFieldUseMmd(inheritedMmdName, generatedMmd);
                    return generatedMmd;
                }
                else
                {
                    // use type / extends
                    if (inheritedMmdName == null)
                        throw new MetaMetadataException("no type / extends defined for " + this
                            + " (note that due to a limitation explicit child_scalar_type is needed for scalar collection fields, even if it has been declared in super field).");

                    NameType[] nameType = new NameType[1];
                    inheritedMmd = inheritanceHandler.ResolveMmdName(inheritedMmdName, nameType);

                    if (inheritedMmd == null)
                        throw new MetaMetadataException("meta-metadata not found: " + inheritedMmdName + " (if you want to define new types inline, you need to specify extends/child_extends).");

                    if (!inheritedMmdName.Equals(inheritedMmd.Name) && nameType[0] == NameType.MMD)
                    {
                        // could be inline mmd
                        this.MakeThisFieldUseMmd(inheritedMmdName, inheritedMmd);
                    }

                    // process normal mmd / field
                    Debug.WriteLine("setting " + this + ".inheritedMmd to " + inheritedMmd);
                    TypeMmd = inheritedMmd;
                }
            }
            return inheritedMmd;
        }

        protected void MakeThisFieldUseMmd(String previousName, MetaMetadata mmd)
        {
            // must set this before generatedMmd.inheritMetaMetadata() to meet inheritMetaMetadata() prerequisites
            TypeMmd = mmd;
            // make this field as if is using generatedMmd as type
            Type = mmd.Name;
            ExtendsAttribute = null;
            if (Tag == null)
                Tag = previousName; // but keep the tag name
        }


        protected MetaMetadata GenerateMetaMetadata(String previousName, MetaMetadata inheritedMmd)
        {
            String generatedName = getGeneratedMmdName2(previousName);

            // generate the mmd and set attributes
            MetaMetadata generatedMmd = new MetaMetadata
                                            {
                                                Name = generatedName,
                                                PackageName = PackageName,
                                                Type = null,
                                                TypeMmd = inheritedMmd,
                                                ExtendsAttribute = inheritedMmd.Name,
                                                Repository = Repository,
                                                Visibility = Visibility.PACKAGE,
                                                Scope =
                                                    new MmdScope(this.Scope,
                                                                                         inheritedMmd.Scope)
                                            };
            if (SchemaOrgItemtype != null)
                generatedMmd.SchemaOrgItemtype = SchemaOrgItemtype;
            generatedMmd.SetNewMetadataClass(true);

            // move nested fields (they will be cloned later)
            if (kids != null && kids.Count > 0)
            {
                foreach (String kidKey in this.kids.Keys)
                {
                    MetaMetadataField kid;
                    kids.TryGetValue(kidKey, out kid);
                    generatedMmd.Kids.Put(kidKey, kid);
                    kid.Parent = generatedMmd;
                }
                kids.Clear();
            }
            MakeThisFieldUseMmd(previousName, generatedMmd);
            return generatedMmd;
        }

        private String getGeneratedMmdName2(String previousName)
        {
            return previousName;
        }

        #region Properties

        public String Type
        {
            get { return type; }
            set
            {
                type = value;
                if (TypeChangeListener != null)
                    TypeChangeListener(value);
            }
        }

        public override String GetMmdType()
        {
            return type;
        }

        public delegate void TypeChanged(String newType);

        public delegate void ExtendsChanged(String newExtends);

        public delegate void TagChanged(String newTag);

        public TypeChanged TypeChangeListener { get; set; }

        public ExtendsChanged ExtendsChangeListener { get; set; }

        public TagChanged TagChangeListener { get; set; }

        public Boolean Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public String UserAgentName
        {
            get { return userAgentName; }
            set { userAgentName = value; }
        }

        public String UserAgentString
        {
            get
            {
                if (userAgentString == null)
                {
                    userAgentString = UserAgentName == null ? Repository.DefaultUserAgentString : Repository.UserAgents[UserAgentName].UserAgentString;
                }
                return userAgentString;
            }
            set { userAgentString = value; }
        }

        public String Parser
        {
            get { return parser; }
            set { parser = value; }
        }

        public List<SemanticOperation> SemanticActions
        {
            get { return semanticActions; }
            set { semanticActions = value; }
        }

        public List<DefVar> DefVars
        {
            get { return defVars; }
            set { defVars = value; }
        }

        public Boolean ReloadPageFirstTime
        {
            get { return reloadPageFirstTime; }
            set { reloadPageFirstTime = value; }
        }

        public string ExtendsAttribute
        {
            get { return extendsAttribute; }
            set
            {
                extendsAttribute = value;
                if (ExtendsChangeListener != null)
                    ExtendsChangeListener(value);
            }
        }

        public override string GetMmdExtendsAttribute()
        {
            return ExtendsAttribute;
        }

        public override string Tag
        {
            get { return base.Tag; }
            set
            {
                base.Tag = value;
                if (TagChangeListener != null) TagChangeListener(value);
            }
        }

        public MMSelectorType MMSelectorType
        {
            get { return mmSelectorType; }
            internal set { mmSelectorType = value; }
        }

        public bool IsGenericMetadata
        {
            get { return MMSelectorType == MMSelectorType.SUFFIX_OR_MIME || IsBuiltIn; }
        }

        public virtual bool IsBuiltIn
        {
            get { return false; }
        }

        #endregion

        public String GetTypeOrName()
        {
            return Type ?? Name;
        }

        public override MetaMetadataCompositeField GetMetaMetadataCompositeField()
        {
            return this;
        }
    }
}

//
//  MetaMetadataCollectionField.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Simpl.Fundamental.Generic;
using Simpl.Serialization.Attributes;
using Simpl.Serialization.Types;
using ecologylab.semantics.metadata;

using Simpl.Serialization;
using ecologylab.semantics.metadata.scalar.types;

namespace ecologylab.semantics.metametadata
{
  /// <summary>
  /// missing java doc comments or could not find the source file.
  /// </summary>
  [SimplInherit]
  [SimplTag("collection")]
  [SimplDescriptorClasses(new[] { typeof(MetaMetadataClassDescriptor), typeof(MetaMetadataFieldDescriptor) })]
  public class MetaMetadataCollectionField : MetaMetadataNestedField
  {
    public static readonly String UNRESOLVED_NAME = "&UNRESOLVED_NAME";
    /// <summary>
    /// missing java doc comments or could not find the source file.
    /// </summary>
    [SimplScalar]
    private String childTag;

    /// <summary>
    /// missing java doc comments or could not find the source file.
    /// </summary>
    [SimplScalar]
    private String childType;

    /// <summary>
    /// missing java doc comments or could not find the source file.
    /// </summary>
    [SimplScalar]
    private Boolean childEntity;

    [SimplScalar]
    [MmDontInherit]
    private String childExtends;


    private MetadataScalarType childScalarType;

    /// <summary>
    /// missing java doc comments or could not find the source file.
    /// </summary>
    [SimplScalar]
    private Boolean noWrap;

    [SimplScalar]
    private Boolean parseAsHypertext;

    public MetaMetadataCollectionField()
    { }

    protected override string GetMetaMetadataTagToInheritFrom()
    {
      if (childEntity)
        return DocumentParserTagNames.ENTITY;
      else if (childType != null)
        return childType;
      else
        return null;
    }

    protected override void InheritMetaMetadataHelper()
    {
      /*
   * the childComposite should hide all complexity between collection fields and composite fields,
   * through hooks when necessary.
   */
      int typeCode = this.GetFieldType();
      switch (typeCode)
      {
        case FieldTypes.CollectionElement:
          {
            // prepare childComposite: possibly new name, type, extends, tag and inheritedField
            MetaMetadataCompositeField childComposite = this.GetChildComposite();
            if (childComposite.Name == UNRESOLVED_NAME)
              childComposite.Name = (childType ?? Name);
            childComposite.Type = childType; // here not using setter to reduce unnecessary re-assignment of this.childType
            childComposite.ExtendsAttribute = ChildExtends;
            childComposite.Tag = childTag;
            childComposite.Repository = Repository;
            childComposite.PackageName = PackageName;

            if (InheritedField != null)
              childComposite.InheritedField = (InheritedField as MetaMetadataCollectionField).GetChildComposite();
            childComposite.DeclaringMmd = DeclaringMmd;
            childComposite.MmdScope = MmdScope;

            childComposite.InheritMetaMetadata(); // inheritedMmd might be inferred from type/extends

            InheritedMmd = childComposite.InheritedMmd;
            MmdScope = childComposite.MmdScope;
            break;
          }
        case FieldTypes.CollectionScalar:
          {
            MetaMetadataField inheritedField = InheritedField;
            if (inheritedField != null)
              InheritAttributes(inheritedField);
            break;
          }
      }
    }



    public String ChildTag
    {
      get { return childTag; }
      set { childTag = value; }
    }

    public String ChildType
    {
      get { return childType; }
      set { childType = value; }
    }

    public Boolean ChildEntity
    {
      get { return childEntity; }
      set { childEntity = value; }
    }

    public Boolean NoWrap
    {
      get { return noWrap; }
      set { noWrap = value; }
    }

    public Boolean ParseAsHypertext
    {
      get { return parseAsHypertext; }
      set { parseAsHypertext = value; }
    }

    public string ChildExtends
    {
      get { return childExtends; }
      set { childExtends = value; }
    }

    public MetadataScalarType ChildScalarType
    {
      get { return childScalarType; }
      set { childScalarType = value; }
    }

    public override MetaMetadataCompositeField GetMetaMetadataCompositeField()
    {
      return GetChildComposite();
    }

    public MetaMetadataCompositeField GetChildComposite()
    {
      return (kids != null && kids.Count > 0) ? (MetaMetadataCompositeField)kids.ElementAt(0) : null;
    }

    public String DetermineCollectionChildType()
    {
      return (!childEntity) ? childType : DocumentParserTagNames.ENTITY;
    }

    public void DeserializationPostHook(object o, FieldDescriptor fd)
    {
      int typeCode = this.GetFieldType();
      if (typeCode == FieldTypes.CollectionScalar)
        return;

      String childCompositeName = ChildType ?? UNRESOLVED_NAME;
      MetaMetadataCollectionField thisField = this;
      var composite = new MetaMetadataCompositeField(childCompositeName, kids);
      composite.TypeChangeListener += (newType) => this.childType = newType;
      composite.ExtendsChangeListener += (newExtends) => this.childExtends = newExtends;
      composite.TagChangeListener += (newTag) => this.childTag = newTag;
      composite.Parent = this;
      composite.Type = childType;
      composite.ExtendsAttribute = this.childExtends;
      kids.Clear();
      kids.Add(composite.Name, composite);
      composite.PromoteChildren = this.PromoteChildren;
    }

    public override string GetTypeName()
    {
      throw new NotImplementedException();
    }

    internal override bool GetClassAndBindDescriptors(SimplTypesScope metadataTScope)
    {
      return GetChildComposite().GetClassAndBindDescriptors(metadataTScope);
    }
  }

  internal class MetaMetadataClassDescriptor : ClassDescriptor
  {
    public MetaMetadataClassDescriptor(Type thatClass)
      : base(thatClass)
    {

    }

    public MetaMetadataClassDescriptor(string tagName, string comment, string describedClassPackageName, string describedClassSimpleName, ClassDescriptor superClass, List<string> interfaces)
      : base(tagName, comment, describedClassPackageName, describedClassSimpleName, superClass, interfaces)
    {
    }
  }

  internal class MetaMetadataFieldDescriptor : FieldDescriptor
  {

    public bool IsInheritable { get; set; }
    /**
   * Should this field be inherited in meta-metadata
   */

    public MetaMetadataFieldDescriptor(ClassDescriptor declaringClassDescriptor, FieldInfo field, int annotationType) // String nameSpacePrefix
      : base(declaringClassDescriptor, field, annotationType)
    {
      if (field != null)
      {
        IsInheritable = !field.IsDefined(typeof(MmDontInherit), false); //isAnnotationPresent(mm_dont_inherit.class);
      }
      else
      {
        IsInheritable = true;
      }
    }

    public MetaMetadataFieldDescriptor(ClassDescriptor baseClassDescriptor, FieldDescriptor wrappedFD, String wrapperTag)
      : base(baseClassDescriptor, wrappedFD, wrapperTag)
    {
      IsInheritable = true;
    }


  }
}

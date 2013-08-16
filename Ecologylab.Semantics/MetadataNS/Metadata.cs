//
//  Metadata.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/02/10.
//  Copyright 2010 Interface Ecology Lab. 
//


using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecologylab.Semantics.MetadataNS.Builtins.Declarations;
using Ecologylab.Semantics.MetaMetadataNS;
using Ecologylab.Semantics.MetadataNS;
using Ecologylab.Semantics.Model.Text;
using Simpl.Fundamental.Net;
using Simpl.Serialization.Attributes;
using Simpl.Serialization;
using Ecologylab.Semantics.MetadataNS.Scalar;


namespace Ecologylab.Semantics.MetadataNS
{
	[SimplInherit]
	public class Metadata : MetadataDeclaration, IMetadata
    {

        private MetaMetadataCompositeField _metaMetadata;
        /**
	    * Hidden reference to the MetaMetadataRepository. DO NOT access this field directly. DO NOT
	    * create a static public accessor. -- andruid 10/7/09.
	    */
        private static MetaMetadataRepository _repository;

        private MetadataClassDescriptor _classDescriptor;

		public Metadata()
		{ }

        public Metadata(MetaMetadataCompositeField metaMetadata) : this()
        {
            if (metaMetadata != null)
            {
                this._metaMetadata = metaMetadata;
                string metaMetadataName = metaMetadata.Name;
                if (MetadataClassDescriptor.TagName != metaMetadataName)
                    this.MetaMetadataName = new MetadataString(metaMetadataName);
            }
        }

        public MetaMetadataCompositeField MetaMetadata
        {
            get { return _metaMetadata ?? GetMetaMetadata(); }
            set { _metaMetadata = value; }
        }

        public virtual MetadataParsedURL Location
        {
            get { return null; }
        }

	    public virtual bool IsImage
	    {
	        get { return false; }
	    }

	    private MetaMetadataCompositeField GetMetaMetadata()
        {
            MetaMetadataCompositeField mm = _metaMetadata;

            //mm = await MetaMetadataTranslationScope.Get().Deserialize()
            if (_repository == null)
                _repository = MetaMetadataRepositoryInit.getRepository();

            if (mm == null && _repository != null)
            {
                if ( this.MetaMetadataName != null) // get from saved composition
                    mm = _repository.GetMMByName(this.MetaMetadataName.Value);

                if (mm == null)
                {
                    ParsedUri location = Location == null ? null : Location.Value;
                    if (location != null)
                    {
                        mm = IsImage ? _repository.GetImageMM(location) : _repository.GetDocumentMM(location);

                        // TODO -- also try to resolve by mime type ???
                    }
                    if (mm == null)
                        mm = _repository.GetByClass(this.GetType());
                    if (mm == null && MetadataClassDescriptor != null)
                    {
                        mm = _repository.GetMMByName(MetadataClassDescriptor.TagName);
                    }
                }

                if (mm != null)
                    MetaMetadata = mm;
            }
            return mm;
        }

        public MetaMetadataOneLevelNestingEnumerator MetaMetadataIterator(MetaMetadataField metaMetadataField = null)
        {
            MetaMetadataField firstMetaMetadataField = metaMetadataField ?? this.MetaMetadata;
            return new MetaMetadataOneLevelNestingEnumerator(firstMetaMetadataField, this);
        }

        public void AddMixin(Metadata mixin)
        {
            if (Mixins == null)
            {
                Mixins = new List<Metadata>();
            }
            Mixins.Add(mixin);
        }

        public MetadataClassDescriptor MetadataClassDescriptor
	    {
            get
            {
                MetadataClassDescriptor result = this._classDescriptor;
                if (result == null)
                {
                    result = (MetadataClassDescriptor) ClassDescriptor.GetClassDescriptor(this);
                    this._classDescriptor = result;
                }
                return result;
            }
	    }

        public int NumberOfVisibleFields(bool considerAlwaysShow = true)
	    {
		    int size = 0;

		    MetaMetadataOneLevelNestingEnumerator fullEnumerator = FullNonRecursiveMetaMetadataIterator();
		    // iterate over all fields in this & then in each mixin of this
		    while (fullEnumerator.MoveNext())
		    {
			    MetaMetadataField metaMetadataField = fullEnumerator.Current;
			    MetaMetadataField metaMetadata = fullEnumerator.CurrentObject(); // stays the same for until we
																																			    // iterate over all mfd's for
																																			    // it
			    Metadata currentMetadata = fullEnumerator.CurrentMetadata;

			    // When the iterator enters the metadata in the mixins "this" in getValueString has to be
			    // the corresponding metadata in mixin.
			    bool hasVisibleNonNullField = false;
			    MetadataFieldDescriptor mfd = metaMetadataField.MetadataFieldDescriptor;

			    if (metaMetadata.IsChildFieldDisplayed(metaMetadataField.Name))
			    {
				    if (mfd.IsScalar && !mfd.IsCollection)
					    hasVisibleNonNullField = MetadataString.IsNotNullAndEmptyValue(mfd.GetValueString(currentMetadata));
				    else if (mfd.IsComposite)
				    {
					    Metadata nestedMetadata = (Metadata) mfd.GetNestedMetadata(currentMetadata);
					    hasVisibleNonNullField = (nestedMetadata != null) ? (nestedMetadata.NumberOfVisibleFields() > 0) : false;
				    }
				    else if (mfd.IsCollection)
				    {
					    ICollection collection = mfd.GetCollection(currentMetadata);
					    hasVisibleNonNullField = (collection != null) ? (collection.Count > 0) : false;
				    }
			    }

			    // "null" happens with mixins fieldAccessor b'coz getValueString() returns "null".

			    // TODO use MetaMetadataField.numNonDisplayedFields()
			    bool isVisibleField = !metaMetadataField.Hide
					    && ((considerAlwaysShow && metaMetadataField.AlwaysShow) || hasVisibleNonNullField);

			    if (isVisibleField)
				    size++;
		    }

		    return size;
	    }

        public MetaMetadataOneLevelNestingEnumerator FullNonRecursiveMetaMetadataIterator(MetaMetadataField metaMetadataField = null)
	    {
		    MetaMetadataField firstMetaMetadataField = metaMetadataField ?? MetaMetadata;
		    return new MetaMetadataOneLevelNestingEnumerator(firstMetaMetadataField, this);
	    }

	    #region Implementation of IEnumerable

	    public IEnumerator<FieldDescriptor> GetEnumerator()
	    {
	        return MetadataClassDescriptor.GetEnumerator();
	    }

	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return GetEnumerator();
	    }

	    #endregion

	    #region Implementation of IMetadata

	    public ITermVector TermVector
	    {
	        get { throw new NotImplementedException(); }
	        set { throw new NotImplementedException(); }
	    }

	    public ITermVector GetTermVector(HashSet<Metadata> visitedMetadata)
	    {
	        throw new NotImplementedException();
	    }

	    public void Recycle()
	    {
	        throw new NotImplementedException();
	    }

	    public void RebuildCompositeTermVector()
	    {
	        throw new NotImplementedException();
	    }

	    public bool IgnoreInTermVector
	    {
	        get { throw new NotImplementedException(); }
	        set { throw new NotImplementedException(); }
	    }

	    #endregion
    }
}

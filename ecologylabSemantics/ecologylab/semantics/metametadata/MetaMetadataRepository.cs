//
//  MetaMetadataRepository.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Simpl.Fundamental.Collections;
using Simpl.Fundamental.Generic;
using Simpl.Fundamental.Net;
using Simpl.Serialization.Attributes;
using Simpl.Serialization;
using ecologylab.net;
using ecologylab.semantics.connectors;
using ecologylab.semantics.metadata.scalar.types;
using ecologylab.textformat;
using System.Text.RegularExpressions;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metadata.builtins;
using System.IO;

namespace ecologylab.semantics.metametadata 
{
	/// <summary>
	/// missing java doc comments or could not find the source file.
	/// </summary>
	public class MetaMetadataRepository : ElementState
    {
	    public static bool stopTheConsoleDumping = false;

        #region Locals
        private static String FIREFOX_3_6_4_AGENT_STRING			= "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.4) Gecko/20100513 Firefox/3.6.4";
	    private readonly Dictionary<String, MetaMetadata>    
            _repositoryByClassName;

	    /**
	     * Repository with noAnchorNoQuery URL string as key.
	     */
	    private readonly Dictionary<String, MetaMetadata>    
            _documentRepositoryByUrlStripped;

	    /**
	     * Repository with domain as key.
	     */
	    private readonly Dictionary<String, MetaMetadata>    
            _documentRepositoryByDomain;

	    /**
	     * Repository for ClippableDocument and its subclasses.
	     */
	    private readonly Dictionary<String, MetaMetadata>    
            _clippableDocumentRepositoryByUrlStripped;

	    private readonly Dictionary<String, List<RepositoryPatternEntry>>	
            _documentRepositoryByPattern;

	    private readonly Dictionary<String, List<RepositoryPatternEntry>>	
            _clippableDocumentRepositoryByPattern;

        /// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String name;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplTag("package")]
		[SimplScalar]
		private String packageName;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplMap("user_agent")]
		private Dictionary<String, UserAgent> userAgents;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplMap("search_engine")]
		private Dictionary<String, SearchEngine> searchEngines;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplMap("named_style")]
		private Dictionary<String, NamedStyle> namedStyles;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplScalar]
		private String defaultUserAgentName;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplNoWrap]
		[SimplCollection("cookie_processing")]
		private List<CookieProcessing> cookieProcessors;

		/// <summary>
		/// The map from meta-metadata name (currently simple name, but might be extended to fully
	    /// qualified name in the future) to meta-metadata objects. This collection is filled during the
	    /// loading process.
		/// </summary>
		[SimplMap("meta_metadata")]
		[SimplNoWrap]
		private Dictionary<String, MetaMetadata> _repositoryByName;

        private Dictionary<String, MetaMetadata> _repositoryByMime = new Dictionary<string,MetaMetadata>();

        private Dictionary<String, MetaMetadata> _repositoryBySuffix = new Dictionary<string,MetaMetadata>();

        private Dictionary<string, MultiAncestorScope<MetaMetadata>> packageMmdScopes;
		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplMap("selector")]
		[SimplNoWrap]
		private Dictionary<String, MetaMetadataSelector> selectorsByName;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[SimplMap("site")]
		private Dictionary<String, SemanticsSite> sites;

	    private String defaultUserAgentString = null;


        public SimplTypesScope MetadataTScope { get; set; }

        public string File { get; set; }

        private static bool initializedTypes;


	    #endregion
        
        public MetaMetadataRepository()
        {
            _clippableDocumentRepositoryByPattern       = new Dictionary<String, List<RepositoryPatternEntry>>();
            _documentRepositoryByPattern                = new Dictionary<String, List<RepositoryPatternEntry>>();
            _clippableDocumentRepositoryByUrlStripped   = new Dictionary<String, MetaMetadata>();
            _documentRepositoryByDomain                 = new Dictionary<String, MetaMetadata>();
            _documentRepositoryByUrlStripped            = new Dictionary<String, MetaMetadata>();
            _repositoryByClassName                      = new Dictionary<String, MetaMetadata>();
        }

        /// <summary>
        /// 
	    /// Recursively bind MetadataFieldDescriptors to all MetaMetadataFields. Perform other
	    /// initialization.
        /// </summary>
        /// <param name="metadataTScope"></param>
	    public void BindMetadataClassDescriptorsToMetaMetadata(SimplTypesScope metadataTScope)
	    {
		    this.MetadataTScope = metadataTScope;

            TraverseAndInheritMetaMetadata();

            // global metadata classes
		    // use another copy because we may modify the scope during the process
		    List<MetaMetadata> mmds = new   List<MetaMetadata>(_repositoryByName.Values);
		    foreach (MetaMetadata mmd in  mmds)
		    {
			    MetadataClassDescriptor mcd = mmd.BindMetadataClassDescriptor(metadataTScope);
			    if (mcd == null)
			    {
				    Debug.WriteLine("Cannot bind metadata class descriptor for " + mmd);
				    this.RepositoryByName.Remove(mmd.Name);
			    }
		    }
		
		    // other initialization stuffs
		    foreach (MetaMetadata mmd in RepositoryByName.Values)
		    {
			    MetadataClassDescriptor mcd = mmd.MetadataClassDescriptor;
			    if (mcd != null)
				    RepositoryByClassName.Put(mcd.DescribedClass.Name, mmd);
			
			    //mmd.setUpLinkWith(this); //Note Implement linking.
		    }

		    InitializeLocationBasedMaps();
	    }


	    private void TraverseAndInheritMetaMetadata()
	    {
	        if (_repositoryByName != null && _repositoryByName.Count > 0)
		    {
			    // make another copy because we may modify the collection (e.g. for adding inline definitions)
			    foreach (MetaMetadata metaMetadata in _repositoryByName.Values)
			    {
				    metaMetadata.Repository = this;
				    metaMetadata.InheritMetaMetadata();
			    }
		    }
	    }

	    public static void InitializeTypes()
        {
            if(!initializedTypes)
            {
                initializedTypes = true;
                MetadataScalarType.init();
                MetadataBuiltinsTranslationScope.Get();
            }
        }

        private void InitializeDefaultUserAgent()
        {
 	        if (defaultUserAgentString == null)
		    {
			    this.defaultUserAgentString = FIREFOX_3_6_4_AGENT_STRING;
		    }
        }

        /**
	     * Initializes HashMaps for MetaMetadata selectors by URL or pattern. Uses the ClippableDocument and Document
	     * base classes to ensure that maps are only filled with appropriate matching MetaMetadata.
	     */
	    public void InitializeLocationBasedMaps()
	    {
		    foreach (MetaMetadata metaMetadata in _repositoryByName.Values)
		    {
			    // metaMetadata.inheritMetaMetadata(this);

			    Type metadataClass = metaMetadata.GetMetadataClass(MetadataTScope);
			    if (metadataClass == null)
			    {
                    Console.WriteLine("No metadata class found for metaMetadata: " + metaMetadata.Name);
				    continue;
			    }

			    Dictionary<String, MetaMetadata> repositoryByUrlStripped;
			    Dictionary<String, List<RepositoryPatternEntry>> repositoryByPattern;

			    if (typeof(ClippableDocument).IsAssignableFrom(metadataClass))
			    {
				    repositoryByUrlStripped = _clippableDocumentRepositoryByUrlStripped;
				    repositoryByPattern = _clippableDocumentRepositoryByPattern;
			    }
			    else if (typeof(Document).IsAssignableFrom(metadataClass))
			    {
				    repositoryByUrlStripped = _documentRepositoryByUrlStripped;
				    repositoryByPattern = _documentRepositoryByPattern;
			    }
			    else
				    continue;

			    // We need to check if something is there already
			    // if something is there, then we need to check to see if it has its cf pref set
			    // if not, then if I am null then I win

                MetaMetadataSelector selector = metaMetadata.Selectors[0];//Note: Needs to consider all selectors. 
                ParsedUri purl = selector.UrlStripped;
			    if (purl != null)
			    {
                    MetaMetadata inMap;
                    repositoryByUrlStripped.TryGetValue(purl.Stripped, out inMap);
                    if (inMap == null)
                        repositoryByUrlStripped.Add(purl.Stripped, metaMetadata);
                    else
                        Console.WriteLine("MetaMetadata already exists in repositoryByUrlStripped for purl\n\t: " 
                            + purl + " :: " + inMap.Name + " Ignoring MMD: " + metaMetadata.Name);
                        
			    }
			    else
			    {
					// use .pattern() for comparison
                    String domain = selector.Domain ?? (selector.UrlPathTree != null ? selector.UrlPathTree.Domain : null);
					if (domain != null)
					{
                        Regex urlPattern = selector.UrlRegex;

                        if (urlPattern == null)
                            urlPattern = new Regex(selector.UrlPathTree.ToString().Replace("*", "[^/]+"));

						if (urlPattern != null)
						{
							List<RepositoryPatternEntry> bucket;
                            repositoryByPattern.TryGetValue(domain, out bucket);
							if (bucket == null)
							{
								bucket = new List<RepositoryPatternEntry>(2);
								repositoryByPattern.Add(domain, bucket);
							}
                            bucket.Add(new RepositoryPatternEntry(urlPattern, metaMetadata));
						}
					    else
					    {
						    // domain only -- no pattern
						    _documentRepositoryByDomain.Add(domain, metaMetadata);
					    }
					}
			    }
		    }
	    }


        /// <summary>
        /// This initalizes the map based on mime type and suffix.
        /// </summary>
        public void InitializeSuffixAndMimeDicts()
        {
            if (_repositoryByName == null)
			    return;

		    foreach (MetaMetadata metaMetadata in _repositoryByName.Values)
		    {
		        if (metaMetadata.Selectors == null || metaMetadata.Selectors.Count <= 0) continue;

		        MetaMetadataSelector selector = metaMetadata.Selectors[0];//Note: Needs to consider all selectors. 
		        List<String> suffixes = selector.Suffixes;
		        if (suffixes != null)
		        {
		            foreach (String suffix in suffixes)
		            {
		                // FIXME-- Ask whether the suffix and mime should be
		                // inherited or not
		                if (!_repositoryBySuffix.ContainsKey(suffix))
		                    _repositoryBySuffix.Add(suffix, metaMetadata);
		            }
		        }

		        List<String> mimeTypes = selector.MimeTypes;
		        if (mimeTypes != null)
		        {
		            foreach (String mimeType in mimeTypes)
		            {
		                // FIXME -- Ask whether the suffix and mime should be
		                // inherited or not
		                if (!_repositoryByMime.ContainsKey(mimeType))
		                    _repositoryByMime.Add(mimeType, metaMetadata);
		            }
		        }
		    }
        }

	    /// <summary>
	    /// Integrate the contents of otherRepository with this one.
	    /// </summary>
	    /// <param name="repository"></param>
	    public void IntegrateRepository(MetaMetadataRepository repository)
        {
            // combine userAgents
            if (!MergeDictionaries(repository.userAgents, this.userAgents))
                this.userAgents = repository.userAgents;

            // combine searchEngines
            if (!MergeDictionaries(repository.searchEngines, this.searchEngines))
                this.searchEngines = repository.searchEngines;

            // combine namedStyles
            if (!MergeDictionaries(repository.namedStyles, this.namedStyles))
                this.namedStyles = repository.namedStyles;

            // combine sites
            if (!MergeDictionaries(repository.sites, this.sites))
                this.sites = repository.sites;

            if (!MergeDictionaries(repository._repositoryByMime, this._repositoryByMime))
                this._repositoryByMime = repository._repositoryByMime;

            if (!MergeDictionaries(repository._repositoryBySuffix, this._repositoryBySuffix))
                this._repositoryBySuffix = repository._repositoryBySuffix;

            Dictionary<String, MetaMetadata> otherRepositoryByTagName = repository._repositoryByName;
            //set metaMetadata to have the correct parent repository in ElementState
            if (otherRepositoryByTagName != null)
            {
                foreach (MetaMetadata mmd in otherRepositoryByTagName.Values)
                {
                    mmd.Parent = this; 
                    if (mmd.PackageName == null)
                        mmd.PackageName = repository.packageName;
                }

                if (!MergeDictionaries(otherRepositoryByTagName, this._repositoryByName))
                    this._repositoryByName = otherRepositoryByTagName;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcDict"></param>
        /// <param name="destDict"></param>
        /// <returns></returns>
        public bool MergeDictionaries<String, T>(Dictionary<String, T> srcDict, Dictionary<String, T> destDict)
            where T :ElementState {
            if (destDict == null)
                return false;

            if (srcDict != null)
                foreach (KeyValuePair<String, T> entry in srcDict)
                {
                    if (destDict.ContainsKey(entry.Key))
                        destDict.Remove(entry.Key); //By Default the new value will override the old one.
                    destDict.Add(entry.Key, entry.Value);
                }

            return true;
        }

        /// <summary>
        ///  Get MetaMetadata. First, try matching by url_base. If this fails, including if the attribute is
	    ///  null, then try by url_prefix. If this fails, including if the attribute is null, then try by
	    ///  url_pattern (regular expression).
	    ///  <p/>
	    /// If that lookup fails, then lookup by tag name, to acquire the default.
	    /// </summary>
        /// <param name="uri"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public MetaMetadata GetDocumentMM(ParsedUri uri, String tagName = DocumentParserTagNames.DOCUMENT_TAG)
	    {
		    MetaMetadata result = null;
		    if (uri != null)
		    {
			    if (!uri.IsFile)
			    {
                    
				    String noAnchorNoQueryPageString = uri.GetLeftPart(UriPartial.Path);

                    _documentRepositoryByUrlStripped.TryGetValue(noAnchorNoQueryPageString, out result);

				    if (result == null)
				    {
                        //Check to see if the url prefix is actually a url-path tree.
                        //TODO: For url-path-tree cases, we should just generate a regex to handle those cases.

				    }

				    if (result == null)
				    {
                        String domain = uri.Domain; 
					    if (domain != null)
					    {
                            List<RepositoryPatternEntry> entries = null;
                            _documentRepositoryByPattern.TryGetValue(domain, out entries);

						    if (entries != null)
						    {
							    foreach (RepositoryPatternEntry entry in entries)
							    {
								    Match matcher = entry.Pattern.Match(uri.ToString());
								    if (matcher.Success)
								    {
									    result = entry.MetaMetadata;
                                        break;
								    }
							    }
						    }
					    }
				    }
			    }
			    // be careful of the order! suffix before domain

			    if (result == null)
			    {
				    String suffix = uri.Suffix;

				    if (suffix != null)
					    result = GetMMBySuffix(suffix);
			    }
			    if (result == null)
			    {
				    String domain = uri.Domain;
				    _documentRepositoryByDomain.TryGetValue(domain, out result);

				    if (result != null)
					    Console.WriteLine("Matched by domain = " + domain + "\t" + result);
			    }

		    }
		    //if (result == null)
			 //   result = getByTagName(tagName);

		    return result;
	    }

        private MetaMetadata GetMMBySuffix(string suffix)
        {
            MetaMetadata result = null;
            _repositoryBySuffix.TryGetValue(suffix, out result);
            return result;
            
        }
        
        public MetaMetadata GetMMByName(String tagName)
        {
            if (tagName == null)
                return null;
            MetaMetadata result = null;
            _repositoryByName.TryGetValue(tagName, out result);
            return result;
        }
        
        public MetaMetadata GetByClass(Type metadataClass)
	    {
		    if (metadataClass == null)
			    return null;

            MetaMetadata result = null;
		    // String tag = metadataTScope.getTag(metadataClass);
		    RepositoryByClassName.TryGetValue(metadataClass.Name, out result);
            return result;
	    }

        #region Properties

        public String Name
		{
			get{return name;}
			set{name = value;}
		}

		public String PackageName
		{
			get{return packageName;}
			set{packageName = value;}
		}

		public Dictionary<String, UserAgent> UserAgents
		{
			get
            {
                if(userAgents == null)
                    userAgents = new Dictionary<String, UserAgent>();
                return userAgents;
            }
			set{userAgents = value;}
		}

		public Dictionary<String, SearchEngine> SearchEngines
		{
			get{return searchEngines;}
			set{searchEngines = value;}
		}

		public Dictionary<String, NamedStyle> NamedStyles
		{
			get{return namedStyles;}
			set{namedStyles = value;}
		}

		public String DefaultUserAgentName
		{
			get{return defaultUserAgentName;}
			set{defaultUserAgentName = value;}
		}

		public List<CookieProcessing> CookieProcessors
		{
			get{return cookieProcessors;}
			set{cookieProcessors = value;}
		}

		public Dictionary<String, MetaMetadata> RepositoryByName
		{
			get{return _repositoryByName;}
			set{_repositoryByName = value;}
		}

		public Dictionary<String, MetaMetadataSelector> SelectorsByName
		{
			get{return selectorsByName;}
			set{selectorsByName = value;}
		}

		public Dictionary<String, SemanticsSite> Sites
		{
			get{return sites;}
			set{sites = value;}
        }

	    public Dictionary<string, MultiAncestorScope<MetaMetadata>> PackageMmdScopes
	    {
	        get { return packageMmdScopes; }
	        set { packageMmdScopes = value; }
	    }

	    public Dictionary<string, MetaMetadata> RepositoryByClassName
	    {
	        get { return _repositoryByClassName; }
	    }

	    #endregion
    }
}

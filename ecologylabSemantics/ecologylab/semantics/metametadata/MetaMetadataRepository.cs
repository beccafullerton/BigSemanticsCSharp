//
//  MetaMetadataRepository.cs
//  s.im.pl serialization
//
//  Generated by DotNetTranslator on 11/16/10.
//  Copyright 2010 Interface Ecology Lab. 
//

using System;
using System.Collections.Generic;
using ecologylab.attributes;
using ecologylab.serialization;
using ecologylab.net;
using ecologylab.semantics.connectors;
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
	    private Dictionary<String, MetaMetadata>    
            repositoryByClassName                       = new Dictionary<String, MetaMetadata>();

	    /**
	     * Repository with noAnchorNoQuery URL string as key.
	     */
	    private Dictionary<String, MetaMetadata>    
            documentRepositoryByUrlStripped	            = new Dictionary<String, MetaMetadata>();

	    /**
	     * Repository with domain as key.
	     */
	    private Dictionary<String, MetaMetadata>    
            documentRepositoryByDomain		            = new Dictionary<String, MetaMetadata>();

	    /**
	     * Repository for ClippableDocument and its subclasses.
	     */
	    private Dictionary<String, MetaMetadata>    
            clippableDocumentRepositoryByUrlStripped    = new Dictionary<String, MetaMetadata>();

	    private Dictionary<String, List<RepositoryPatternEntry>>	
            documentRepositoryByPattern			        = new Dictionary<String, List<RepositoryPatternEntry>>();

	    private Dictionary<String, List<RepositoryPatternEntry>>	
            clippableDocumentRepositoryByPattern	    = new Dictionary<String, List<RepositoryPatternEntry>>();

        /// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String name;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[xml_tag("package")]
		[simpl_scalar]
		private String packageAttribute;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_map("user_agent")]
		private Dictionary<String, UserAgent> userAgents;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_map("search_engine")]
		private Dictionary<String, SearchEngine> searchEngines;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_map("named_style")]
		private Dictionary<String, NamedStyle> namedStyles;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_scalar]
		private String defaultUserAgentName;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_nowrap]
		[simpl_collection("cookie_processing")]
		private List<CookieProcessing> cookieProcessors;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_map("meta_metadata")]
		[simpl_nowrap]
		private Dictionary<String, MetaMetadata> repositoryByTagName;

        private Dictionary<String, MetaMetadata> repositoryByMime = new Dictionary<string,MetaMetadata>();

        private Dictionary<String, MetaMetadata> repositoryBySuffix = new Dictionary<string,MetaMetadata>();

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_map("selector")]
		[simpl_nowrap]
		private Dictionary<String, MetaMetadataSelector> selectorsByName;

		/// <summary>
		/// missing java doc comments or could not find the source file.
		/// </summary>
		[simpl_map("site")]
		private Dictionary<String, SemanticsSite> sites;

        private TranslationScope metadataTScope;

        private String defaultUserAgentString = null;

        String file;
        #endregion
        
        public MetaMetadataRepository()
		{ 

        }

        public static MetaMetadataRepository ReadDirectoryRecursively(String path, TranslationScope mmdTScope, TranslationScope metadataTScope)
        {
            MetaMetadataRepository repo = new MetaMetadataRepository();
            
            Stack<string> stack = new Stack<string>();
            stack.Push(path);
            while(stack.Count > 0)
            {
                string dir = stack.Pop();
                Console.WriteLine("Looking in : "  + dir);
                String[] files = Directory.GetFiles(dir, "*.xml");
                foreach (String file in files)
                {
                    MetaMetadataRepository thatRepo = ReadRepository(file, mmdTScope, metadataTScope);
                    repo.IntegrateRepository(thatRepo);
                }
                foreach (String innerDir in Directory.GetDirectories(dir))
                    if(!innerDir.Contains(".svn"))
                        stack.Push(innerDir);
            }

            repo.BindMetadataClassDescriptorsToMetaMetadata(metadataTScope);

            return repo;
        }

        public static MetaMetadataRepository ReadRepository(String filename, TranslationScope mmdTScope, TranslationScope metadataTScope)
        {
            MetaMetadataRepository repo = null;
            //Console.WriteLine("MetaMetadataRepository Reading: " + filename);

            try
            {
                repo = (MetaMetadataRepository)mmdTScope.deserialize(filename);
                repo.metadataTScope = metadataTScope;
                repo.file = filename;
                repo.InitializeSuffixAndMimeDicts();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't translate repository file: " + filename);
                Console.WriteLine(e);
            }

            return repo;
        }



        /**
	     * Recursively bind MetadataFieldDescriptors to all MetaMetadataFields. Perform other
	     * initialization.
	     * 
	     * @param metadataTScope
	     */
	    public void BindMetadataClassDescriptorsToMetaMetadata(TranslationScope metadataTScope)
	    {
		    this.metadataTScope = metadataTScope;
		    InitializeDefaultUserAgent();

		    // findAndDeclareNestedMetaMetadata(metadataTScope);
            List<MetaMetadata> nonBindingMetaMetadata = new List<MetaMetadata>();

		    foreach (MetaMetadata metaMetadata in repositoryByTagName.Values)
		    {
			    metaMetadata.InheritMetaMetadata(this);
			    bool binded = metaMetadata.GetClassAndBindDescriptors(metadataTScope);
			    MetadataClassDescriptor metadataClassDescriptor = metaMetadata.MetadataClassDescriptor;
                if (metaMetadata.Type == null && metadataClassDescriptor != null 
                    && repositoryByClassName.ContainsKey(metadataClassDescriptor.DescribedClass.Name)) // don't put restatements of the same base type into
																					    // *this* map
				    repositoryByClassName.Add(metadataClassDescriptor.DescribedClass.Name, metaMetadata);
		    }

            foreach (MetaMetadata metaMetadata in nonBindingMetaMetadata)
            {
                repositoryByTagName.Remove(metaMetadata.Name);
            }

		    InitializeLocationBasedMaps();
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
		    foreach (MetaMetadata metaMetadata in repositoryByTagName.Values)
		    {
			    // metaMetadata.inheritMetaMetadata(this);

			    Type metadataClass = metaMetadata.GetMetadataClass(metadataTScope);
			    if (metadataClass == null)
			    {
                    Console.WriteLine("No metadata class found for metaMetadata: " + metaMetadata.Name);
				    continue;
			    }

			    Dictionary<String, MetaMetadata> repositoryByUrlStripped;
			    Dictionary<String, List<RepositoryPatternEntry>> repositoryByPattern;

			    if (typeof(ClippableDocument).IsAssignableFrom(metadataClass))
			    {
				    repositoryByUrlStripped = clippableDocumentRepositoryByUrlStripped;
				    repositoryByPattern = clippableDocumentRepositoryByPattern;
			    }
			    else if (typeof(Document).IsAssignableFrom(metadataClass))
			    {
				    repositoryByUrlStripped = documentRepositoryByUrlStripped;
				    repositoryByPattern = documentRepositoryByPattern;
			    }
			    else
				    continue;

			    // We need to check if something is there already
			    // if something is there, then we need to check to see if it has its cf pref set
			    // if not, then if I am null then I win

			    MetaMetadataSelector selector = metaMetadata.Selector;
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
						    documentRepositoryByDomain.Add(domain, metaMetadata);
					    }
					}
			    }
		    }
	    }


        /// <summary>
        /// This initalizes the map based on mime type and suffix.
        /// </summary>
        private void InitializeSuffixAndMimeDicts()
        {
            if (repositoryByTagName == null)
			    return;

		    foreach (MetaMetadata metaMetadata in repositoryByTagName.Values)
		    {
                MetaMetadataSelector selector = metaMetadata.Selector;
			    List<String> suffixes = selector.Suffixes;
			    if (suffixes != null)
			    {
				    foreach (String suffix in suffixes)
				    {
					    // FIXME-- Ask whether the suffix and mime should be
					    // inherited or not
					    if (!repositoryBySuffix.ContainsKey(suffix))
						    repositoryBySuffix.Add(suffix, metaMetadata);
				    }
			    }

                List<String> mimeTypes = selector.MimeTypes;
			    if (mimeTypes != null)
			    {
				    foreach (String mimeType in mimeTypes)
				    {
					    // FIXME -- Ask whether the suffix and mime should be
					    // inherited or not
					    if (!repositoryByMime.ContainsKey(mimeType))
						    repositoryByMime.Add(mimeType, metaMetadata);
				    }
			    }

		    }
        }

        /// <summary>
        /// Integrate the contents of otherRepository with this one.
        /// </summary>
        /// <param name="otherRepository"></param>
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


            if (!MergeDictionaries(repository.repositoryByMime, this.repositoryByMime))
                this.repositoryByMime = repository.repositoryByMime;

            if (!MergeDictionaries(repository.repositoryBySuffix, this.repositoryBySuffix))
                this.repositoryBySuffix = repository.repositoryBySuffix;

            Dictionary<String, MetaMetadata> otherRepositoryByTagName = repository.repositoryByTagName;
            //set metaMetadata to have the correct parent repository in ElementState
            if (otherRepositoryByTagName != null)
            {
                foreach (MetaMetadata mmd in otherRepositoryByTagName.Values)
                {
                    mmd.Parent = this;
                    if (mmd.PackageAttribute == null)
                        mmd.PackageAttribute = repository.packageAttribute;
                }
            }

            if (!MergeDictionaries(otherRepositoryByTagName, this.repositoryByTagName))
                this.repositoryByTagName = otherRepositoryByTagName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcDict"></param>
        /// <param name="destDict"></param>
        /// <returns></returns>
        public bool MergeDictionaries<String, T>(Dictionary<String, T> srcDict, Dictionary<String, T> destDict)
            where T : ElementState
        {
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

                    documentRepositoryByUrlStripped.TryGetValue(noAnchorNoQueryPageString, out result);

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
                            documentRepositoryByPattern.TryGetValue(domain, out entries);

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
				    documentRepositoryByDomain.TryGetValue(domain, out result);

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
            repositoryBySuffix.TryGetValue(suffix, out result);
            return result;
            
        }
        
        public MetaMetadata GetByTagName(String tagName)
        {
            if (tagName == null)
                return null;
            MetaMetadata result = null;
            repositoryByTagName.TryGetValue(tagName, out result);
            return result;
        }
        
        public MetaMetadata GetByClass(Type metadataClass)
	    {
		    if (metadataClass == null)
			    return null;

            MetaMetadata result = null;
		    // String tag = metadataTScope.getTag(metadataClass);
		    repositoryByClassName.TryGetValue(metadataClass.Name, out result);
            return result;
	    }

        #region Properties

        public String Name
		{
			get{return name;}
			set{name = value;}
		}

		public String PackageAttribute
		{
			get{return packageAttribute;}
			set{packageAttribute = value;}
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

		public Dictionary<String, MetaMetadata> RepositoryByTagName
		{
			get{return repositoryByTagName;}
			set{repositoryByTagName = value;}
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
        #endregion
    }
}

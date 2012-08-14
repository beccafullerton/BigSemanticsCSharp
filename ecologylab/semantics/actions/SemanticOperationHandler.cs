﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simpl.Serialization;
using ecologylab.collections;
using ecologylab.semantics.collecting;
using ecologylab.semantics.documentparsers;
using ecologylab.semantics.metadata;
using ecologylab.semantics.metametadata;
using ecologylabSemantics.ecologylab.semantics.actions;
using ecologylab.semantics.actions.exceptions;

namespace ecologylab.semantics.actions
{
    /**
     * This is the handler for semantic operations. * It has a <code>handleSemanticOperation</code> method
     * which decides what operation to take when a semantic operation is passed to it. There is one
     * SemanticOperationHandler created for each DocumentParser.connect()
     * 
     * @author amathur
     */
    // TODO Might want to implement lexical scoping in variables.
    public class SemanticOperationHandler : SemanticOperationStandardMethods
    {

	    static readonly Scope<Object> BUILT_IN_SCOPE = new Scope<Object>();

	    static SemanticOperationHandler()
	    {
		    BUILT_IN_SCOPE.Add(FALSE, false);
		    BUILT_IN_SCOPE.Add(TRUE, true);
		    BUILT_IN_SCOPE.Add(NULL, null);
	    }

	    private SemanticsGlobalScope semanticsScope;

	    private DocumentParser documentParser;

	    /**
	     * This is a map of return value and objects from semantic operation. The key being the return_value
	     * of the semantic operation. TODO remane this also to some thing like objectMap or variableMap.
	     */
	    private Scope<Object> semanticOperationVariableMap;

	    private Dictionary<SemanticOperation, Dictionary<String, Object>> operationStates	= new Dictionary<SemanticOperation, Dictionary<string, object>>();

	    /**
	     * Error handler for the semantic operations.
	     */
	    private SemanticOperationErrorHandler errorHandler;

	    bool requestWaiting	= false;

	    MetaMetadata metaMetadata;

	    Metadata metadata;

	    public SemanticOperationHandler(SemanticsGlobalScope semanticsScope, DocumentParser documentParser)
            : this(semanticsScope, documentParser, new Scope<Object>(BUILT_IN_SCOPE))
	    {
	    }

	    public SemanticOperationHandler(SemanticsGlobalScope semanticsScope, DocumentParser documentParser, 
			    Scope<Object> semanticOperationVariableMap)
	    {
		    this.semanticsScope 			= semanticsScope;
		    this.documentParser 			= documentParser;
//		    semanticOperationVariableMap.Add(
//				    SemanticOperationKeyWords.PURLCONNECTION_MIME,
//				    documentParser.purlConnection().mimeType());
		    this.semanticOperationVariableMap	= semanticOperationVariableMap;
	    }

        public Scope<Object> SemanticOperationVariableMap
	    {
		    get { return semanticOperationVariableMap; }
	    }

        public SemanticsGlobalScope SemanticsScope
        {
            get { return semanticsScope; }
        }

        public void TakeSemanticOperations()
	    {
		    if (metaMetadata != null && metadata != null)
			    TakeSemanticOperations(metaMetadata, metadata);
	    }

        public void TakeSemanticOperations(Metadata metadata)
	    {
            TakeSemanticOperations((MetaMetadata)metadata.MetaMetadata, metadata);
	    }
        public void TakeSemanticOperations(MetaMetadata metaMetadata, Metadata metadata)
	    {
            TakeSemanticOperations(metaMetadata, metadata, metaMetadata.SemanticActions);
	    }
        public void TakeSemanticOperations(MetaMetadata metaMetadata, Metadata metadata, List<SemanticOperation> semanticActions)
	    {
		    if (semanticActions == null)
		    {
			    Console.WriteLine("warning: no semantic actions exist");
			    return;
		    }
		
		    if (requestWaiting)
		    {
			    requestWaiting = false;
		    }
		    else
		    {
			    this.metaMetadata = metaMetadata;
			    this.metadata = metadata;

                //FIXME -- should not have SemanticOperationsKeyWords && SemanticOperationsNamedArguments as separate sets !!!
			    semanticOperationVariableMap.Put(DOCUMENT_TYPE, documentParser);
			    semanticOperationVariableMap.Put(SemanticOperationKeyWords.METADATA, metadata);
//edit			    semanticOperationVariableMap.Add(TRUE_PURL, documentParser.getTruePURL());

                PreSemanticOperationsHook(metadata);
		    }
		    for (int i = 0; i < semanticActions.Count; i++)
		    {
			    SemanticOperation action = semanticActions[i];
                HandleSemanticOperation(action, documentParser, semanticsScope);
			    if (requestWaiting)
				    return;
		    }
            PostSemanticOperationsHook(metadata);

		    Recycle();
	    }

	    /**
	     * main entry to handle semantic operations. FOR loops and IFs are handled directly (they have built-
	     * in semantics and are not overridable). otherwise it will can the perform() method on the operation
	     * object.
	     * 
	     * @param action
	     * @param parser
	     * @param infoCollector
	     */
        public void HandleSemanticOperation(SemanticOperation operation, DocumentParser parser, SemanticsGlobalScope infoCollector)
	    {
		    int state = GetOperationState(operation, "state", SemanticOperation.INIT);
		    if (state == SemanticOperation.FIN || requestWaiting)
			    return;
    //		debug("["+parser+"] semantic operation: " + action.getActionName() + ", SA class: " + action.getClassSimpleName() + "\n");

            operation.SemanticOperationHandler = this;
		
		    // here state must be INTER or INIT

		    // if state == INIT, we check pre-conditions
		    // if state == INTER, because this must have been started, we skip checking pre-conditions
		    if (state == SemanticOperation.INIT)
		    {
			    if (!CheckConditionsIfAny(operation))
			    {
				    if (!(operation is IfSemanticOperation))
					    Console.WriteLine("Semantic operation {0} not taken since (some) pre-requisite conditions are not met",operation);
				    return;
			    }
		    }
		    else
		    {
			    Console.WriteLine("re-entering operations with pre-conditions; checking pre-conditions skipped: " + operation.GetOperationName());
		    }

		    operation.SessionScope = infoCollector;
            operation.SemanticOperationHandler = this;
		    operation.DocumentParser = parser;

		    String operationName = operation.GetOperationName();

		    try
		    {
			    if (SemanticOperationStandardMethods.FOR_EACH.Equals(operationName))
			    {
				    HandleForLoop((ForEachSemanticOperation) operation, parser, infoCollector);
			    }
			    else if (SemanticOperationStandardMethods.IF.Equals(operationName))
			    {
				    HandleIf((IfSemanticOperation) operation, parser, infoCollector);
			    }
			    else
			    {
				    HandleGeneralOperation(operation);
			    }
		    }
		    catch (Exception e)
		    {
			    Console.WriteLine("The action " + operationName
					    + " could not be executed. Please see the stack trace for errors.");
		    }
		    finally
		    {
			    if (!requestWaiting)
				    SetOperationState(operation, "state", SemanticOperation.FIN);
		    }
	    }

	    ///<summary>
	    ///handle semantic actions other than FOR and IF.
	    ///</summary>
	    public void HandleGeneralOperation(SemanticOperation operation)
	    {
		    // get the object on which the action has to be taken
		    String objectName = operation.ObjectStr;
		    if (objectName == null)
			    objectName = SemanticOperationKeyWords.METADATA;
		    Object obj = semanticOperationVariableMap.Get(objectName);

		    try
		    {
			    Object returnValue = null;
			    returnValue = operation.Perform(obj);
			    if (requestWaiting)
				    return;
			    if (operation.Name != null && returnValue != null)
			    {
				    semanticOperationVariableMap.Put(operation.Name, returnValue);
			    }
		    }
		    catch (Exception e)
		    {
			    if (e is SemanticOperationExecutionException)
				    throw e;
			    throw new SemanticOperationExecutionException(e, operation, semanticOperationVariableMap);
		    }
	    }

        public void HandleForLoop(ForEachSemanticOperation operation, DocumentParser parser,
			    SemanticsGlobalScope infoCollector)
	    {
		    try
		    {
			    // get all the action which have to be performed in loop
			    List<SemanticOperation> nestedSemanticActions = operation.NestedSemanticActionList;

			    // get the collection object name on which we have to loop
			    String collectionObjectName = operation.Collection;
			    // if(checkPreConditionFlagsIfAny(action))
		        {
		            Object collectionObject = semanticOperationVariableMap.Get(collectionObjectName);

                    if (collectionObject == null)
				    {
					    Console.WriteLine("Can't execute loop because collection is null: " + SimplTypesScope.Serialize(operation, StringFormat.Xml));
					    return;
				    }

                    // get the objects from the collection object
/*                    List<Object> collection = new List<Object>();
                    foreach (Object value in (IEnumerable)collectionObject)
                    {
                        collection.Add(value);
                    }
*/
                    int collectionSize = ((IList) collectionObject).Count;

				    // set the size of collection in the for loop action.
				    if (operation.Size != null)
				    {
					    // we have the size value. so we add it in parameters
					    semanticOperationVariableMap.Put(operation.Size, collectionSize);
				    }

				    int start = 0;
				    int end = collectionSize;

				    if (operation.Start != null)
				    {
					    start = Int32.Parse(operation.Start);
				    }
				    if (operation.End != null)
				    {
					    end = Int32.Parse(operation.End);
				    }

				    if (GetOperationState(operation, "state", SemanticOperation.INIT) == SemanticOperation.INTER)
				    {
					    start = GetOperationState(operation, "current_index", 0);
				    }

				    SetOperationState(operation, "state", SemanticOperation.INTER);

				    // start the loop over each object
				    for (int i = start; i < end; i++)
				    {
					    SetOperationState(operation, "current_index", i);
                        Object item = ((IList) collectionObject)[i];
					    // put it in semantic action return value map
                        semanticOperationVariableMap.Put(operation.AsStr, item);

					    // see if current index is needed
                        if (operation.CurrentIndex != null)
					    {
						    // set the value of this variable in parameters
                            semanticOperationVariableMap.Put(operation.CurrentIndex, i);
					    }

					    // now take all the actions nested inside for loop
					    foreach (SemanticOperation nestedSemanticAction in nestedSemanticActions)
					    {
                            HandleSemanticOperation(nestedSemanticAction, parser, infoCollector);
					    }

					    if (requestWaiting)
						    break;

					    // at the end of each iteration clear flags so that we can do the next iteration
                        operation.SetNestedOperationState("state", SemanticOperation.INIT);
				    }
			    }
		    }
		    catch (Exception e)
		    {
			    Console.WriteLine(System.Environment.StackTrace);
			    throw new ForLoopException(e, operation, semanticOperationVariableMap);
		    }
	    }

        public void HandleIf(IfSemanticOperation operation, DocumentParser parser, SemanticsGlobalScope infoCollector)
	    {
		    // conditions have been checked in handleSemanticAction()

		    try
		    {
			    SetOperationState(operation, "state", SemanticOperation.INTER);
			    List<SemanticOperation> nestedSemanticActions = operation.NestedSemanticActionList;
			    foreach (SemanticOperation nestedSemanticAction in nestedSemanticActions)
                    HandleSemanticOperation(nestedSemanticAction, parser, infoCollector);
		    }
		    catch (Exception e)
		    {
                throw new IfOperationException(e, operation, semanticOperationVariableMap);
		    }
	    }

	    ///<summary>
	    /// This function checks for the pre-condition flag values for this action and returns the "anded"
	    /// result.
	    /// 
	    /// @param action
	    /// @return true if conditions are satisfied; false otherwise.
	    ///</summary>
	    public bool CheckConditionsIfAny(SemanticOperation operation)
	    {
		    List<Condition> conditions = operation.Checks;

		    if (conditions != null)
		    {
			    // loop over all the flags to be checked
			    foreach (Condition condition in conditions)
			    {
				    bool flag = condition.Evaluate(this);
				    if (!flag)
					    return false;
			    }
		    }
		    return true;
	    }

	    /*********************** hooks ************************/

        public void PreSemanticOperationsHook(Metadata metadata)
	    {

	    }

        public void PostSemanticOperationsHook(Metadata metadata)
	    {

	    }

	    /*********************** used by the library ************************/

	    public void Recycle()
	    {
		    semanticOperationVariableMap.Clear();
		    semanticOperationVariableMap = null;
	    }

        public T GetOperationState<T>(SemanticOperation operation, String name, T defaultValue)
	    {
		    if (operationStates.ContainsKey(operation))
		    {
			    Dictionary<String, Object> states = operationStates[operation];
		        Object state; 
                states.TryGetValue(name, out state);
                if (state != null)
				    return (T) state;
		    }
		    return defaultValue;
	    }

        public void SetOperationState<T>(SemanticOperation action, String name, T value)
	    {
		    if (!operationStates.ContainsKey(action))
			    operationStates.Add(action, new Dictionary<string, object>());
		    Dictionary<String, Object> states = operationStates[action];
            if (states.ContainsKey(name))
                states.Remove(name);
		    states.Add(name, value);
	    }

    }
}
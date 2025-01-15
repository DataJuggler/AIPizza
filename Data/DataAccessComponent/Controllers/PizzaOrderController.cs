

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class PizzaOrderController
    /// <summary>
    /// This class controls a(n) 'PizzaOrder' object.
    /// </summary>
    public class PizzaOrderController
    {

        #region Methods

            #region CreatePizzaOrderParameter
            /// <summary>
            /// This method creates the parameter for a 'PizzaOrder' data operation.
            /// </summary>
            /// <param name='pizzaorder'>The 'PizzaOrder' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreatePizzaOrderParameter(PizzaOrder pizzaOrder)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = pizzaOrder;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(PizzaOrder tempPizzaOrder, DataManager dataManager)
            /// <summary>
            /// Deletes a 'PizzaOrder' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'PizzaOrder_Delete'.
            /// </summary>
            /// <param name='pizzaorder'>The 'PizzaOrder' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(PizzaOrder tempPizzaOrder, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeletePizzaOrder";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify temppizzaOrder exists before attemptintg to delete
                    if (tempPizzaOrder != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deletePizzaOrderMethod = PizzaOrderMethods.DeletePizzaOrder;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreatePizzaOrderParameter(tempPizzaOrder);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deletePizzaOrderMethod, parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(PizzaOrder tempPizzaOrder, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'PizzaOrder' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'PizzaOrder_FetchAll'.</summary>
            /// <param name='tempPizzaOrder'>A temporary PizzaOrder for passing values.</param>
            /// <returns>A collection of 'PizzaOrder' objects.</returns>
            public static List<PizzaOrder> FetchAll(PizzaOrder tempPizzaOrder, DataManager dataManager)
            {
                // Initial value
                List<PizzaOrder> pizzaOrderList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = PizzaOrderMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreatePizzaOrderParameter(tempPizzaOrder);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<PizzaOrder> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        pizzaOrderList = (List<PizzaOrder>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return pizzaOrderList;
            }
            #endregion

            #region Find(PizzaOrder tempPizzaOrder, DataManager dataManager)
            /// <summary>
            /// Finds a 'PizzaOrder' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'PizzaOrder_Find'</param>
            /// </summary>
            /// <param name='tempPizzaOrder'>A temporary PizzaOrder for passing values.</param>
            /// <returns>A 'PizzaOrder' object if found else a null 'PizzaOrder'.</returns>
            public static PizzaOrder Find(PizzaOrder tempPizzaOrder, DataManager dataManager)
            {
                // Initial values
                PizzaOrder pizzaOrder = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempPizzaOrder != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = PizzaOrderMethods.FindPizzaOrder;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreatePizzaOrderParameter(tempPizzaOrder);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as PizzaOrder != null))
                        {
                            // Get ReturnObject
                            pizzaOrder = (PizzaOrder) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return pizzaOrder;
            }
            #endregion

            #region Insert(PizzaOrder pizzaOrder, DataManager dataManager)
            /// <summary>
            /// Insert a 'PizzaOrder' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'PizzaOrder_Insert'.</param>
            /// </summary>
            /// <param name='pizzaOrder'>The 'PizzaOrder' object to insert.</param>
            /// <returns>The id (int) of the new  'PizzaOrder' object that was inserted.</returns>
            public static int Insert(PizzaOrder pizzaOrder, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If PizzaOrderexists
                    if (pizzaOrder != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = PizzaOrderMethods.InsertPizzaOrder;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreatePizzaOrderParameter(pizzaOrder);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref PizzaOrder pizzaOrder, DataManager dataManager)
            /// <summary>
            /// Saves a 'PizzaOrder' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='pizzaOrder'>The 'PizzaOrder' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref PizzaOrder pizzaOrder, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the pizzaOrder exists.
                if (pizzaOrder != null)
                {
                    // Is this a new PizzaOrder
                    if (pizzaOrder.IsNew)
                    {
                        // Insert new PizzaOrder
                        int newIdentity = Insert(pizzaOrder, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            pizzaOrder.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update PizzaOrder
                        saved = Update(pizzaOrder, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(PizzaOrder pizzaOrder, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'PizzaOrder' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'PizzaOrder_Update'.</param>
            /// </summary>
            /// <param name='pizzaOrder'>The 'PizzaOrder' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(PizzaOrder pizzaOrder, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (pizzaOrder != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = PizzaOrderMethods.UpdatePizzaOrder;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreatePizzaOrderParameter(pizzaOrder);
                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

    }
    #endregion

}

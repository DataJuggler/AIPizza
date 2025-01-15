

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

    #region class CustomerController
    /// <summary>
    /// This class controls a(n) 'Customer' object.
    /// </summary>
    public class CustomerController
    {

        #region Methods

            #region CreateCustomerParameter
            /// <summary>
            /// This method creates the parameter for a 'Customer' data operation.
            /// </summary>
            /// <param name='customer'>The 'Customer' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateCustomerParameter(Customer customer)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = customer;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Customer tempCustomer, DataManager dataManager)
            /// <summary>
            /// Deletes a 'Customer' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'Customer_Delete'.
            /// </summary>
            /// <param name='customer'>The 'Customer' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(Customer tempCustomer, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteCustomer";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempcustomer exists before attemptintg to delete
                    if (tempCustomer != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteCustomerMethod = CustomerMethods.DeleteCustomer;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCustomerParameter(tempCustomer);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteCustomerMethod, parameters, dataManager);

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

            #region FetchAll(Customer tempCustomer, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'Customer' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Customer_FetchAll'.</summary>
            /// <param name='tempCustomer'>A temporary Customer for passing values.</param>
            /// <returns>A collection of 'Customer' objects.</returns>
            public static List<Customer> FetchAll(Customer tempCustomer, DataManager dataManager)
            {
                // Initial value
                List<Customer> customerList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = CustomerMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateCustomerParameter(tempCustomer);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Customer> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        customerList = (List<Customer>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return customerList;
            }
            #endregion

            #region Find(Customer tempCustomer, DataManager dataManager)
            /// <summary>
            /// Finds a 'Customer' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Customer_Find'</param>
            /// </summary>
            /// <param name='tempCustomer'>A temporary Customer for passing values.</param>
            /// <returns>A 'Customer' object if found else a null 'Customer'.</returns>
            public static Customer Find(Customer tempCustomer, DataManager dataManager)
            {
                // Initial values
                Customer customer = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempCustomer != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = CustomerMethods.FindCustomer;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCustomerParameter(tempCustomer);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Customer != null))
                        {
                            // Get ReturnObject
                            customer = (Customer) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return customer;
            }
            #endregion

            #region Insert(Customer customer, DataManager dataManager)
            /// <summary>
            /// Insert a 'Customer' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Customer_Insert'.</param>
            /// </summary>
            /// <param name='customer'>The 'Customer' object to insert.</param>
            /// <returns>The id (int) of the new  'Customer' object that was inserted.</returns>
            public static int Insert(Customer customer, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Customerexists
                    if (customer != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = CustomerMethods.InsertCustomer;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCustomerParameter(customer);

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

            #region Save(ref Customer customer, DataManager dataManager)
            /// <summary>
            /// Saves a 'Customer' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='customer'>The 'Customer' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref Customer customer, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the customer exists.
                if (customer != null)
                {
                    // Is this a new Customer
                    if (customer.IsNew)
                    {
                        // Insert new Customer
                        int newIdentity = Insert(customer, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            customer.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Customer
                        saved = Update(customer, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Customer customer, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'Customer' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Customer_Update'.</param>
            /// </summary>
            /// <param name='customer'>The 'Customer' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(Customer customer, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (customer != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = CustomerMethods.UpdateCustomer;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCustomerParameter(customer);
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

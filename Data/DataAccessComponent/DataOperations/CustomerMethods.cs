

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.DataBridge;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class CustomerMethods
    /// <summary>
    /// This class contains methods for modifying a 'Customer' object.
    /// </summary>
    public static class CustomerMethods
    {

        #region Methods

            #region DeleteCustomer(Customer)
            /// <summary>
            /// This method deletes a 'Customer' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Customer' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteCustomer(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteCustomerStoredProcedure deleteCustomerProc = null;

                    // verify the first parameters is a(n) 'Customer'.
                    if (parameters[0].ObjectValue as Customer != null)
                    {
                        // Create Customer
                        Customer customer = (Customer) parameters[0].ObjectValue;

                        // verify customer exists
                        if(customer != null)
                        {
                            // Now create deleteCustomerProc from CustomerWriter
                            // The DataWriter converts the 'Customer'
                            // to the SqlParameter[] array needed to delete a 'Customer'.
                            deleteCustomerProc = CustomerWriter.CreateDeleteCustomerStoredProcedure(customer);
                        }
                    }

                    // Verify deleteCustomerProc exists
                    if(deleteCustomerProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = CustomerManager.DeleteCustomer(deleteCustomerProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Customer' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Customer' to delete.
            /// <returns>A PolymorphicObject object with all  'Customers' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Customer> customerListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllCustomersStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get CustomerParameter
                    // Declare Parameter
                    Customer paramCustomer = null;

                    // verify the first parameters is a(n) 'Customer'.
                    if (parameters[0].ObjectValue as Customer != null)
                    {
                        // Get CustomerParameter
                        paramCustomer = (Customer) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllCustomersProc from CustomerWriter
                    fetchAllProc = CustomerWriter.CreateFetchAllCustomersStoredProcedure(paramCustomer);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    customerListCollection = CustomerManager.FetchAllCustomers(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(customerListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = customerListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindCustomer(Customer)
            /// <summary>
            /// This method finds a 'Customer' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Customer' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindCustomer(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Customer customer = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindCustomerStoredProcedure findCustomerProc = null;

                    // verify the first parameters is a 'Customer'.
                    if (parameters[0].ObjectValue as Customer != null)
                    {
                        // Get CustomerParameter
                        Customer paramCustomer = (Customer) parameters[0].ObjectValue;

                        // verify paramCustomer exists
                        if(paramCustomer != null)
                        {
                            // Now create findCustomerProc from CustomerWriter
                            // The DataWriter converts the 'Customer'
                            // to the SqlParameter[] array needed to find a 'Customer'.
                            findCustomerProc = CustomerWriter.CreateFindCustomerStoredProcedure(paramCustomer);
                        }

                        // Verify findCustomerProc exists
                        if(findCustomerProc != null)
                        {
                            // Execute Find Stored Procedure
                            customer = CustomerManager.FindCustomer(findCustomerProc, dataConnector);

                            // if dataObject exists
                            if(customer != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = customer;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertCustomer (Customer)
            /// <summary>
            /// This method inserts a 'Customer' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Customer' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertCustomer(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Customer customer = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertCustomerStoredProcedure insertCustomerProc = null;

                    // verify the first parameters is a(n) 'Customer'.
                    if (parameters[0].ObjectValue as Customer != null)
                    {
                        // Create Customer Parameter
                        customer = (Customer) parameters[0].ObjectValue;

                        // verify customer exists
                        if(customer != null)
                        {
                            // Now create insertCustomerProc from CustomerWriter
                            // The DataWriter converts the 'Customer'
                            // to the SqlParameter[] array needed to insert a 'Customer'.
                            insertCustomerProc = CustomerWriter.CreateInsertCustomerStoredProcedure(customer);
                        }

                        // Verify insertCustomerProc exists
                        if(insertCustomerProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = CustomerManager.InsertCustomer(insertCustomerProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateCustomer (Customer)
            /// <summary>
            /// This method updates a 'Customer' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Customer' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateCustomer(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Customer customer = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateCustomerStoredProcedure updateCustomerProc = null;

                    // verify the first parameters is a(n) 'Customer'.
                    if (parameters[0].ObjectValue as Customer != null)
                    {
                        // Create Customer Parameter
                        customer = (Customer) parameters[0].ObjectValue;

                        // verify customer exists
                        if(customer != null)
                        {
                            // Now create updateCustomerProc from CustomerWriter
                            // The DataWriter converts the 'Customer'
                            // to the SqlParameter[] array needed to update a 'Customer'.
                            updateCustomerProc = CustomerWriter.CreateUpdateCustomerStoredProcedure(customer);
                        }

                        // Verify updateCustomerProc exists
                        if(updateCustomerProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = CustomerManager.UpdateCustomer(updateCustomerProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

    }
    #endregion

}

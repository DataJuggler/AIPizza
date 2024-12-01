

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

    #region class PizzaOrderMethods
    /// <summary>
    /// This class contains methods for modifying a 'PizzaOrder' object.
    /// </summary>
    public class PizzaOrderMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'PizzaOrderMethods' object.
        /// </summary>
        public PizzaOrderMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeletePizzaOrder(PizzaOrder)
            /// <summary>
            /// This method deletes a 'PizzaOrder' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'PizzaOrder' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeletePizzaOrder(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeletePizzaOrderStoredProcedure deletePizzaOrderProc = null;

                    // verify the first parameters is a(n) 'PizzaOrder'.
                    if (parameters[0].ObjectValue as PizzaOrder != null)
                    {
                        // Create PizzaOrder
                        PizzaOrder pizzaOrder = (PizzaOrder) parameters[0].ObjectValue;

                        // verify pizzaOrder exists
                        if(pizzaOrder != null)
                        {
                            // Now create deletePizzaOrderProc from PizzaOrderWriter
                            // The DataWriter converts the 'PizzaOrder'
                            // to the SqlParameter[] array needed to delete a 'PizzaOrder'.
                            deletePizzaOrderProc = PizzaOrderWriter.CreateDeletePizzaOrderStoredProcedure(pizzaOrder);
                        }
                    }

                    // Verify deletePizzaOrderProc exists
                    if(deletePizzaOrderProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = PizzaOrderManager.DeletePizzaOrder(deletePizzaOrderProc, dataConnector);

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
            /// This method fetches all 'PizzaOrder' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'PizzaOrder' to delete.
            /// <returns>A PolymorphicObject object with all  'PizzaOrders' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<PizzaOrder> pizzaOrderListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllPizzaOrdersStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get PizzaOrderParameter
                    // Declare Parameter
                    PizzaOrder paramPizzaOrder = null;

                    // verify the first parameters is a(n) 'PizzaOrder'.
                    if (parameters[0].ObjectValue as PizzaOrder != null)
                    {
                        // Get PizzaOrderParameter
                        paramPizzaOrder = (PizzaOrder) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllPizzaOrdersProc from PizzaOrderWriter
                    fetchAllProc = PizzaOrderWriter.CreateFetchAllPizzaOrdersStoredProcedure(paramPizzaOrder);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    pizzaOrderListCollection = PizzaOrderManager.FetchAllPizzaOrders(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(pizzaOrderListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = pizzaOrderListCollection;
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

            #region FindPizzaOrder(PizzaOrder)
            /// <summary>
            /// This method finds a 'PizzaOrder' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'PizzaOrder' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindPizzaOrder(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                PizzaOrder pizzaOrder = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindPizzaOrderStoredProcedure findPizzaOrderProc = null;

                    // verify the first parameters is a 'PizzaOrder'.
                    if (parameters[0].ObjectValue as PizzaOrder != null)
                    {
                        // Get PizzaOrderParameter
                        PizzaOrder paramPizzaOrder = (PizzaOrder) parameters[0].ObjectValue;

                        // verify paramPizzaOrder exists
                        if(paramPizzaOrder != null)
                        {
                            // Now create findPizzaOrderProc from PizzaOrderWriter
                            // The DataWriter converts the 'PizzaOrder'
                            // to the SqlParameter[] array needed to find a 'PizzaOrder'.
                            findPizzaOrderProc = PizzaOrderWriter.CreateFindPizzaOrderStoredProcedure(paramPizzaOrder);
                        }

                        // Verify findPizzaOrderProc exists
                        if(findPizzaOrderProc != null)
                        {
                            // Execute Find Stored Procedure
                            pizzaOrder = PizzaOrderManager.FindPizzaOrder(findPizzaOrderProc, dataConnector);

                            // if dataObject exists
                            if(pizzaOrder != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = pizzaOrder;
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

            #region InsertPizzaOrder (PizzaOrder)
            /// <summary>
            /// This method inserts a 'PizzaOrder' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'PizzaOrder' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertPizzaOrder(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                PizzaOrder pizzaOrder = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertPizzaOrderStoredProcedure insertPizzaOrderProc = null;

                    // verify the first parameters is a(n) 'PizzaOrder'.
                    if (parameters[0].ObjectValue as PizzaOrder != null)
                    {
                        // Create PizzaOrder Parameter
                        pizzaOrder = (PizzaOrder) parameters[0].ObjectValue;

                        // verify pizzaOrder exists
                        if(pizzaOrder != null)
                        {
                            // Now create insertPizzaOrderProc from PizzaOrderWriter
                            // The DataWriter converts the 'PizzaOrder'
                            // to the SqlParameter[] array needed to insert a 'PizzaOrder'.
                            insertPizzaOrderProc = PizzaOrderWriter.CreateInsertPizzaOrderStoredProcedure(pizzaOrder);
                        }

                        // Verify insertPizzaOrderProc exists
                        if(insertPizzaOrderProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = PizzaOrderManager.InsertPizzaOrder(insertPizzaOrderProc, dataConnector);
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

            #region UpdatePizzaOrder (PizzaOrder)
            /// <summary>
            /// This method updates a 'PizzaOrder' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'PizzaOrder' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdatePizzaOrder(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                PizzaOrder pizzaOrder = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdatePizzaOrderStoredProcedure updatePizzaOrderProc = null;

                    // verify the first parameters is a(n) 'PizzaOrder'.
                    if (parameters[0].ObjectValue as PizzaOrder != null)
                    {
                        // Create PizzaOrder Parameter
                        pizzaOrder = (PizzaOrder) parameters[0].ObjectValue;

                        // verify pizzaOrder exists
                        if(pizzaOrder != null)
                        {
                            // Now create updatePizzaOrderProc from PizzaOrderWriter
                            // The DataWriter converts the 'PizzaOrder'
                            // to the SqlParameter[] array needed to update a 'PizzaOrder'.
                            updatePizzaOrderProc = PizzaOrderWriter.CreateUpdatePizzaOrderStoredProcedure(pizzaOrder);
                        }

                        // Verify updatePizzaOrderProc exists
                        if(updatePizzaOrderProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = PizzaOrderManager.UpdatePizzaOrder(updatePizzaOrderProc, dataConnector);

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

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}

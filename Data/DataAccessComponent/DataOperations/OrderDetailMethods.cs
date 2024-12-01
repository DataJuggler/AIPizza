

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

    #region class OrderDetailMethods
    /// <summary>
    /// This class contains methods for modifying a 'OrderDetail' object.
    /// </summary>
    public class OrderDetailMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'OrderDetailMethods' object.
        /// </summary>
        public OrderDetailMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteOrderDetail(OrderDetail)
            /// <summary>
            /// This method deletes a 'OrderDetail' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'OrderDetail' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteOrderDetail(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteOrderDetailStoredProcedure deleteOrderDetailProc = null;

                    // verify the first parameters is a(n) 'OrderDetail'.
                    if (parameters[0].ObjectValue as OrderDetail != null)
                    {
                        // Create OrderDetail
                        OrderDetail orderDetail = (OrderDetail) parameters[0].ObjectValue;

                        // verify orderDetail exists
                        if(orderDetail != null)
                        {
                            // Now create deleteOrderDetailProc from OrderDetailWriter
                            // The DataWriter converts the 'OrderDetail'
                            // to the SqlParameter[] array needed to delete a 'OrderDetail'.
                            deleteOrderDetailProc = OrderDetailWriter.CreateDeleteOrderDetailStoredProcedure(orderDetail);
                        }
                    }

                    // Verify deleteOrderDetailProc exists
                    if(deleteOrderDetailProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = OrderDetailManager.DeleteOrderDetail(deleteOrderDetailProc, dataConnector);

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
            /// This method fetches all 'OrderDetail' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'OrderDetail' to delete.
            /// <returns>A PolymorphicObject object with all  'OrderDetails' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<OrderDetail> orderDetailListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllOrderDetailsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get OrderDetailParameter
                    // Declare Parameter
                    OrderDetail paramOrderDetail = null;

                    // verify the first parameters is a(n) 'OrderDetail'.
                    if (parameters[0].ObjectValue as OrderDetail != null)
                    {
                        // Get OrderDetailParameter
                        paramOrderDetail = (OrderDetail) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllOrderDetailsProc from OrderDetailWriter
                    fetchAllProc = OrderDetailWriter.CreateFetchAllOrderDetailsStoredProcedure(paramOrderDetail);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    orderDetailListCollection = OrderDetailManager.FetchAllOrderDetails(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(orderDetailListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = orderDetailListCollection;
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

            #region FindOrderDetail(OrderDetail)
            /// <summary>
            /// This method finds a 'OrderDetail' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'OrderDetail' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindOrderDetail(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                OrderDetail orderDetail = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindOrderDetailStoredProcedure findOrderDetailProc = null;

                    // verify the first parameters is a 'OrderDetail'.
                    if (parameters[0].ObjectValue as OrderDetail != null)
                    {
                        // Get OrderDetailParameter
                        OrderDetail paramOrderDetail = (OrderDetail) parameters[0].ObjectValue;

                        // verify paramOrderDetail exists
                        if(paramOrderDetail != null)
                        {
                            // Now create findOrderDetailProc from OrderDetailWriter
                            // The DataWriter converts the 'OrderDetail'
                            // to the SqlParameter[] array needed to find a 'OrderDetail'.
                            findOrderDetailProc = OrderDetailWriter.CreateFindOrderDetailStoredProcedure(paramOrderDetail);
                        }

                        // Verify findOrderDetailProc exists
                        if(findOrderDetailProc != null)
                        {
                            // Execute Find Stored Procedure
                            orderDetail = OrderDetailManager.FindOrderDetail(findOrderDetailProc, dataConnector);

                            // if dataObject exists
                            if(orderDetail != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = orderDetail;
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

            #region InsertOrderDetail (OrderDetail)
            /// <summary>
            /// This method inserts a 'OrderDetail' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'OrderDetail' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertOrderDetail(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                OrderDetail orderDetail = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertOrderDetailStoredProcedure insertOrderDetailProc = null;

                    // verify the first parameters is a(n) 'OrderDetail'.
                    if (parameters[0].ObjectValue as OrderDetail != null)
                    {
                        // Create OrderDetail Parameter
                        orderDetail = (OrderDetail) parameters[0].ObjectValue;

                        // verify orderDetail exists
                        if(orderDetail != null)
                        {
                            // Now create insertOrderDetailProc from OrderDetailWriter
                            // The DataWriter converts the 'OrderDetail'
                            // to the SqlParameter[] array needed to insert a 'OrderDetail'.
                            insertOrderDetailProc = OrderDetailWriter.CreateInsertOrderDetailStoredProcedure(orderDetail);
                        }

                        // Verify insertOrderDetailProc exists
                        if(insertOrderDetailProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = OrderDetailManager.InsertOrderDetail(insertOrderDetailProc, dataConnector);
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

            #region UpdateOrderDetail (OrderDetail)
            /// <summary>
            /// This method updates a 'OrderDetail' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'OrderDetail' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateOrderDetail(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                OrderDetail orderDetail = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateOrderDetailStoredProcedure updateOrderDetailProc = null;

                    // verify the first parameters is a(n) 'OrderDetail'.
                    if (parameters[0].ObjectValue as OrderDetail != null)
                    {
                        // Create OrderDetail Parameter
                        orderDetail = (OrderDetail) parameters[0].ObjectValue;

                        // verify orderDetail exists
                        if(orderDetail != null)
                        {
                            // Now create updateOrderDetailProc from OrderDetailWriter
                            // The DataWriter converts the 'OrderDetail'
                            // to the SqlParameter[] array needed to update a 'OrderDetail'.
                            updateOrderDetailProc = OrderDetailWriter.CreateUpdateOrderDetailStoredProcedure(orderDetail);
                        }

                        // Verify updateOrderDetailProc exists
                        if(updateOrderDetailProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = OrderDetailManager.UpdateOrderDetail(updateOrderDetailProc, dataConnector);

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

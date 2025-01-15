

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

    #region class OrderDetailController
    /// <summary>
    /// This class controls a(n) 'OrderDetail' object.
    /// </summary>
    public class OrderDetailController
    {

        #region Methods

            #region CreateOrderDetailParameter
            /// <summary>
            /// This method creates the parameter for a 'OrderDetail' data operation.
            /// </summary>
            /// <param name='orderdetail'>The 'OrderDetail' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateOrderDetailParameter(OrderDetail orderDetail)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = orderDetail;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(OrderDetail tempOrderDetail, DataManager dataManager)
            /// <summary>
            /// Deletes a 'OrderDetail' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'OrderDetail_Delete'.
            /// </summary>
            /// <param name='orderdetail'>The 'OrderDetail' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(OrderDetail tempOrderDetail, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteOrderDetail";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify temporderDetail exists before attemptintg to delete
                    if (tempOrderDetail != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteOrderDetailMethod = OrderDetailMethods.DeleteOrderDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateOrderDetailParameter(tempOrderDetail);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteOrderDetailMethod, parameters, dataManager);

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

            #region FetchAll(OrderDetail tempOrderDetail, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'OrderDetail' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'OrderDetail_FetchAll'.</summary>
            /// <param name='tempOrderDetail'>A temporary OrderDetail for passing values.</param>
            /// <returns>A collection of 'OrderDetail' objects.</returns>
            public static List<OrderDetail> FetchAll(OrderDetail tempOrderDetail, DataManager dataManager)
            {
                // Initial value
                List<OrderDetail> orderDetailList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = OrderDetailMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateOrderDetailParameter(tempOrderDetail);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<OrderDetail> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        orderDetailList = (List<OrderDetail>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return orderDetailList;
            }
            #endregion

            #region Find(OrderDetail tempOrderDetail, DataManager dataManager)
            /// <summary>
            /// Finds a 'OrderDetail' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'OrderDetail_Find'</param>
            /// </summary>
            /// <param name='tempOrderDetail'>A temporary OrderDetail for passing values.</param>
            /// <returns>A 'OrderDetail' object if found else a null 'OrderDetail'.</returns>
            public static OrderDetail Find(OrderDetail tempOrderDetail, DataManager dataManager)
            {
                // Initial values
                OrderDetail orderDetail = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempOrderDetail != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = OrderDetailMethods.FindOrderDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateOrderDetailParameter(tempOrderDetail);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as OrderDetail != null))
                        {
                            // Get ReturnObject
                            orderDetail = (OrderDetail) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return orderDetail;
            }
            #endregion

            #region Insert(OrderDetail orderDetail, DataManager dataManager)
            /// <summary>
            /// Insert a 'OrderDetail' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'OrderDetail_Insert'.</param>
            /// </summary>
            /// <param name='orderDetail'>The 'OrderDetail' object to insert.</param>
            /// <returns>The id (int) of the new  'OrderDetail' object that was inserted.</returns>
            public static int Insert(OrderDetail orderDetail, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If OrderDetailexists
                    if (orderDetail != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = OrderDetailMethods.InsertOrderDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateOrderDetailParameter(orderDetail);

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

            #region Save(ref OrderDetail orderDetail, DataManager dataManager)
            /// <summary>
            /// Saves a 'OrderDetail' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='orderDetail'>The 'OrderDetail' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref OrderDetail orderDetail, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the orderDetail exists.
                if (orderDetail != null)
                {
                    // Is this a new OrderDetail
                    if (orderDetail.IsNew)
                    {
                        // Insert new OrderDetail
                        int newIdentity = Insert(orderDetail, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            orderDetail.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update OrderDetail
                        saved = Update(orderDetail, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(OrderDetail orderDetail, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'OrderDetail' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'OrderDetail_Update'.</param>
            /// </summary>
            /// <param name='orderDetail'>The 'OrderDetail' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(OrderDetail orderDetail, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (orderDetail != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = OrderDetailMethods.UpdateOrderDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateOrderDetailParameter(orderDetail);
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

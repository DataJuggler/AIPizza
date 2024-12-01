

#region using statements

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

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'OrderDetailController' object.
        /// </summary>
        public OrderDetailController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

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

            #region Delete(OrderDetail tempOrderDetail)
            /// <summary>
            /// Deletes a 'OrderDetail' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'OrderDetail_Delete'.
            /// </summary>
            /// <param name='orderdetail'>The 'OrderDetail' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(OrderDetail tempOrderDetail)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteOrderDetail";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify temporderDetail exists before attemptintg to delete
                    if(tempOrderDetail != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteOrderDetailMethod = this.AppController.DataBridge.DataOperations.OrderDetailMethods.DeleteOrderDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateOrderDetailParameter(tempOrderDetail);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteOrderDetailMethod, parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(OrderDetail tempOrderDetail)
            /// <summary>
            /// This method fetches a collection of 'OrderDetail' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'OrderDetail_FetchAll'.</summary>
            /// <param name='tempOrderDetail'>A temporary OrderDetail for passing values.</param>
            /// <returns>A collection of 'OrderDetail' objects.</returns>
            public List<OrderDetail> FetchAll(OrderDetail tempOrderDetail)
            {
                // Initial value
                List<OrderDetail> orderDetailList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.OrderDetailMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateOrderDetailParameter(tempOrderDetail);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<OrderDetail> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        orderDetailList = (List<OrderDetail>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return orderDetailList;
            }
            #endregion

            #region Find(OrderDetail tempOrderDetail)
            /// <summary>
            /// Finds a 'OrderDetail' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'OrderDetail_Find'</param>
            /// </summary>
            /// <param name='tempOrderDetail'>A temporary OrderDetail for passing values.</param>
            /// <returns>A 'OrderDetail' object if found else a null 'OrderDetail'.</returns>
            public OrderDetail Find(OrderDetail tempOrderDetail)
            {
                // Initial values
                OrderDetail orderDetail = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempOrderDetail != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.OrderDetailMethods.FindOrderDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateOrderDetailParameter(tempOrderDetail);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return orderDetail;
            }
            #endregion

            #region Insert(OrderDetail orderDetail)
            /// <summary>
            /// Insert a 'OrderDetail' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'OrderDetail_Insert'.</param>
            /// </summary>
            /// <param name='orderDetail'>The 'OrderDetail' object to insert.</param>
            /// <returns>The id (int) of the new  'OrderDetail' object that was inserted.</returns>
            public int Insert(OrderDetail orderDetail)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If OrderDetailexists
                    if(orderDetail != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.OrderDetailMethods.InsertOrderDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateOrderDetailParameter(orderDetail);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref OrderDetail orderDetail)
            /// <summary>
            /// Saves a 'OrderDetail' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='orderDetail'>The 'OrderDetail' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref OrderDetail orderDetail)
            {
                // Initial value
                bool saved = false;

                // If the orderDetail exists.
                if(orderDetail != null)
                {
                    // Is this a new OrderDetail
                    if(orderDetail.IsNew)
                    {
                        // Insert new OrderDetail
                        int newIdentity = this.Insert(orderDetail);

                        // if insert was successful
                        if(newIdentity > 0)
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
                        saved = this.Update(orderDetail);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(OrderDetail orderDetail)
            /// <summary>
            /// This method Updates a 'OrderDetail' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'OrderDetail_Update'.</param>
            /// </summary>
            /// <param name='orderDetail'>The 'OrderDetail' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(OrderDetail orderDetail)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(orderDetail != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.OrderDetailMethods.UpdateOrderDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateOrderDetailParameter(orderDetail);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}

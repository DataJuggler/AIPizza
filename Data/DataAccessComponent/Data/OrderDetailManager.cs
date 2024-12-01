

#region using statements

using DataAccessComponent.Data.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data
{

    #region class OrderDetailManager
    /// <summary>
    /// This class is used to manage a 'OrderDetail' object.
    /// </summary>
    public class OrderDetailManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'OrderDetailManager' object.
        /// </summary>
        public OrderDetailManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteOrderDetail()
            /// <summary>
            /// This method deletes a 'OrderDetail' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteOrderDetail(DeleteOrderDetailStoredProcedure deleteOrderDetailProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteOrderDetailProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllOrderDetails()
            /// <summary>
            /// This method fetches a  'List<OrderDetail>' object.
            /// This method uses the 'OrderDetails_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<OrderDetail>'</returns>
            /// </summary>
            public static List<OrderDetail> FetchAllOrderDetails(FetchAllOrderDetailsStoredProcedure fetchAllOrderDetailsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<OrderDetail> orderDetailCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allOrderDetailsDataSet = DataHelper.LoadDataSet(fetchAllOrderDetailsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allOrderDetailsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allOrderDetailsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            orderDetailCollection = OrderDetailReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return orderDetailCollection;
            }
            #endregion

            #region FindOrderDetail()
            /// <summary>
            /// This method finds a  'OrderDetail' object.
            /// This method uses the 'OrderDetail_Find' procedure.
            /// </summary>
            /// <returns>A 'OrderDetail' object.</returns>
            /// </summary>
            public static OrderDetail FindOrderDetail(FindOrderDetailStoredProcedure findOrderDetailProc, DataConnector databaseConnector)
            {
                // Initial Value
                OrderDetail orderDetail = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet orderDetailDataSet = DataHelper.LoadDataSet(findOrderDetailProc, databaseConnector);

                    // Verify DataSet Exists
                    if(orderDetailDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(orderDetailDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load OrderDetail
                            orderDetail = OrderDetailReader.Load(row);
                        }
                    }
                }

                // return value
                return orderDetail;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertOrderDetail()
            /// <summary>
            /// This method inserts a 'OrderDetail' object.
            /// This method uses the 'OrderDetail_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertOrderDetail(InsertOrderDetailStoredProcedure insertOrderDetailProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertOrderDetailProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateOrderDetail()
            /// <summary>
            /// This method updates a 'OrderDetail'.
            /// This method uses the 'OrderDetail_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateOrderDetail(UpdateOrderDetailStoredProcedure updateOrderDetailProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateOrderDetailProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}

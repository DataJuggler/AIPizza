

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

    #region class PizzaOrderManager
    /// <summary>
    /// This class is used to manage a 'PizzaOrder' object.
    /// </summary>
    public class PizzaOrderManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'PizzaOrderManager' object.
        /// </summary>
        public PizzaOrderManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeletePizzaOrder()
            /// <summary>
            /// This method deletes a 'PizzaOrder' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeletePizzaOrder(DeletePizzaOrderStoredProcedure deletePizzaOrderProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deletePizzaOrderProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllPizzaOrders()
            /// <summary>
            /// This method fetches a  'List<PizzaOrder>' object.
            /// This method uses the 'PizzaOrders_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<PizzaOrder>'</returns>
            /// </summary>
            public static List<PizzaOrder> FetchAllPizzaOrders(FetchAllPizzaOrdersStoredProcedure fetchAllPizzaOrdersProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<PizzaOrder> pizzaOrderCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allPizzaOrdersDataSet = DataHelper.LoadDataSet(fetchAllPizzaOrdersProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allPizzaOrdersDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allPizzaOrdersDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            pizzaOrderCollection = PizzaOrderReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return pizzaOrderCollection;
            }
            #endregion

            #region FindPizzaOrder()
            /// <summary>
            /// This method finds a  'PizzaOrder' object.
            /// This method uses the 'PizzaOrder_Find' procedure.
            /// </summary>
            /// <returns>A 'PizzaOrder' object.</returns>
            /// </summary>
            public static PizzaOrder FindPizzaOrder(FindPizzaOrderStoredProcedure findPizzaOrderProc, DataConnector databaseConnector)
            {
                // Initial Value
                PizzaOrder pizzaOrder = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet pizzaOrderDataSet = DataHelper.LoadDataSet(findPizzaOrderProc, databaseConnector);

                    // Verify DataSet Exists
                    if(pizzaOrderDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(pizzaOrderDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load PizzaOrder
                            pizzaOrder = PizzaOrderReader.Load(row);
                        }
                    }
                }

                // return value
                return pizzaOrder;
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

            #region InsertPizzaOrder()
            /// <summary>
            /// This method inserts a 'PizzaOrder' object.
            /// This method uses the 'PizzaOrder_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertPizzaOrder(InsertPizzaOrderStoredProcedure insertPizzaOrderProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertPizzaOrderProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdatePizzaOrder()
            /// <summary>
            /// This method updates a 'PizzaOrder'.
            /// This method uses the 'PizzaOrder_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdatePizzaOrder(UpdatePizzaOrderStoredProcedure updatePizzaOrderProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updatePizzaOrderProc, databaseConnector);
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

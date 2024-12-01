

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

    #region class CustomerManager
    /// <summary>
    /// This class is used to manage a 'Customer' object.
    /// </summary>
    public class CustomerManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CustomerManager' object.
        /// </summary>
        public CustomerManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteCustomer()
            /// <summary>
            /// This method deletes a 'Customer' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteCustomer(DeleteCustomerStoredProcedure deleteCustomerProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteCustomerProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllCustomers()
            /// <summary>
            /// This method fetches a  'List<Customer>' object.
            /// This method uses the 'Customers_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Customer>'</returns>
            /// </summary>
            public static List<Customer> FetchAllCustomers(FetchAllCustomersStoredProcedure fetchAllCustomersProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Customer> customerCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allCustomersDataSet = DataHelper.LoadDataSet(fetchAllCustomersProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allCustomersDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allCustomersDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            customerCollection = CustomerReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return customerCollection;
            }
            #endregion

            #region FindCustomer()
            /// <summary>
            /// This method finds a  'Customer' object.
            /// This method uses the 'Customer_Find' procedure.
            /// </summary>
            /// <returns>A 'Customer' object.</returns>
            /// </summary>
            public static Customer FindCustomer(FindCustomerStoredProcedure findCustomerProc, DataConnector databaseConnector)
            {
                // Initial Value
                Customer customer = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet customerDataSet = DataHelper.LoadDataSet(findCustomerProc, databaseConnector);

                    // Verify DataSet Exists
                    if(customerDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(customerDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Customer
                            customer = CustomerReader.Load(row);
                        }
                    }
                }

                // return value
                return customer;
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

            #region InsertCustomer()
            /// <summary>
            /// This method inserts a 'Customer' object.
            /// This method uses the 'Customer_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertCustomer(InsertCustomerStoredProcedure insertCustomerProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertCustomerProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateCustomer()
            /// <summary>
            /// This method updates a 'Customer'.
            /// This method uses the 'Customer_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateCustomer(UpdateCustomerStoredProcedure updateCustomerProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateCustomerProc, databaseConnector);
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

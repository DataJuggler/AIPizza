

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

    #region class DataOperationsManager
    /// <summary>
    /// This class manages DataOperations for this project.
    /// </summary>
    public class DataOperationsManager
    {

        #region Private Variables
        private DataManager dataManager;
        private SystemMethods systemMethods;
        private CustomerMethods customerMethods;
        private OrderDetailMethods orderdetailMethods;
        private PizzaOrderMethods pizzaorderMethods;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DataOperationsManager' object.
        /// </summary>
        public DataOperationsManager(DataManager dataManagerArg)
        {
            // Save Arguments
            this.DataManager = dataManagerArg;

            // Create Child DataOperationMethods
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child DataOperationMethods
            /// </summary>
            private void Init()
            {
                // Create Child DataOperatonMethods
                this.SystemMethods = new SystemMethods();
                this.CustomerMethods = new CustomerMethods(this.DataManager);
                this.OrderDetailMethods = new OrderDetailMethods(this.DataManager);
                this.PizzaOrderMethods = new PizzaOrderMethods(this.DataManager);
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

            #region SystemMethods
            public SystemMethods SystemMethods
            {
                get { return systemMethods; }
                set { systemMethods = value; }
            }
            #endregion

            #region CustomerMethods
            public CustomerMethods CustomerMethods
            {
                get { return customerMethods; }
                set { customerMethods = value; }
            }
            #endregion

            #region OrderDetailMethods
            public OrderDetailMethods OrderDetailMethods
            {
                get { return orderdetailMethods; }
                set { orderdetailMethods = value; }
            }
            #endregion

            #region PizzaOrderMethods
            public PizzaOrderMethods PizzaOrderMethods
            {
                get { return pizzaorderMethods; }
                set { pizzaorderMethods = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}

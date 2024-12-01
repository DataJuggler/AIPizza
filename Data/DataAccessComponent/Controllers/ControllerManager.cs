

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

    #region class ControllerManager
    /// <summary>
    /// This class manages the child controllers for this application.
    /// </summary>
    public class ControllerManager
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        private CustomerController customerController;
        private OrderDetailController orderdetailController;
        private PizzaOrderController pizzaorderController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ControllerManager' object.
        /// </summary>
        public ControllerManager(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;

            // Create Child Controllers
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child Controllers
            /// </summary>
            private void Init()
            {
                // Create Child Controllers
                this.CustomerController = new CustomerController(this.ErrorProcessor, this.AppController);
                this.OrderDetailController = new OrderDetailController(this.ErrorProcessor, this.AppController);
                this.PizzaOrderController = new PizzaOrderController(this.ErrorProcessor, this.AppController);
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

            #region CustomerController
            public CustomerController CustomerController
            {
                get { return customerController; }
                set { customerController = value; }
            }
            #endregion

            #region OrderDetailController
            public OrderDetailController OrderDetailController
            {
                get { return orderdetailController; }
                set { orderdetailController = value; }
            }
            #endregion

            #region PizzaOrderController
            public PizzaOrderController PizzaOrderController
            {
                get { return pizzaorderController; }
                set { pizzaorderController = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}

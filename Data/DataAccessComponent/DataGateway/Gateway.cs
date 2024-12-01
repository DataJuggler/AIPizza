
#region using statements

using DataAccessComponent.Controllers;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Data;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

#endregion

namespace DataAccessComponent.DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName = "")
        {
            // store the ConnectionName
            this.ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region DeleteCustomer(int id, Customer tempCustomer = null)
            /// <summary>
            /// This method is used to delete Customer objects.
            /// </summary>
            /// <param name="id">Delete the Customer with this id</param>
            /// <param name="tempCustomer">Pass in a tempCustomer to perform a custom delete.</param>
            public bool DeleteCustomer(int id, Customer tempCustomer = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempCustomer does not exist
                    if (tempCustomer == null)
                    {
                        // create a temp Customer
                        tempCustomer = new Customer();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempCustomer.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.CustomerController.Delete(tempCustomer);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteOrderDetail(int id, OrderDetail tempOrderDetail = null)
            /// <summary>
            /// This method is used to delete OrderDetail objects.
            /// </summary>
            /// <param name="id">Delete the OrderDetail with this id</param>
            /// <param name="tempOrderDetail">Pass in a tempOrderDetail to perform a custom delete.</param>
            public bool DeleteOrderDetail(int id, OrderDetail tempOrderDetail = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempOrderDetail does not exist
                    if (tempOrderDetail == null)
                    {
                        // create a temp OrderDetail
                        tempOrderDetail = new OrderDetail();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempOrderDetail.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.OrderDetailController.Delete(tempOrderDetail);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeletePizzaOrder(int id, PizzaOrder tempPizzaOrder = null)
            /// <summary>
            /// This method is used to delete PizzaOrder objects.
            /// </summary>
            /// <param name="id">Delete the PizzaOrder with this id</param>
            /// <param name="tempPizzaOrder">Pass in a tempPizzaOrder to perform a custom delete.</param>
            public bool DeletePizzaOrder(int id, PizzaOrder tempPizzaOrder = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempPizzaOrder does not exist
                    if (tempPizzaOrder == null)
                    {
                        // create a temp PizzaOrder
                        tempPizzaOrder = new PizzaOrder();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempPizzaOrder.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.PizzaOrderController.Delete(tempPizzaOrder);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.Data.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindCustomer(int id, Customer tempCustomer = null)
            /// <summary>
            /// This method is used to find 'Customer' objects.
            /// </summary>
            /// <param name="id">Find the Customer with this id</param>
            /// <param name="tempCustomer">Pass in a tempCustomer to perform a custom find.</param>
            public Customer FindCustomer(int id, Customer tempCustomer = null)
            {
                // initial value
                Customer customer = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempCustomer does not exist
                    if (tempCustomer == null)
                    {
                        // create a temp Customer
                        tempCustomer = new Customer();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempCustomer.UpdateIdentity(id);
                    }

                    // perform the find
                    customer = this.AppController.ControllerManager.CustomerController.Find(tempCustomer);
                }

                // return value
                return customer;
            }
            #endregion

                #region FindCustomerByPhoneNumber(string phoneNumber)
                /// <summary>
                /// This method is used to find 'Customer' objects for the PhoneNumber given.
                /// </summary>
                public Customer FindCustomerByPhoneNumber(string phoneNumber)
                {
                    // initial value
                    Customer customer = null;
                    
                    // Create a temp Customer object
                    Customer tempCustomer = new Customer();
                    
                    // Set the value for FindByPhoneNumber to true
                    tempCustomer.FindByPhoneNumber = true;
                    
                    // Set the value for PhoneNumber
                    tempCustomer.PhoneNumber = phoneNumber;
                    
                    // Perform the find
                    customer = FindCustomer(0, tempCustomer);
                    
                    // return value
                    return customer;
                }
                #endregion
                
            #region FindOrderDetail(int id, OrderDetail tempOrderDetail = null)
            /// <summary>
            /// This method is used to find 'OrderDetail' objects.
            /// </summary>
            /// <param name="id">Find the OrderDetail with this id</param>
            /// <param name="tempOrderDetail">Pass in a tempOrderDetail to perform a custom find.</param>
            public OrderDetail FindOrderDetail(int id, OrderDetail tempOrderDetail = null)
            {
                // initial value
                OrderDetail orderDetail = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempOrderDetail does not exist
                    if (tempOrderDetail == null)
                    {
                        // create a temp OrderDetail
                        tempOrderDetail = new OrderDetail();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempOrderDetail.UpdateIdentity(id);
                    }

                    // perform the find
                    orderDetail = this.AppController.ControllerManager.OrderDetailController.Find(tempOrderDetail);
                }

                // return value
                return orderDetail;
            }
            #endregion

            #region FindPizzaOrder(int id, PizzaOrder tempPizzaOrder = null)
            /// <summary>
            /// This method is used to find 'PizzaOrder' objects.
            /// </summary>
            /// <param name="id">Find the PizzaOrder with this id</param>
            /// <param name="tempPizzaOrder">Pass in a tempPizzaOrder to perform a custom find.</param>
            public PizzaOrder FindPizzaOrder(int id, PizzaOrder tempPizzaOrder = null)
            {
                // initial value
                PizzaOrder pizzaOrder = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempPizzaOrder does not exist
                    if (tempPizzaOrder == null)
                    {
                        // create a temp PizzaOrder
                        tempPizzaOrder = new PizzaOrder();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempPizzaOrder.UpdateIdentity(id);
                    }

                    // perform the find
                    pizzaOrder = this.AppController.ControllerManager.PizzaOrderController.Find(tempPizzaOrder);
                }

                // return value
                return pizzaOrder;
            }
            #endregion

            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (this.AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = this.AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // If the AppController object exists
                if (this.HasAppController)
                {
                    // return the Exception from the AppController
                    exception = this.AppController.Exception;

                    // Set to null after the exception is retrieved so it does not return again
                    this.AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                this.AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region LoadCustomers(Customer tempCustomer = null)
            /// <summary>
            /// This method loads a collection of 'Customer' objects.
            /// </summary>
            public List<Customer> LoadCustomers(Customer tempCustomer = null)
            {
                // initial value
                List<Customer> customers = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    customers = this.AppController.ControllerManager.CustomerController.FetchAll(tempCustomer);
                }

                // return value
                return customers;
            }
            #endregion

            #region LoadOrderDetails(OrderDetail tempOrderDetail = null)
            /// <summary>
            /// This method loads a collection of 'OrderDetail' objects.
            /// </summary>
            public List<OrderDetail> LoadOrderDetails(OrderDetail tempOrderDetail = null)
            {
                // initial value
                List<OrderDetail> orderDetails = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    orderDetails = this.AppController.ControllerManager.OrderDetailController.FetchAll(tempOrderDetail);
                }

                // return value
                return orderDetails;
            }
            #endregion

            #region LoadPizzaOrders(PizzaOrder tempPizzaOrder = null)
            /// <summary>
            /// This method loads a collection of 'PizzaOrder' objects.
            /// </summary>
            public List<PizzaOrder> LoadPizzaOrders(PizzaOrder tempPizzaOrder = null)
            {
                // initial value
                List<PizzaOrder> pizzaOrders = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    pizzaOrders = this.AppController.ControllerManager.PizzaOrderController.FetchAll(tempPizzaOrder);
                }

                // return value
                return pizzaOrders;
            }
            #endregion

            #region SaveCustomer(ref Customer customer)
            /// <summary>
            /// This method is used to save 'Customer' objects.
            /// </summary>
            /// <param name="customer">The Customer to save.</param>
            public bool SaveCustomer(ref Customer customer)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.CustomerController.Save(ref customer);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveOrderDetail(ref OrderDetail orderDetail)
            /// <summary>
            /// This method is used to save 'OrderDetail' objects.
            /// </summary>
            /// <param name="orderDetail">The OrderDetail to save.</param>
            public bool SaveOrderDetail(ref OrderDetail orderDetail)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.OrderDetailController.Save(ref orderDetail);
                }

                // return value
                return saved;
            }
            #endregion

            #region SavePizzaOrder(ref PizzaOrder pizzaOrder)
            /// <summary>
            /// This method is used to save 'PizzaOrder' objects.
            /// </summary>
            /// <param name="pizzaOrder">The PizzaOrder to save.</param>
            public bool SavePizzaOrder(ref PizzaOrder pizzaOrder)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.PizzaOrderController.Save(ref pizzaOrder);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion
            
            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}


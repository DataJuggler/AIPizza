

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Writers
{

    #region class PizzaOrderWriterBase
    /// <summary>
    /// This class is used for converting a 'PizzaOrder' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class PizzaOrderWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(PizzaOrder pizzaOrder)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='pizzaOrder'>The 'PizzaOrder' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(PizzaOrder pizzaOrder)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (pizzaOrder != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", pizzaOrder.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeletePizzaOrderStoredProcedure(PizzaOrder pizzaOrder)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeletePizzaOrder'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'PizzaOrder_Delete'.
            /// </summary>
            /// <param name="pizzaOrder">The 'PizzaOrder' to Delete.</param>
            /// <returns>An instance of a 'DeletePizzaOrderStoredProcedure' object.</returns>
            public static DeletePizzaOrderStoredProcedure CreateDeletePizzaOrderStoredProcedure(PizzaOrder pizzaOrder)
            {
                // Initial Value
                DeletePizzaOrderStoredProcedure deletePizzaOrderStoredProcedure = new DeletePizzaOrderStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deletePizzaOrderStoredProcedure.Parameters = CreatePrimaryKeyParameter(pizzaOrder);

                // return value
                return deletePizzaOrderStoredProcedure;
            }
            #endregion

            #region CreateFindPizzaOrderStoredProcedure(PizzaOrder pizzaOrder)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindPizzaOrderStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'PizzaOrder_Find'.
            /// </summary>
            /// <param name="pizzaOrder">The 'PizzaOrder' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindPizzaOrderStoredProcedure CreateFindPizzaOrderStoredProcedure(PizzaOrder pizzaOrder)
            {
                // Initial Value
                FindPizzaOrderStoredProcedure findPizzaOrderStoredProcedure = null;

                // verify pizzaOrder exists
                if(pizzaOrder != null)
                {
                    // Instanciate findPizzaOrderStoredProcedure
                    findPizzaOrderStoredProcedure = new FindPizzaOrderStoredProcedure();

                    // Now create parameters for this procedure
                    findPizzaOrderStoredProcedure.Parameters = CreatePrimaryKeyParameter(pizzaOrder);
                }

                // return value
                return findPizzaOrderStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(PizzaOrder pizzaOrder)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new pizzaOrder.
            /// </summary>
            /// <param name="pizzaOrder">The 'PizzaOrder' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(PizzaOrder pizzaOrder)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify pizzaOrderexists
                if(pizzaOrder != null)
                {
                    // Create [CustomerId] parameter
                    param = new SqlParameter("@CustomerId", pizzaOrder.CustomerId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [DriverDepartTime] Parameter
                    param = new SqlParameter("@DriverDepartTime", SqlDbType.DateTime);

                    // If pizzaOrder.DriverDepartTime does not exist.
                    if (pizzaOrder.DriverDepartTime.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = pizzaOrder.DriverDepartTime;
                    }
                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Filled] parameter
                    param = new SqlParameter("@Filled", pizzaOrder.Filled);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [OrderDate] Parameter
                    param = new SqlParameter("@OrderDate", SqlDbType.DateTime);

                    // If pizzaOrder.OrderDate does not exist.
                    if (pizzaOrder.OrderDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = pizzaOrder.OrderDate;
                    }
                    // set parameters[3]
                    parameters[3] = param;

                    // Create [OrderType] parameter
                    param = new SqlParameter("@OrderType", pizzaOrder.OrderType);

                    // set parameters[4]
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertPizzaOrderStoredProcedure(PizzaOrder pizzaOrder)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertPizzaOrderStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'PizzaOrder_Insert'.
            /// </summary>
            /// <param name="pizzaOrder"The 'PizzaOrder' object to insert</param>
            /// <returns>An instance of a 'InsertPizzaOrderStoredProcedure' object.</returns>
            public static InsertPizzaOrderStoredProcedure CreateInsertPizzaOrderStoredProcedure(PizzaOrder pizzaOrder)
            {
                // Initial Value
                InsertPizzaOrderStoredProcedure insertPizzaOrderStoredProcedure = null;

                // verify pizzaOrder exists
                if(pizzaOrder != null)
                {
                    // Instanciate insertPizzaOrderStoredProcedure
                    insertPizzaOrderStoredProcedure = new InsertPizzaOrderStoredProcedure();

                    // Now create parameters for this procedure
                    insertPizzaOrderStoredProcedure.Parameters = CreateInsertParameters(pizzaOrder);
                }

                // return value
                return insertPizzaOrderStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(PizzaOrder pizzaOrder)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing pizzaOrder.
            /// </summary>
            /// <param name="pizzaOrder">The 'PizzaOrder' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(PizzaOrder pizzaOrder)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[6];
                SqlParameter param = null;

                // verify pizzaOrderexists
                if(pizzaOrder != null)
                {
                    // Create parameter for [CustomerId]
                    param = new SqlParameter("@CustomerId", pizzaOrder.CustomerId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [DriverDepartTime]
                    // Create [DriverDepartTime] Parameter
                    param = new SqlParameter("@DriverDepartTime", SqlDbType.DateTime);

                    // If pizzaOrder.DriverDepartTime does not exist.
                    if (pizzaOrder.DriverDepartTime.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = pizzaOrder.DriverDepartTime;
                    }

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Filled]
                    param = new SqlParameter("@Filled", pizzaOrder.Filled);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [OrderDate]
                    // Create [OrderDate] Parameter
                    param = new SqlParameter("@OrderDate", SqlDbType.DateTime);

                    // If pizzaOrder.OrderDate does not exist.
                    if (pizzaOrder.OrderDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = pizzaOrder.OrderDate;
                    }

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [OrderType]
                    param = new SqlParameter("@OrderType", pizzaOrder.OrderType);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", pizzaOrder.Id);
                    parameters[5] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdatePizzaOrderStoredProcedure(PizzaOrder pizzaOrder)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdatePizzaOrderStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'PizzaOrder_Update'.
            /// </summary>
            /// <param name="pizzaOrder"The 'PizzaOrder' object to update</param>
            /// <returns>An instance of a 'UpdatePizzaOrderStoredProcedure</returns>
            public static UpdatePizzaOrderStoredProcedure CreateUpdatePizzaOrderStoredProcedure(PizzaOrder pizzaOrder)
            {
                // Initial Value
                UpdatePizzaOrderStoredProcedure updatePizzaOrderStoredProcedure = null;

                // verify pizzaOrder exists
                if(pizzaOrder != null)
                {
                    // Instanciate updatePizzaOrderStoredProcedure
                    updatePizzaOrderStoredProcedure = new UpdatePizzaOrderStoredProcedure();

                    // Now create parameters for this procedure
                    updatePizzaOrderStoredProcedure.Parameters = CreateUpdateParameters(pizzaOrder);
                }

                // return value
                return updatePizzaOrderStoredProcedure;
            }
            #endregion

            #region CreateFetchAllPizzaOrdersStoredProcedure(PizzaOrder pizzaOrder)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllPizzaOrdersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'PizzaOrder_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllPizzaOrdersStoredProcedure' object.</returns>
            public static FetchAllPizzaOrdersStoredProcedure CreateFetchAllPizzaOrdersStoredProcedure(PizzaOrder pizzaOrder)
            {
                // Initial value
                FetchAllPizzaOrdersStoredProcedure fetchAllPizzaOrdersStoredProcedure = new FetchAllPizzaOrdersStoredProcedure();

                // return value
                return fetchAllPizzaOrdersStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}

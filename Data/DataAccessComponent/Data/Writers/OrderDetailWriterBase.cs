

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

    #region class OrderDetailWriterBase
    /// <summary>
    /// This class is used for converting a 'OrderDetail' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class OrderDetailWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(OrderDetail orderDetail)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='orderDetail'>The 'OrderDetail' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(OrderDetail orderDetail)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (orderDetail != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", orderDetail.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteOrderDetailStoredProcedure(OrderDetail orderDetail)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteOrderDetail'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'OrderDetail_Delete'.
            /// </summary>
            /// <param name="orderDetail">The 'OrderDetail' to Delete.</param>
            /// <returns>An instance of a 'DeleteOrderDetailStoredProcedure' object.</returns>
            public static DeleteOrderDetailStoredProcedure CreateDeleteOrderDetailStoredProcedure(OrderDetail orderDetail)
            {
                // Initial Value
                DeleteOrderDetailStoredProcedure deleteOrderDetailStoredProcedure = new DeleteOrderDetailStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteOrderDetailStoredProcedure.Parameters = CreatePrimaryKeyParameter(orderDetail);

                // return value
                return deleteOrderDetailStoredProcedure;
            }
            #endregion

            #region CreateFindOrderDetailStoredProcedure(OrderDetail orderDetail)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindOrderDetailStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'OrderDetail_Find'.
            /// </summary>
            /// <param name="orderDetail">The 'OrderDetail' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindOrderDetailStoredProcedure CreateFindOrderDetailStoredProcedure(OrderDetail orderDetail)
            {
                // Initial Value
                FindOrderDetailStoredProcedure findOrderDetailStoredProcedure = null;

                // verify orderDetail exists
                if(orderDetail != null)
                {
                    // Instanciate findOrderDetailStoredProcedure
                    findOrderDetailStoredProcedure = new FindOrderDetailStoredProcedure();

                    // Now create parameters for this procedure
                    findOrderDetailStoredProcedure.Parameters = CreatePrimaryKeyParameter(orderDetail);
                }

                // return value
                return findOrderDetailStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(OrderDetail orderDetail)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new orderDetail.
            /// </summary>
            /// <param name="orderDetail">The 'OrderDetail' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(OrderDetail orderDetail)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[6];
                SqlParameter param = null;

                // verify orderDetailexists
                if(orderDetail != null)
                {
                    // Create [GroundBeef] parameter
                    param = new SqlParameter("@GroundBeef", orderDetail.GroundBeef);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Pepperoni] parameter
                    param = new SqlParameter("@Pepperoni", orderDetail.Pepperoni);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [PizzaOrderId] parameter
                    param = new SqlParameter("@PizzaOrderId", orderDetail.PizzaOrderId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Price] parameter
                    param = new SqlParameter("@Price", orderDetail.Price);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [Quantity] parameter
                    param = new SqlParameter("@Quantity", orderDetail.Quantity);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [Sausage] parameter
                    param = new SqlParameter("@Sausage", orderDetail.Sausage);

                    // set parameters[5]
                    parameters[5] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertOrderDetailStoredProcedure(OrderDetail orderDetail)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertOrderDetailStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'OrderDetail_Insert'.
            /// </summary>
            /// <param name="orderDetail"The 'OrderDetail' object to insert</param>
            /// <returns>An instance of a 'InsertOrderDetailStoredProcedure' object.</returns>
            public static InsertOrderDetailStoredProcedure CreateInsertOrderDetailStoredProcedure(OrderDetail orderDetail)
            {
                // Initial Value
                InsertOrderDetailStoredProcedure insertOrderDetailStoredProcedure = null;

                // verify orderDetail exists
                if(orderDetail != null)
                {
                    // Instanciate insertOrderDetailStoredProcedure
                    insertOrderDetailStoredProcedure = new InsertOrderDetailStoredProcedure();

                    // Now create parameters for this procedure
                    insertOrderDetailStoredProcedure.Parameters = CreateInsertParameters(orderDetail);
                }

                // return value
                return insertOrderDetailStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(OrderDetail orderDetail)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing orderDetail.
            /// </summary>
            /// <param name="orderDetail">The 'OrderDetail' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(OrderDetail orderDetail)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[7];
                SqlParameter param = null;

                // verify orderDetailexists
                if(orderDetail != null)
                {
                    // Create parameter for [GroundBeef]
                    param = new SqlParameter("@GroundBeef", orderDetail.GroundBeef);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Pepperoni]
                    param = new SqlParameter("@Pepperoni", orderDetail.Pepperoni);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [PizzaOrderId]
                    param = new SqlParameter("@PizzaOrderId", orderDetail.PizzaOrderId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Price]
                    param = new SqlParameter("@Price", orderDetail.Price);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Quantity]
                    param = new SqlParameter("@Quantity", orderDetail.Quantity);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Sausage]
                    param = new SqlParameter("@Sausage", orderDetail.Sausage);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", orderDetail.Id);
                    parameters[6] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateOrderDetailStoredProcedure(OrderDetail orderDetail)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateOrderDetailStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'OrderDetail_Update'.
            /// </summary>
            /// <param name="orderDetail"The 'OrderDetail' object to update</param>
            /// <returns>An instance of a 'UpdateOrderDetailStoredProcedure</returns>
            public static UpdateOrderDetailStoredProcedure CreateUpdateOrderDetailStoredProcedure(OrderDetail orderDetail)
            {
                // Initial Value
                UpdateOrderDetailStoredProcedure updateOrderDetailStoredProcedure = null;

                // verify orderDetail exists
                if(orderDetail != null)
                {
                    // Instanciate updateOrderDetailStoredProcedure
                    updateOrderDetailStoredProcedure = new UpdateOrderDetailStoredProcedure();

                    // Now create parameters for this procedure
                    updateOrderDetailStoredProcedure.Parameters = CreateUpdateParameters(orderDetail);
                }

                // return value
                return updateOrderDetailStoredProcedure;
            }
            #endregion

            #region CreateFetchAllOrderDetailsStoredProcedure(OrderDetail orderDetail)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllOrderDetailsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'OrderDetail_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllOrderDetailsStoredProcedure' object.</returns>
            public static FetchAllOrderDetailsStoredProcedure CreateFetchAllOrderDetailsStoredProcedure(OrderDetail orderDetail)
            {
                // Initial value
                FetchAllOrderDetailsStoredProcedure fetchAllOrderDetailsStoredProcedure = new FetchAllOrderDetailsStoredProcedure();

                // return value
                return fetchAllOrderDetailsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}

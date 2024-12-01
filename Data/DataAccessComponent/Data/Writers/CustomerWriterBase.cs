

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

    #region class CustomerWriterBase
    /// <summary>
    /// This class is used for converting a 'Customer' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class CustomerWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Customer customer)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='customer'>The 'Customer' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Customer customer)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (customer != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", customer.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteCustomerStoredProcedure(Customer customer)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteCustomer'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Customer_Delete'.
            /// </summary>
            /// <param name="customer">The 'Customer' to Delete.</param>
            /// <returns>An instance of a 'DeleteCustomerStoredProcedure' object.</returns>
            public static DeleteCustomerStoredProcedure CreateDeleteCustomerStoredProcedure(Customer customer)
            {
                // Initial Value
                DeleteCustomerStoredProcedure deleteCustomerStoredProcedure = new DeleteCustomerStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteCustomerStoredProcedure.Parameters = CreatePrimaryKeyParameter(customer);

                // return value
                return deleteCustomerStoredProcedure;
            }
            #endregion

            #region CreateFindCustomerStoredProcedure(Customer customer)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindCustomerStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Customer_Find'.
            /// </summary>
            /// <param name="customer">The 'Customer' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindCustomerStoredProcedure CreateFindCustomerStoredProcedure(Customer customer)
            {
                // Initial Value
                FindCustomerStoredProcedure findCustomerStoredProcedure = null;

                // verify customer exists
                if(customer != null)
                {
                    // Instanciate findCustomerStoredProcedure
                    findCustomerStoredProcedure = new FindCustomerStoredProcedure();

                    // Now create parameters for this procedure
                    findCustomerStoredProcedure.Parameters = CreatePrimaryKeyParameter(customer);
                }

                // return value
                return findCustomerStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Customer customer)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new customer.
            /// </summary>
            /// <param name="customer">The 'Customer' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Customer customer)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[7];
                SqlParameter param = null;

                // verify customerexists
                if(customer != null)
                {
                    // Create [Address] parameter
                    param = new SqlParameter("@Address", customer.Address);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [City] parameter
                    param = new SqlParameter("@City", customer.City);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", customer.Name);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [PhoneNumber] parameter
                    param = new SqlParameter("@PhoneNumber", customer.PhoneNumber);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [State] parameter
                    param = new SqlParameter("@State", customer.State);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [VIPClub] parameter
                    param = new SqlParameter("@VIPClub", customer.VIPClub);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [ZipCode] parameter
                    param = new SqlParameter("@ZipCode", customer.ZipCode);

                    // set parameters[6]
                    parameters[6] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertCustomerStoredProcedure(Customer customer)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertCustomerStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Customer_Insert'.
            /// </summary>
            /// <param name="customer"The 'Customer' object to insert</param>
            /// <returns>An instance of a 'InsertCustomerStoredProcedure' object.</returns>
            public static InsertCustomerStoredProcedure CreateInsertCustomerStoredProcedure(Customer customer)
            {
                // Initial Value
                InsertCustomerStoredProcedure insertCustomerStoredProcedure = null;

                // verify customer exists
                if(customer != null)
                {
                    // Instanciate insertCustomerStoredProcedure
                    insertCustomerStoredProcedure = new InsertCustomerStoredProcedure();

                    // Now create parameters for this procedure
                    insertCustomerStoredProcedure.Parameters = CreateInsertParameters(customer);
                }

                // return value
                return insertCustomerStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Customer customer)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing customer.
            /// </summary>
            /// <param name="customer">The 'Customer' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Customer customer)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[8];
                SqlParameter param = null;

                // verify customerexists
                if(customer != null)
                {
                    // Create parameter for [Address]
                    param = new SqlParameter("@Address", customer.Address);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [City]
                    param = new SqlParameter("@City", customer.City);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", customer.Name);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [PhoneNumber]
                    param = new SqlParameter("@PhoneNumber", customer.PhoneNumber);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [State]
                    param = new SqlParameter("@State", customer.State);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [VIPClub]
                    param = new SqlParameter("@VIPClub", customer.VIPClub);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [ZipCode]
                    param = new SqlParameter("@ZipCode", customer.ZipCode);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", customer.Id);
                    parameters[7] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateCustomerStoredProcedure(Customer customer)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateCustomerStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Customer_Update'.
            /// </summary>
            /// <param name="customer"The 'Customer' object to update</param>
            /// <returns>An instance of a 'UpdateCustomerStoredProcedure</returns>
            public static UpdateCustomerStoredProcedure CreateUpdateCustomerStoredProcedure(Customer customer)
            {
                // Initial Value
                UpdateCustomerStoredProcedure updateCustomerStoredProcedure = null;

                // verify customer exists
                if(customer != null)
                {
                    // Instanciate updateCustomerStoredProcedure
                    updateCustomerStoredProcedure = new UpdateCustomerStoredProcedure();

                    // Now create parameters for this procedure
                    updateCustomerStoredProcedure.Parameters = CreateUpdateParameters(customer);
                }

                // return value
                return updateCustomerStoredProcedure;
            }
            #endregion

            #region CreateFetchAllCustomersStoredProcedure(Customer customer)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllCustomersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Customer_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllCustomersStoredProcedure' object.</returns>
            public static FetchAllCustomersStoredProcedure CreateFetchAllCustomersStoredProcedure(Customer customer)
            {
                // Initial value
                FetchAllCustomersStoredProcedure fetchAllCustomersStoredProcedure = new FetchAllCustomersStoredProcedure();

                // return value
                return fetchAllCustomersStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}

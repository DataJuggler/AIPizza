
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

    #region class CustomerWriter
    /// <summary>
    /// This class is used for converting a 'Customer' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class CustomerWriter : CustomerWriterBase
    {

        #region Static Methods

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
            public static new FindCustomerStoredProcedure CreateFindCustomerStoredProcedure(Customer customer)
            {
                // Initial Value
                FindCustomerStoredProcedure findCustomerStoredProcedure = null;

                // verify customer exists
                if(customer != null)
                {
                    // Instanciate findCustomerStoredProcedure
                    findCustomerStoredProcedure = new FindCustomerStoredProcedure();

                    // if customer.FindByPhoneNumber is true
                    if (customer.FindByPhoneNumber)
                    {
                            // Change the procedure name
                            findCustomerStoredProcedure.ProcedureName = "Customer_FindByPhoneNumber";
                            
                            // Create the @PhoneNumber parameter
                            findCustomerStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@PhoneNumber", customer.PhoneNumber);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findCustomerStoredProcedure.Parameters = CreatePrimaryKeyParameter(customer);
                    }
                }

                // return value
                return findCustomerStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}

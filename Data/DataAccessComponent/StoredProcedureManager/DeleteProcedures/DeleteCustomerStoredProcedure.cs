

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteCustomerStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Customer' object.
    /// </summary>
    public class DeleteCustomerStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteCustomerStoredProcedure' object.
        /// </summary>
        public DeleteCustomerStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "Customer_Delete";

                // Set tableName
                this.TableName = "Customer";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}

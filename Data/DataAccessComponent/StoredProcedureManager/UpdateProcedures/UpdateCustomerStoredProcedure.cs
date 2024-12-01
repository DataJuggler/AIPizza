

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateCustomerStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Customer' object.
    /// </summary>
    public class UpdateCustomerStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateCustomerStoredProcedure' object.
        /// </summary>
        public UpdateCustomerStoredProcedure()
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
                this.ProcedureName = "Customer_Update";

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

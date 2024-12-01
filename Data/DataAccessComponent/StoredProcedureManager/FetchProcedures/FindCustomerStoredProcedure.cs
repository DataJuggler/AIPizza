

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindCustomerStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Customer' object.
    /// </summary>
    public class FindCustomerStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindCustomerStoredProcedure' object.
        /// </summary>
        public FindCustomerStoredProcedure()
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
                this.ProcedureName = "Customer_Find";

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

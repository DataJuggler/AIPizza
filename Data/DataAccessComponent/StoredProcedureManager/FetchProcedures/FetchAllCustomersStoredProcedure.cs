

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllCustomersStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Customer' objects.
    /// </summary>
    public class FetchAllCustomersStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllCustomersStoredProcedure' object.
        /// </summary>
        public FetchAllCustomersStoredProcedure()
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
                this.ProcedureName = "Customer_FetchAll";

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

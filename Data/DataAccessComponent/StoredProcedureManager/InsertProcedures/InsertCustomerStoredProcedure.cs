

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertCustomerStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Customer' object.
    /// </summary>
    public class InsertCustomerStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertCustomerStoredProcedure' object.
        /// </summary>
        public InsertCustomerStoredProcedure()
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
                this.ProcedureName = "Customer_Insert";

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

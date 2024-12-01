

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllOrderDetailsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'OrderDetail' objects.
    /// </summary>
    public class FetchAllOrderDetailsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllOrderDetailsStoredProcedure' object.
        /// </summary>
        public FetchAllOrderDetailsStoredProcedure()
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
                this.ProcedureName = "OrderDetail_FetchAll";

                // Set tableName
                this.TableName = "OrderDetail";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}

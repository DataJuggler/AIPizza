

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindOrderDetailStoredProcedure
    /// <summary>
    /// This class is used to Find a 'OrderDetail' object.
    /// </summary>
    public class FindOrderDetailStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindOrderDetailStoredProcedure' object.
        /// </summary>
        public FindOrderDetailStoredProcedure()
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
                this.ProcedureName = "OrderDetail_Find";

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

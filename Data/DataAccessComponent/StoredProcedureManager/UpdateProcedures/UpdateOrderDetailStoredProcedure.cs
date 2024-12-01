

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateOrderDetailStoredProcedure
    /// <summary>
    /// This class is used to Update a 'OrderDetail' object.
    /// </summary>
    public class UpdateOrderDetailStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateOrderDetailStoredProcedure' object.
        /// </summary>
        public UpdateOrderDetailStoredProcedure()
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
                this.ProcedureName = "OrderDetail_Update";

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

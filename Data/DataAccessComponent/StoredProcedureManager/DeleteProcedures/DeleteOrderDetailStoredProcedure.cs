

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteOrderDetailStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'OrderDetail' object.
    /// </summary>
    public class DeleteOrderDetailStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteOrderDetailStoredProcedure' object.
        /// </summary>
        public DeleteOrderDetailStoredProcedure()
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
                this.ProcedureName = "OrderDetail_Delete";

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

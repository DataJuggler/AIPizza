

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertOrderDetailStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'OrderDetail' object.
    /// </summary>
    public class InsertOrderDetailStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertOrderDetailStoredProcedure' object.
        /// </summary>
        public InsertOrderDetailStoredProcedure()
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
                this.ProcedureName = "OrderDetail_Insert";

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

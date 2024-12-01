

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeletePizzaOrderStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'PizzaOrder' object.
    /// </summary>
    public class DeletePizzaOrderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeletePizzaOrderStoredProcedure' object.
        /// </summary>
        public DeletePizzaOrderStoredProcedure()
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
                this.ProcedureName = "PizzaOrder_Delete";

                // Set tableName
                this.TableName = "PizzaOrder";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}

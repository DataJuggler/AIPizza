

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdatePizzaOrderStoredProcedure
    /// <summary>
    /// This class is used to Update a 'PizzaOrder' object.
    /// </summary>
    public class UpdatePizzaOrderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdatePizzaOrderStoredProcedure' object.
        /// </summary>
        public UpdatePizzaOrderStoredProcedure()
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
                this.ProcedureName = "PizzaOrder_Update";

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

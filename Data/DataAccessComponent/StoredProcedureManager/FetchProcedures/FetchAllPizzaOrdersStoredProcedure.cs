

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllPizzaOrdersStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'PizzaOrder' objects.
    /// </summary>
    public class FetchAllPizzaOrdersStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllPizzaOrdersStoredProcedure' object.
        /// </summary>
        public FetchAllPizzaOrdersStoredProcedure()
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
                this.ProcedureName = "PizzaOrder_FetchAll";

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

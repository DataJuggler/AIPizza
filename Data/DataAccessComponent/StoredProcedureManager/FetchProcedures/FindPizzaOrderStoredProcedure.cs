

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindPizzaOrderStoredProcedure
    /// <summary>
    /// This class is used to Find a 'PizzaOrder' object.
    /// </summary>
    public class FindPizzaOrderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindPizzaOrderStoredProcedure' object.
        /// </summary>
        public FindPizzaOrderStoredProcedure()
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
                this.ProcedureName = "PizzaOrder_Find";

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



namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertPizzaOrderStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'PizzaOrder' object.
    /// </summary>
    public class InsertPizzaOrderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertPizzaOrderStoredProcedure' object.
        /// </summary>
        public InsertPizzaOrderStoredProcedure()
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
                this.ProcedureName = "PizzaOrder_Insert";

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

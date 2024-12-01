

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class PizzaOrder
    [Serializable]
    public partial class PizzaOrder
    {

        #region Private Variables
        #endregion

        #region Constructor
        public PizzaOrder()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public PizzaOrder Clone()
            {
                // Create New Object
                PizzaOrder newPizzaOrder = (PizzaOrder) this.MemberwiseClone();

                // Return Cloned Object
                return newPizzaOrder;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}

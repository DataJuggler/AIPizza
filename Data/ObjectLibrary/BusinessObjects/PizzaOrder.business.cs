

#region using statements

using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class PizzaOrder
    [Serializable]
    public partial class PizzaOrder
    {

        #region Private Variables
        private List<OrderDetail> details;
        #endregion

        #region Constructor
        public PizzaOrder()
        {
            // Create a new collection of 'OrderDetail' objects.
            Details = new List<OrderDetail>();
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

            #region Details
            /// <summary>
            /// This property gets or sets the value for 'Details'.
            /// </summary>
            public List<OrderDetail> Details
            {
                get { return details; }
                set { details = value; }
            }
            #endregion
            
            #region HasDetails
            /// <summary>
            /// This property returns true if this object has a 'Details'.
            /// </summary>
            public bool HasDetails
            {
                get
                {
                    // initial value
                    bool hasDetails = (this.Details != null);
                    
                    // return value
                    return hasDetails;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

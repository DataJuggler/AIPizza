

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class OrderDetail
    [Serializable]
    public partial class OrderDetail
    {

        #region Private Variables
        #endregion

        #region Constructor
        public OrderDetail()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public OrderDetail Clone()
            {
                // Create New Object
                OrderDetail newOrderDetail = (OrderDetail) this.MemberwiseClone();

                // Return Cloned Object
                return newOrderDetail;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}



#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class PizzaOrder
    public partial class PizzaOrder
    {

        #region Private Variables
        private int customerId;
        private DateTime driverDepartTime;
        private bool filled;
        private int id;
        private DateTime orderDate;
        private int orderType;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int CustomerId
            public int CustomerId
            {
                get
                {
                    return customerId;
                }
                set
                {
                    customerId = value;
                }
            }
            #endregion

            #region DateTime DriverDepartTime
            public DateTime DriverDepartTime
            {
                get
                {
                    return driverDepartTime;
                }
                set
                {
                    driverDepartTime = value;
                }
            }
            #endregion

            #region bool Filled
            public bool Filled
            {
                get
                {
                    return filled;
                }
                set
                {
                    filled = value;
                }
            }
            #endregion

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region DateTime OrderDate
            public DateTime OrderDate
            {
                get
                {
                    return orderDate;
                }
                set
                {
                    orderDate = value;
                }
            }
            #endregion

            #region int OrderType
            public int OrderType
            {
                get
                {
                    return orderType;
                }
                set
                {
                    orderType = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}

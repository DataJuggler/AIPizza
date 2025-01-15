﻿

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region enum OrderTypeEnum : int
    /// <summary>
    /// The type of Order
    /// </summary>
    public enum OrderTypeEnum : int
    {
        Dine_In = 0,
        Pick_Up = 1,
        Delivery = 2        
    }
    #endregion

    #region enum ScreenTypeEnum : int
    /// <summary>
    /// The choices for the Home Page
    /// </summary>
    public enum ScreenTypeEnum : int
    {
        Default = 0,
        NewOrder = 1,
        ExistingOrder = 2,
        EditOrder = 3,
        FindCustomer = 4,
        NewCustomer = 5,
        EditCustomer = 6
    }
    #endregion

}
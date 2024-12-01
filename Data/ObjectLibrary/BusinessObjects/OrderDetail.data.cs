

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class OrderDetail
    public partial class OrderDetail
    {

        #region Private Variables
        private bool groundBeef;
        private int id;
        private bool pepperoni;
        private int pizzaOrderId;
        private double price;
        private int quantity;
        private bool sausage;
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

            #region bool GroundBeef
            public bool GroundBeef
            {
                get
                {
                    return groundBeef;
                }
                set
                {
                    groundBeef = value;
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

            #region bool Pepperoni
            public bool Pepperoni
            {
                get
                {
                    return pepperoni;
                }
                set
                {
                    pepperoni = value;
                }
            }
            #endregion

            #region int PizzaOrderId
            public int PizzaOrderId
            {
                get
                {
                    return pizzaOrderId;
                }
                set
                {
                    pizzaOrderId = value;
                }
            }
            #endregion

            #region double Price
            public double Price
            {
                get
                {
                    return price;
                }
                set
                {
                    price = value;
                }
            }
            #endregion

            #region int Quantity
            public int Quantity
            {
                get
                {
                    return quantity;
                }
                set
                {
                    quantity = value;
                }
            }
            #endregion

            #region bool Sausage
            public bool Sausage
            {
                get
                {
                    return sausage;
                }
                set
                {
                    sausage = value;
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

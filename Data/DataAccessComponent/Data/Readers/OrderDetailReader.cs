

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class OrderDetailReader
    /// <summary>
    /// This class loads a single 'OrderDetail' object or a list of type <OrderDetail>.
    /// </summary>
    public class OrderDetailReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'OrderDetail' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'OrderDetail' DataObject.</returns>
            public static OrderDetail Load(DataRow dataRow)
            {
                // Initial Value
                OrderDetail orderDetail = new OrderDetail();

                // Create field Integers
                int groundBeeffield = 0;
                int idfield = 1;
                int pepperonifield = 2;
                int pizzaOrderIdfield = 3;
                int pricefield = 4;
                int quantityfield = 5;
                int sausagefield = 6;

                try
                {
                    // Load Each field
                    orderDetail.GroundBeef = DataHelper.ParseBoolean(dataRow.ItemArray[groundBeeffield], false);
                    orderDetail.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    orderDetail.Pepperoni = DataHelper.ParseBoolean(dataRow.ItemArray[pepperonifield], false);
                    orderDetail.PizzaOrderId = DataHelper.ParseInteger(dataRow.ItemArray[pizzaOrderIdfield], 0);
                    orderDetail.Price = DataHelper.ParseDouble(dataRow.ItemArray[pricefield], 0);
                    orderDetail.Quantity = DataHelper.ParseInteger(dataRow.ItemArray[quantityfield], 0);
                    orderDetail.Sausage = DataHelper.ParseBoolean(dataRow.ItemArray[sausagefield], false);
                }
                catch
                {
                }

                // return value
                return orderDetail;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'OrderDetail' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A OrderDetail Collection.</returns>
            public static List<OrderDetail> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<OrderDetail> orderDetails = new List<OrderDetail>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'OrderDetail' from rows
                        OrderDetail orderDetail = Load(row);

                        // Add this object to collection
                        orderDetails.Add(orderDetail);
                    }
                }
                catch
                {
                }

                // return value
                return orderDetails;
            }
            #endregion

        #endregion

    }
    #endregion

}

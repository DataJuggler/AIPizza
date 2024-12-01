

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class PizzaOrderReader
    /// <summary>
    /// This class loads a single 'PizzaOrder' object or a list of type <PizzaOrder>.
    /// </summary>
    public class PizzaOrderReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'PizzaOrder' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'PizzaOrder' DataObject.</returns>
            public static PizzaOrder Load(DataRow dataRow)
            {
                // Initial Value
                PizzaOrder pizzaOrder = new PizzaOrder();

                // Create field Integers
                int customerIdfield = 0;
                int driverDepartTimefield = 1;
                int filledfield = 2;
                int idfield = 3;
                int orderDatefield = 4;
                int orderTypefield = 5;

                try
                {
                    // Load Each field
                    pizzaOrder.CustomerId = DataHelper.ParseInteger(dataRow.ItemArray[customerIdfield], 0);
                    pizzaOrder.DriverDepartTime = DataHelper.ParseDate(dataRow.ItemArray[driverDepartTimefield]);
                    pizzaOrder.Filled = DataHelper.ParseBoolean(dataRow.ItemArray[filledfield], false);
                    pizzaOrder.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    pizzaOrder.OrderDate = DataHelper.ParseDate(dataRow.ItemArray[orderDatefield]);
                    pizzaOrder.OrderType = (OrderTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[orderTypefield], 0);
                }
                catch
                {
                }

                // return value
                return pizzaOrder;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'PizzaOrder' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A PizzaOrder Collection.</returns>
            public static List<PizzaOrder> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<PizzaOrder> pizzaOrders = new List<PizzaOrder>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'PizzaOrder' from rows
                        PizzaOrder pizzaOrder = Load(row);

                        // Add this object to collection
                        pizzaOrders.Add(pizzaOrder);
                    }
                }
                catch
                {
                }

                // return value
                return pizzaOrders;
            }
            #endregion

        #endregion

    }
    #endregion

}

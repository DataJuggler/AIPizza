

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class CustomerReader
    /// <summary>
    /// This class loads a single 'Customer' object or a list of type <Customer>.
    /// </summary>
    public class CustomerReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Customer' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Customer' DataObject.</returns>
            public static Customer Load(DataRow dataRow)
            {
                // Initial Value
                Customer customer = new Customer();

                // Create field Integers
                int addressfield = 0;
                int cityfield = 1;
                int idfield = 2;
                int namefield = 3;
                int phoneNumberfield = 4;
                int statefield = 5;
                int vIPClubfield = 6;
                int zipCodefield = 7;

                try
                {
                    // Load Each field
                    customer.Address = DataHelper.ParseString(dataRow.ItemArray[addressfield]);
                    customer.City = DataHelper.ParseString(dataRow.ItemArray[cityfield]);
                    customer.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    customer.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    customer.PhoneNumber = DataHelper.ParseString(dataRow.ItemArray[phoneNumberfield]);
                    customer.State = DataHelper.ParseString(dataRow.ItemArray[statefield]);
                    customer.VIPClub = DataHelper.ParseBoolean(dataRow.ItemArray[vIPClubfield], false);
                    customer.ZipCode = DataHelper.ParseString(dataRow.ItemArray[zipCodefield]);
                }
                catch
                {
                }

                // return value
                return customer;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Customer' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Customer Collection.</returns>
            public static List<Customer> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Customer> customers = new List<Customer>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Customer' from rows
                        Customer customer = Load(row);

                        // Add this object to collection
                        customers.Add(customer);
                    }
                }
                catch
                {
                }

                // return value
                return customers;
            }
            #endregion

        #endregion

    }
    #endregion

}

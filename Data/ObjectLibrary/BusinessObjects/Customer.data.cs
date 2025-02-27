

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Customer
    public partial class Customer
    {

        #region Private Variables
        private string address;
        private string city;
        private int id;
        private string name;
        private string phoneNumber;
        private string state;
        private bool vIPClub;
        private string zipCode;
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

            #region string Address
            public string Address
            {
                get
                {
                    return address;
                }
                set
                {
                    address = value;
                }
            }
            #endregion

            #region string City
            public string City
            {
                get
                {
                    return city;
                }
                set
                {
                    city = value;
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

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion

            #region string PhoneNumber
            public string PhoneNumber
            {
                get
                {
                    return phoneNumber;
                }
                set
                {
                    phoneNumber = value;
                }
            }
            #endregion

            #region string State
            public string State
            {
                get
                {
                    return state;
                }
                set
                {
                    state = value;
                }
            }
            #endregion

            #region bool VIPClub
            public bool VIPClub
            {
                get
                {
                    return vIPClub;
                }
                set
                {
                    vIPClub = value;
                }
            }
            #endregion

            #region string ZipCode
            public string ZipCode
            {
                get
                {
                    return zipCode;
                }
                set
                {
                    zipCode = value;
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

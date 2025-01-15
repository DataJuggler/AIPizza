
#region using statements

using DataJuggler.UltimateHelper;
using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Customer
    [Serializable]
    public partial class Customer
    {

        #region Private Variables
        private bool findByPhoneNumber;
        #endregion

        #region Constructor
        public Customer()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Customer Clone()
            {
                // Create New Object
                Customer newCustomer = (Customer) this.MemberwiseClone();

                // Return Cloned Object
                return newCustomer;
            }
            #endregion

             #region IsValid(ref string invalidReason)
            /// <summary>
            /// returns the Valid
            /// </summary>
            public bool IsValid(ref string invalidReason)
            {
                // initial value
                bool isValid = false;

                // required fields
                bool hasName = !String.IsNullOrEmpty(Name);

                // validate
                isValid = hasName;

                // if the value for isValid is false
                if (!isValid)
                {
                    // if the value for hasName is false
                    if (!hasName)
                    {
                        // Add to the invalidReason
                        invalidReason += "Name is required.";
                    }

                    // if the phoneNumber exists
                    if (TextHelper.Exists(PhoneNumber))
                    {
                        // if the phone number has a 1, remove it
                        if (phoneNumber.StartsWith("1"))
                        {
                            // Remove the first char
                            phoneNumber = phoneNumber.Substring(1);
                        }

                        // Only validate if they enter one
                        isValid = phoneNumber.Length == 10;

                        // if not valid
                        if (!isValid)
                        {
                            // Add to the invalidReason
                            invalidReason += "Phone number be 10 digits";
                        }
                    }
                }
                
                // return value
                return isValid;
            }
            #endregion

        #endregion

        #region Properties

            #region FindByPhoneNumber
            /// <summary>
            /// This property gets or sets the value for 'FindByPhoneNumber'.
            /// </summary>
            public bool FindByPhoneNumber
            {
                get { return findByPhoneNumber; }
                set { findByPhoneNumber = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}

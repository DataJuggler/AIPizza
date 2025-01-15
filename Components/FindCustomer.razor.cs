

#region using statements

using AIPizza.Components.Pages;
using DataAccessComponent.Connection;
using DataAccessComponent.DataGateway;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;

#endregion

namespace AIPizza.Components
{

    #region class FindCustomer
    /// <summary>
    /// This class is used to Find a Customer
    /// </summary>
    public partial class FindCustomer : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        private TextBoxComponent phoneComponent;
        private List<IBlazorComponent> children;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
        
            #region Cancel()
            /// <summary>
            /// Cancel
            /// </summary>
            public void Cancel()
            {
                if (HasParentHomePage)
                {
                    // Cancel the FIndCustomer activity
                    ParentHomePage.Cancel();
                }
            }
            #endregion

            #region LookupCustomer()
            /// <summary>
            /// Lookup Customer
            /// </summary>
            public void LookupCustomer()
            {
                // if the value for HasPhoneComponent is true
                if ((HasPhoneComponent) && (HasParentHomePage))
                {
                    // Get the text
                    string phoneNumber = PhoneComponent.Text;

                    // If the phoneNumber string exists
                    if (TextHelper.Exists(phoneNumber))
                    {
                        // Create a new instance of a 'Gateway' object.
                        Gateway gateway = new Gateway(ConnectionConstants.Name);

                        // Find the Customer
                        ParentHomePage.CurrentCustomer = gateway.FindCustomerByPhoneNumber(phoneNumber);

                        if (ParentHomePage.HasCurrentCustomer)
                        {
                            // Display the CurrentCustomer
                            ParentHomePage.DisplayCustomer();

                            // Back to NewOrder
                            ParentHomePage.ScreenType = ScreenTypeEnum.NewOrder;

                            // Update the Screen
                            ParentHomePage.Refresh();
                        }
                        else
                        {
                            // Show a message
                            ParentHomePage.DisplayMessage("Customer Not Found.");
                        }
                    }
                    else
                    {
                        // if the value for HasParentHomePage is true
                        if (HasParentHomePage)
                        {
                            // Display a message
                            ParentHomePage.DisplayMessage("Phone Number is required.");
                        }
                    }
                }
            }
            #endregion
            
            #region NewCustomer()
            /// <summary>
            /// New Customer
            /// </summary>
            public void NewCustomer()
            {
                // if the value for HasParentHomePage is true
                if (HasParentHomePage)
                {
                    // Create a new instance of a 'ParentHomePage' object.
                    ParentHomePage.CurrentCustomer = new Customer();

                    // Change the ScreenType
                    ParentHomePage.ScreenType = ScreenTypeEnum.NewCustomer;

                    // Update the UI
                    ParentHomePage.Refresh();
                }
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // if Enter was pressed
                if (message.Text == "EnterPressed")
                {
                    // Click the Find button
                    LookupCustomer();
                }
            }
             #endregion

            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                InvokeAsync(() =>
                {
                    // Refresh
                    StateHasChanged();
                });
            }
            #endregion

            #region Register(IBlazorComponent component)
            /// <summary>
            /// method Register
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                if (component is TextBoxComponent tempComponent)
                {
                    if (component.Name == "PhoneControl")
                    {
                        // Use pattern matching to set PhoneComponent
                        PhoneComponent = tempComponent;
                    }
                }                           
            }
            #endregion

        #endregion

        #region Properties

            #region Children
            /// <summary>
            /// This property gets or sets the value for 'Children'.
            /// </summary>
            public List<IBlazorComponent> Children
            {
                get { return children; }
                set { children = value; }
            }
            #endregion
            
            #region HasChildren
            /// <summary>
            /// This property returns true if this object has a 'Children'.
            /// </summary>
            public bool HasChildren
            {
                get
                {
                    // initial value
                    bool hasChildren = (this.Children != null);
                    
                    // return value
                    return hasChildren;
                }
            }
            #endregion
            
            #region HasParent
            /// <summary>
            /// This property returns true if this object has a 'Parent'.
            /// </summary>
            public bool HasParent
            {
                get
                {
                    // initial value
                    bool hasParent = (this.Parent != null);
                    
                    // return value
                    return hasParent;
                }
            }
            #endregion
            
            #region HasParentHomePage
            /// <summary>
            /// This property returns true if this object has a 'ParentHomePage'.
            /// </summary>
            public bool HasParentHomePage
            {
                get
                {
                    // initial value
                    bool hasParentHomePage = (this.ParentHomePage != null);
                    
                    // return value
                    return hasParentHomePage;
                }
            }
            #endregion
            
            #region HasPhoneComponent
            /// <summary>
            /// This property returns true if this object has a 'PhoneComponent'.
            /// </summary>
            public bool HasPhoneComponent
            {
                get
                {
                    // initial value
                    bool hasPhoneComponent = (this.PhoneComponent != null);
                    
                    // return value
                    return hasPhoneComponent;
                }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
             #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get { return parent; }
                set
                {
                    // Set the value
                    parent = value;

                    // If the parent object exists
                    if (HasParent)
                    {
                        // Register this the parent
                        parent.Register(this);
                    }
                }
            }
            #endregion
            
            #region ParentHomePage
            /// <summary>
            /// This read only property returns the value of ParentHomePage from the object Parent.
            /// </summary>
            public Home ParentHomePage
            {
                
                get
                {
                    // initial value
                    Home parentHomePage = null;
                    
                    // if Parent exists
                    if (Parent is Home tempHome)
                    {
                        // set the return value
                        parentHomePage = tempHome;
                    }
                    
                    // return value
                    return parentHomePage;
                }
            }
            #endregion

            #region PhoneComponent
            /// <summary>
            /// This property gets or sets the value for 'PhoneComponent'.
            /// </summary>
            public TextBoxComponent PhoneComponent
            {
                get { return phoneComponent; }
                set { phoneComponent = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}

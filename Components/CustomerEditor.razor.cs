

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using AIPizza.Components.Pages;
using Microsoft.AspNetCore.Components;
using DataAccessComponent.DataGateway;
using DataAccessComponent.Connection;
using DataJuggler.UltimateHelper;

#endregion

namespace AIPizza.Components
{

    #region class CustomerEditor
    /// <summary>
    /// This class is used to create and edit Customer objects
    /// </summary>
    public partial class CustomerEditor : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private List<IBlazorComponent> children;
        private string name;
        private bool editMode;

        // Controls
        private TextBoxComponent nameControl;
        private TextBoxComponent addressControl;
        private TextBoxComponent cityControl;
        private TextBoxComponent stateControl;
        private TextBoxComponent zipControl;
        private TextBoxComponent phoneControl;
        private ToggleComponent vIPMemberComponent;
        private IBlazorComponentParent parent;
        #endregion
        
        #region Constructor
        public CustomerEditor()
        {
            // Create a new collection of 'IBlazorComponent' objects.
            Children = new List<IBlazorComponent>();

            // Set the Name
            Name = "CustomerEditor";
        }            
        #endregion
        
        #region Methods
            
            #region Cancel()
            /// <summary>
            /// Cancel
            /// </summary>
            public void Cancel()
            {
                // if the value for HasParentHomePage is true
                if (HasParentHomePage)
                {
                    // Perform Canccel
                    ParentHomePage.Cancel();

                    // Update the UI
                    ParentHomePage.Refresh();
                }
            }
            #endregion
            
            #region DisplayCustomer()
            /// <summary>
            /// Display Customer
            /// </summary>
            public async Task DisplayCustomer()
            {
                // if everything is set
                if ((HasCurrentCustomer) && (AllControlsRegistered))
                {
                    // Setup the component
                    NameControl.SetTextValue(CurrentCustomer.Name);
                    AddressControl.SetTextValue(CurrentCustomer.Address);
                    CityControl.SetTextValue(CurrentCustomer.City);
                    StateControl.SetTextValue("TX");
                    ZipControl.SetTextValue(CurrentCustomer.ZipCode);                    
                    PhoneControl.SetTextValue(TextHelper.FormatPhoneNumber(CurrentCustomer.PhoneNumber));
                    VIPMemberComponent.SetOnValue(CurrentCustomer.VIPClub);                    

                    // Simulating an async operation
                    await Task.FromResult(0);
                }                
            }
            #endregion
            
            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// method returns the After Render Async
            /// </summary>
            protected override async Task OnAfterRenderAsync(bool firstRender)
            {
                // if this is EditCustomer mode
                if (ScreenType == ScreenTypeEnum.EditCustomer)
                {
                    await DisplayCustomer();
                }
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                
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
                if (component is TextBoxComponent tempTextBox)
            {
                    _ = component.Name switch
                    {
                        "NameControl" => NameControl = tempTextBox,
                        "AddressControl" => AddressControl = tempTextBox,
                        "CityControl" => CityControl = tempTextBox,
                        "StateControl" => StateControl = tempTextBox,
                        "ZipControl" => ZipControl = tempTextBox,
                        "PhoneControl" => PhoneControl = tempTextBox,
                        _ => null
                    };
                }
                else if (component is ToggleComponent tempToggle)
                {  
                    // store
                    VIPMemberComponent = tempToggle;
                }
            }
            #endregion

            #region SaveCustomer()
            /// <summary>
            /// Save Customer
            /// </summary>
            public void SaveCustomer()
            {
                // locals
                Customer customer;
                string invalidReason = "";

                // if the value for HasParentHomePage is true
                if ((HasParentHomePage) && (ParentHomePage.HasCurrentCustomer))
                {  
                    // if All The Controls Are Registered
                    if (AllControlsRegistered)
                    {
                        // Get a local reference
                        customer = ParentHomePage.CurrentCustomer;
                       
                        // Store each property
                        customer.Address = AddressControl.Text;
                        customer.City = CityControl.Text;
                        customer.Name = NameControl.Text;
                        customer.PhoneNumber = NumericHelper.GetNumbersOnly(PhoneControl.Text);
                        customer.State = StateControl.Text;
                        customer.ZipCode = ZipControl.Text;
                        customer.VIPClub = VIPMemberComponent.On;

                        // Is this a valid Customer
                        bool isValid = customer.IsValid(ref invalidReason);

                        // if saved
                        if (isValid)
                        {
                            // Create a new instance of a 'Gateway' object.
                            Gateway gateway = new Gateway(ConnectionConstants.Name);

                            // Save the customer
                            bool saved = gateway.SaveCustomer(ref customer);

                            // if saved
                            if (saved)
                            {
                                // Create a new instance of a 'ParentHomePage' object.
                                ParentHomePage.CurrentCustomer = customer;

                                // Display the current customer
                                ParentHomePage.DisplayCustomer();

                                // Change the ScreenType
                                ParentHomePage.ScreenType = ScreenTypeEnum.NewOrder;

                                // Show a message
                                ParentHomePage.DisplayMessage("Customer Saved");
                            }
                            else
                            {
                                // Get the last exception
                                Exception error = gateway.GetLastException();

                                // If the error object exists
                                if (NullHelper.Exists(error))
                                {
                                    // Display Message
                                    ParentHomePage.DisplayMessage("An error occurred in 'Save Customer' method. Details: " + error.ToString());
                                }
                                else
                                {
                                    // Display Message
                                    ParentHomePage.DisplayMessage("An unknown error occurred in 'Save Customer' method");
                                }
                            }
                        }
                        else
                        {
                            // Display
                            ParentHomePage.DisplayMessage(invalidReason);
                        }
                    }
                    else
                    {
                        // Show a message
                        ParentHomePage.DisplayMessage("System Error - Not All Controls Are Registered In The Customer Editor");
                    }
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region AddressControl
            /// <summary>
            /// This property gets or sets the value for 'AddressControl'.
            /// </summary>
            public TextBoxComponent AddressControl
            {
                get { return addressControl; }
                set { addressControl = value; }
            }
            #endregion
            
            #region AllControlsRegistered
            /// <summary>
            /// This read only property returns the value for 'AllControlsRegistered'.
            /// </summary>
            public bool AllControlsRegistered
            {
                get
                {
                    // initial value
                    bool allRegistered = (HasAddressControl && HasCityControl && HasPhoneControl && HasStateControl &&
                                                    HasVIPMemberComponent && HasZipControl);
                    
                    // return value
                    return allRegistered;
                }
            }
            #endregion
            
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

            #region CityControl
            /// <summary>
            /// This property gets or sets the value for 'CityControl'.
            /// </summary>
            public TextBoxComponent CityControl
            {
                get { return cityControl; }
                set { cityControl = value; }
            }
            #endregion
            
            #region CurrentCustomer
            /// <summary>
            /// This read only property returns the value of CurrentCustomer from the object ParentHomePage.
            /// </summary>
            public Customer CurrentCustomer
            {
                
                get
                {
                    // initial value
                    Customer currentCustomer = null;
                    
                    // if ParentHomePage exists
                    if (HasParentHomePage)
                    {
                        // set the return value
                        currentCustomer = ParentHomePage.CurrentCustomer;
                    }
                    
                    // return value
                    return currentCustomer;
                }
            }
            #endregion
            
            #region EditMode
            /// <summary>
            /// This property gets or sets the value for 'EditMode'.
            /// </summary>
            public bool EditMode
            {
                get { return editMode; }
                set { editMode = value; }
            }
            #endregion
            
            #region HasAddressControl
            /// <summary>
            /// This property returns true if this object has an 'AddressControl'.
            /// </summary>
            public bool HasAddressControl
            {
                get
                {
                    // initial value
                    bool hasAddressControl = (this.AddressControl != null);
                    
                    // return value
                    return hasAddressControl;
                }
            }
            #endregion
            
            #region HasCityControl
            /// <summary>
            /// This property returns true if this object has a 'CityControl'.
            /// </summary>
            public bool HasCityControl
            {
                get
                {
                    // initial value
                    bool hasCityControl = (this.CityControl != null);
                    
                    // return value
                    return hasCityControl;
                }
            }
            #endregion
            
            #region HasCurrentCustomer
            /// <summary>
            /// This property returns true if this object has a 'CurrentCustomer'.
            /// </summary>
            public bool HasCurrentCustomer
            {
                get
                {
                    // initial value
                    bool hasCurrentCustomer = (this.CurrentCustomer != null);
                    
                    // return value
                    return hasCurrentCustomer;
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
            
            #region HasPhoneControl
            /// <summary>
            /// This property returns true if this object has a 'PhoneControl'.
            /// </summary>
            public bool HasPhoneControl
            {
                get
                {
                    // initial value
                    bool hasPhoneControl = (this.PhoneControl != null);
                    
                    // return value
                    return hasPhoneControl;
                }
            }
            #endregion
            
            #region HasStateControl
            /// <summary>
            /// This property returns true if this object has a 'StateControl'.
            /// </summary>
            public bool HasStateControl
            {
                get
                {
                    // initial value
                    bool hasStateControl = (this.StateControl != null);
                    
                    // return value
                    return hasStateControl;
                }
            }
            #endregion
            
            #region HasVIPMemberComponent
            /// <summary>
            /// This property returns true if this object has a 'VIPMemberComponent'.
            /// </summary>
            public bool HasVIPMemberComponent
            {
                get
                {
                    // initial value
                    bool hasVIPMemberComponent = (this.VIPMemberComponent != null);
                    
                    // return value
                    return hasVIPMemberComponent;
                }
            }
            #endregion

            #region HasZipControl
            /// <summary>
            /// This property returns true if this object has a 'ZipControl'.
            /// </summary>
            public bool HasZipControl
            {
                get
                {
                    // initial value
                    bool hasZipControl = (this.ZipControl != null);
                    
                    // return value
                    return hasZipControl;
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
            
            #region NameControl
            /// <summary>
            /// This property gets or sets the value for 'NameControl'.
            /// </summary>
            public TextBoxComponent NameControl
            {
                get { return nameControl; }
                set { nameControl = value; }
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
            
            #region PhoneControl
            /// <summary>
            /// This property gets or sets the value for 'PhoneControl'.
            /// </summary>
            public TextBoxComponent PhoneControl
            {
                get { return phoneControl; }
                set { phoneControl = value; }
            }
            #endregion
            
            #region ScreenType
            /// <summary>
            /// This read only property returns the value of ScreenType from the object ParentHomePage.
            /// </summary>
            public ScreenTypeEnum ScreenType
            {
                
                get
                {
                    // initial value
                    ScreenTypeEnum screenType = ScreenTypeEnum.Default;
                    
                    // if ParentHomePage exists
                    if (ParentHomePage != null)
                    {
                        // set the return value
                        screenType = ParentHomePage.ScreenType;
                    }
                    
                    // return value
                    return screenType;
                }
            }
            #endregion
            
            #region StateControl
            /// <summary>
            /// This property gets or sets the value for 'StateControl'.
            /// </summary>
            public TextBoxComponent StateControl
            {
                get { return stateControl; }
                set { stateControl = value; }
            }
            #endregion
            
            #region VIPMemberComponent
            /// <summary>
            /// This property gets or sets the value for 'VIPMemberComponent'.
            /// </summary>
            public ToggleComponent VIPMemberComponent
            {
                get { return vIPMemberComponent; }
                set { vIPMemberComponent = value; }
            }
            #endregion

            #region ZipControl
            /// <summary>
            /// This property gets or sets the value for 'ZipControl'.
            /// </summary>
            public TextBoxComponent ZipControl
            {
                get { return zipControl; }
                set { zipControl = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

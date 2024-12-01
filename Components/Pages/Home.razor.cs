

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataAccessComponent.Connection;
using DataAccessComponent.DataGateway;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using AIPizza.Components;
using DataJuggler.Blazor.Components.Enumerations;

#endregion

namespace AIPizza.Components.Pages
{

    #region class Home
    /// <summary>
    /// This class is the code behind for the Home Page.
    /// </summary>
    public partial class Home : IBlazorComponentParent
    {
        
        #region Private Variables
        private List<IBlazorComponent> children;
        private Customer currentCustomer;
        private ScreenTypeEnum screenType;           
        private Label statusLabel;
        private bool showStatusMessage;
        private CustomerEditor customerEditor;
        private InformationBox customerInfoBox;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'Home' object.
        /// </summary>
        public Home()
        {
            // Create a new collection of 'IBlazorComponent' objects.
            Children = new List<IBlazorComponent>();
        }
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
                // Reset
                ScreenType = ScreenTypeEnum.Default;
            }
            #endregion
            
            #region DisplayCustomer()
            /// <summary>
            /// Display Customer
            /// </summary>
            public void DisplayCustomer()
            {  
                if ((HasCurrentCustomer) && (HasCustomerInfoBox))
                {
                    // initial value
                    List<Item> items = new List<Item>();

                    // Create a new instance of an 'Item' object.
                    Item item = new Item();
                    item.Caption = "Name:";
                    item.Text = CurrentCustomer.Name;
                
                    // Add this item
                    items.Add(item);

                    // Create a new instance of an 'Item' object.
                    item = new Item();
                    item.Caption = "Address:";                    
                    item.Text = CurrentCustomer.Address;
                
                    // Add this item
                    items.Add(item);

                    // Create a new instance of an 'Item' object.
                    item = new Item();
                    item.Caption = "City Zip:";
                    item.Text = CurrentCustomer.City + ' ' + CurrentCustomer.ZipCode;
                
                    // Add this item
                    items.Add(item);

                    // Create a new instance of an 'Item' object.
                    item = new Item();
                    item.Caption = "Phone:";
                    item.Text = TextHelper.FormatPhoneNumber(CurrentCustomer.PhoneNumber);
                
                    // Add this item
                    items.Add(item);

                    // Create a new instance of an 'Item' object.
                    item = new Item();
                    item.Caption = "VIP Club:";
                    if (CurrentCustomer.VIPClub)
                    {
                        item.Text = "Yes";
                    }
                    else
                    {
                        item.Text = "No";
                    }
                
                    // Add this item
                    items.Add(item);

                    // Set the Items
                    CustomerInfoBox.Items = items;

                    // Update
                    CustomerInfoBox.Refresh();
                }
            }
            #endregion
            
            #region DisplayMessage(string messageText)
            /// <summary>
            /// Display Message
            /// </summary>
            public void DisplayMessage(string messageText)
            {
                // if the value for HasStatusLabel is true
                if (HasStatusLabel)
                {
                    // Set the Text
                    StatusLabel.SetTextValue(messageText);

                    // Display the message
                    ShowStatusMessage = true;

                    // Update the UI
                    Refresh();
                }
            }
            #endregion
            
            #region EditCustomer()
            /// <summary>
            /// Edit Customer
            /// </summary>
            public void EditCustomer()
            {
                // if the value for HasCurrentCustomer is true
                if (HasCurrentCustomer)
                {
                    // Set the ScreentType
                    ScreenType = ScreenTypeEnum.EditCustomer;
                }
            }
            #endregion
            
            #region FindOrder()
            /// <summary>
            /// Find Order
            /// </summary>
            public void FindOrder()
            {
                
            }
            #endregion
            
            #region NewOrder()
            /// <summary>
            /// New Order
            /// </summary>
            public void NewOrder()
            {
                // Change Screen
                ScreenType = ScreenTypeEnum.FindCustomer;
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
                if (component is Label tempLabel)
                {
                    if (component.Name == "StatusLabel")
                    {
                        // Use pattern matching to set StatusLabel
                        StatusLabel = tempLabel;
                    }
                }
                else if (component is CustomerEditor tempCustomerEditor)
                {
                    // Store
                    CustomerEditor = tempCustomerEditor;
                }
                else if (component is InformationBox tempInfoBox)
                {
                    // Store
                    CustomerInfoBox = tempInfoBox;

                    // if the value for HasCurrentCustomer is true
                    if (HasCurrentCustomer)
                    {
                        // Display
                        DisplayCustomer();
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
                
        #region CurrentCustomer
        /// <summary>
        /// This property gets or sets the value for 'CurrentCustomer'.
        /// </summary>
        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; }
        }
        #endregion
                
        #region CustomerEditor
        /// <summary>
        /// This property gets or sets the value for 'CustomerEditor'.
        /// </summary>
        public CustomerEditor CustomerEditor
        {
            get { return customerEditor; }
            set { customerEditor = value; }
        }
        #endregion
            
        #region CustomerInfoBox
        /// <summary>
        /// This property gets or sets the value for 'CustomerInfoBox'.
        /// </summary>
        public InformationBox CustomerInfoBox
        {
            get { return customerInfoBox; }
            set { customerInfoBox = value; }
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
                
        #region HasCustomerInfoBox
        /// <summary>
        /// This property returns true if this object has a 'CustomerInfoBox'.
        /// </summary>
        public bool HasCustomerInfoBox
        {
            get
            {
                // initial value
                bool hasCustomerInfoBox = (this.CustomerInfoBox != null);
                    
                // return value
                return hasCustomerInfoBox;
            }
        }
        #endregion
            
        #region HasStatusLabel
        /// <summary>
        /// This property returns true if this object has a 'StatusLabel'.
        /// </summary>
        public bool HasStatusLabel
        {
            get
            {
                // initial value
                bool hasStatusLabel = (this.StatusLabel != null);
                    
                // return value
                return hasStatusLabel;
            }
        }
        #endregion
                        
        #region ScreenType
        /// <summary>
        /// This property gets or sets the value for 'ScreenType'.
        /// </summary>
        public ScreenTypeEnum ScreenType
        {
            get { return screenType; }
            set { screenType = value; }
        }
        #endregion
                
        #region ShowStatusMessage
        /// <summary>
        /// This property gets or sets the value for 'ShowStatusMessage'.
        /// </summary>
        public bool ShowStatusMessage
        {
            get { return showStatusMessage; }
            set { showStatusMessage = value; }
        }
        #endregion
            
        #region StatusLabel
        /// <summary>
        /// This property gets or sets the value for 'StatusLabel'.
        /// </summary>
        public Label StatusLabel
        {
            get { return statusLabel; }
            set { statusLabel = value; }
        }
        #endregion
            
        #endregion
            
    }
    #endregion
    
}

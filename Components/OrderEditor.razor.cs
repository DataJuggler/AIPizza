

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;

#endregion

namespace AIPizza.Components
{

    #region class OrderEditor
    /// <summary>
    /// This class is used to create and edit orders
    /// </summary>
    public partial class OrderEditor : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private List<IBlazorComponent> children;
        private string name;
        private bool orderNow;        
        private ToggleComponent orderNowComponent;
        private ToggleComponent todayComponent;
        private bool today;
        private IBlazorComponentParent parent;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'OrderEditor' object.
        /// </summary>
        public OrderEditor()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default to ordering now & Today
                OrderNow = true;
                Today = true;
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                if ((NullHelper.Exists(message)) && (message.HasSender))
                {
                    if (message.Sender.Name == "OrderNowComponent")
                    {
                        // Using the CheckedValue for the Toggle Component
                        OrderNow = message.CheckedValue;
                    }
                    else if (message.Sender.Name == "TodayComponent")
                    {
                        // Set the value for Today
                        Today = message.CheckedValue;
                    }

                    // Update the UI
                    Refresh();
                }
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// method Refreshes the UI
            /// </summary>
            public void Refresh()
            {
                InvokeAsync(() =>
                {
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
                if (component is ToggleComponent tempToggle)
                {
                    if (component.Name == "OrderNowComponent")
                    {
                        // Store
                        OrderNowComponent = tempToggle;
                    }
                    else if (component.Name == "TodayComponent")
                    {
                        // Store
                        TodayComponent = tempToggle;
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
                
            #region HasOrderNowComponent
            /// <summary>
            /// This property returns true if this object has an 'OrderNowComponent'.
            /// </summary>
            public bool HasOrderNowComponent
            {
                get
                {
                    // initial value
                    bool hasOrderNowComponent = (this.OrderNowComponent != null);
                        
                    // return value
                    return hasOrderNowComponent;
                }
            }
            #endregion
                
            #region HasTodayComponent
            /// <summary>
            /// This property returns true if this object has a 'TodayComponent'.
            /// </summary>
            public bool HasTodayComponent
            {
                get
                {
                    // initial value
                    bool hasTodayComponent = (this.TodayComponent != null);
                    
                    // return value
                    return hasTodayComponent;
                }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            [Parameter]
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
                
            #region OrderNow
            /// <summary>
            /// This property gets or sets the value for 'OrderNow'.
            /// </summary>
            public bool OrderNow
            {
                get { return orderNow; }
                set { orderNow = value; }
            }
            #endregion
                
            #region OrderNowComponent
            /// <summary>
            /// This property gets or sets the value for 'OrderNowComponent'.
            /// </summary>
            public ToggleComponent OrderNowComponent
            {
                get { return orderNowComponent; }
                set { orderNowComponent = value; }
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
                set { parent = value; }
            }
            #endregion
                
            #region Today
            /// <summary>
            /// This property gets or sets the value for 'Today'.
            /// </summary>
            public bool Today
            {
                get { return today; }
                set { today = value; }
            }
            #endregion
            
            #region TodayComponent
            /// <summary>
            /// This property gets or sets the value for 'TodayComponent'.
            /// </summary>
            public ToggleComponent TodayComponent
            {
                get { return todayComponent; }
                set { todayComponent = value; }
            }
            #endregion
            
        #endregion
            
    }
    #endregion
    
}

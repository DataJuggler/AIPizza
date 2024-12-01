

#region using statements

using ObjectLibrary.Enumerations;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using AIPizza.Components.Pages;
using Microsoft.AspNetCore.Components;

#endregion

namespace AIPizza.Components
{

    #region class StartComponent
    /// <summary>
    /// This component is the default screen to start or find an order.
    /// </summary>
    public partial class StartComponent : IBlazorComponent
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods

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
                // if the value for HasParentHomePage is true
                if (HasParentHomePage)
                {
                    // Change Screen
                    ParentHomePage.ScreenType = ScreenTypeEnum.FindCustomer;

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
                
            }
            #endregion

        #endregion
        
        #region Properties
            
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
                    if (parent != null)
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
            
        #endregion
        
    }
    #endregion

}

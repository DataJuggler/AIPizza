

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;

#endregion

namespace AIPizza.Components
{

    #region class OrderDetailComponent
    /// <summary>
    /// This class is used to order pizzas.
    /// </summary>
    public partial class OrderDetailComponent : IBlazorComponent
    {
        
        #region Private Variables
        private bool editMode;
        private string name;        
        private IBlazorComponentParent parent;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
            #region ReceiveData(Message message)
            /// <summary>
            /// This method is used to receive messages from other components or pages
            /// </summary>
            public void ReceiveData(Message message)
            {

            }
            #endregion
            
        #endregion
        
        #region Properties
            
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
            
            #region HasParentOrderEditor
            /// <summary>
            /// This property returns true if this object has a 'ParentOrderEditor'.
            /// </summary>
            public bool HasParentOrderEditor
            {
                get
                {
                    // initial value
                    bool hasParentOrderEditor = (this.ParentOrderEditor != null);

                    // return value
                    return hasParentOrderEditor;
                }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for Name
            /// </summary>
            [Parameter]
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
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for Parent
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get
                {
                    return parent;
                }
                set
                {
                    parent = value;

                    // If the parent exists
                    if (parent != null)
                    {
                        // register with the parent
                        parent.Register(this);
                    }
                }
            }
            #endregion
            
            #region ParentOrderEditor
            /// <summary>
            /// This read only property returns the value of ParentOrderEditor
            /// </summary>
            public OrderEditor ParentOrderEditor
            {

                get
                {
                    // initial value
                    OrderEditor parentOrderEditor = null;

                    // if Parent exists
                    if (Parent is OrderEditor tempOrderEditor)
                    {
                        // set the return value
                        parentOrderEditor = tempOrderEditor;
                    }

                    // return value
                    return parentOrderEditor;
                }
            }
            #endregion
            
            #region PizzaOrder
            /// <summary>
            /// This read only property returns the value of PizzaOrder from the object ParentOrderEditor.
            /// </summary>
            public PizzaOrder PizzaOrder
            {

                get
                {
                    // initial value
                    PizzaOrder pizzaOrder = null;

                    // if ParentOrderEditor exists
                    if (HasParentOrderEditor)
                    {
                        // set the return value

                    }

                    // return value
                    return pizzaOrder;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}

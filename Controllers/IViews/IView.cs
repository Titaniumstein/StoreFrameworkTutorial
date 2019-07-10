using Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.IViews
{
    public interface IView<TController> : IViewBase where TController : IController
    {       
        
    }
}

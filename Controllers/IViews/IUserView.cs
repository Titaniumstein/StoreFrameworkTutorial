using Controllers.Controllers;
using Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.IViews
{
    public interface IUserView : IView<UserController>
    {
        void Render(UserViewModel user);
    }
}

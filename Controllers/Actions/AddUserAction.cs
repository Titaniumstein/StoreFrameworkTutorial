using Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.Actions
{
    public class AddUserAction : IAction
    {
        public AddUserAction(UserViewModel user)
        {
            this.User = user;
        }

        public UserViewModel User { get; }

    }
}

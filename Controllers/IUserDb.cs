using Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers
{
    public interface IUserDb
    {
        UserViewModel Get(Guid id);
        UserViewModel[] GetAll();
        void Add(UserViewModel user);
    }
}

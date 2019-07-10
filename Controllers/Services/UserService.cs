using Controllers.IViews;
using Controllers.StoreKeys;
using Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.Services
{
    public class UserService : IService
    {
        private IUserDb _userDb;


        public UserService(IUserDb userDb)
        {
            this._userDb = userDb;
        }

        public UserViewModel Get(Guid userId)
        {
            return this._userDb.Get(userId);
        }


        public UserViewModel[] GetUsers()
        {
            return this._userDb.GetAll();
        }



        public void AddUser(UserViewModel user)
        {
            this._userDb.Add(user);
        }

    }
}

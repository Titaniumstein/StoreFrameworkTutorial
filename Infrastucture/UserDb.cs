using Controllers;
using Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class UserDb : IUserDb
    {
        private List<UserViewModel> _users;
        public UserDb()
        {
            var userData = this.GetSeadData();
            this._users = new List<UserViewModel>();
            this._users.AddRange(userData);
        }

        private UserViewModel[] GetSeadData()
        {
            var user1 = new UserViewModel(Guid.NewGuid(), "Joe");
            var user2 = new UserViewModel(Guid.NewGuid(), "John");
            var user3 = new UserViewModel(Guid.NewGuid(), "Jake");
            var users = new UserViewModel[3] { user1, user2, user3 };
            return users;

        }
        public void Add(UserViewModel user)
        {
            this._users.Add(user);
        }

        public UserViewModel Get(Guid id)
        {
            var user = this._users.Where(x => x.Id == id).SingleOrDefault();
            return user;
        }

        public UserViewModel[] GetAll()
        {
            return this._users.ToArray();
        }
    }
}

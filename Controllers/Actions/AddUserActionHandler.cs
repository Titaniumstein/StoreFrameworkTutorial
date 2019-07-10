using Controllers.Controllers;
using Controllers.Services;
using Controllers.StoreKeys;
using Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Actions
{
    class AddUserActionHandler : IActionHandler<AddUserAction>
    {
        private IStoreManager _storeManager;
        private UserService _userService;
        public AddUserActionHandler(IStoreManager storeManager, UserService userService)
        {
            this._storeManager = storeManager;
            this._userService = userService;
        }

        public void Handle(AddUserAction action)
        {
            var user = action.User;
            user.Id = Guid.NewGuid();
            this._userService.AddUser(user);
            var users = this._userService.GetUsers();
            this._storeManager.SaveData(new UserCollectionStoreKey(), users.ToArray());
        }
    }
}

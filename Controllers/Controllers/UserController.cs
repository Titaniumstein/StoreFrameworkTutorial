using Controllers.IViews;
using Controllers.StoreKeys;
using Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.Controllers
{
    public class UserController : IController
    {
        private IStoreReader _storeReader;
        private IUserView _userView;
        private IUsersView _usersView;

        public UserController(IStoreReader storeReader, IUserView userView, IUsersView usersView)
        {
            _userView = userView;
            _usersView = usersView;
            _storeReader = storeReader;
            this.Initialize();
        }

        private void Initialize()
        {
            _storeReader.Subscribe(new UserCollectionStoreKey(), (obj, data) => this.UserCollectionStoreStateChanged(data));
        }


        private void UserCollectionStoreStateChanged(UserViewModel[] state)
        {
            _usersView.Render(state);
        }

        private void UserStoreStateChanged(UserViewModel state)
        {
            _userView.Render(state);
        }



    }
}

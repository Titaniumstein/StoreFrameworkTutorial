using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.ViewModels
{
    public class UserViewModel : IViewModel
    {
        public UserViewModel() { }
        public UserViewModel(Guid id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}

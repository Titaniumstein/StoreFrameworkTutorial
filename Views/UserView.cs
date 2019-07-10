using Controllers.Actions;
using Controllers.Controllers;
using Controllers.IViews;
using Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    public class UserView : IUsersView, IUserView
    {
        private UserController _controller;
        private UserViewModel[] _users;
        private bool _isActive;
        private IActionDispatcher _actionDispatcher;


        public UserView(IActionDispatcher actionDispatcher)
        {
            _isActive = true;
            this._actionDispatcher = actionDispatcher;
            _users = new UserViewModel[0];
        }
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("This application is running!");

            while (_isActive)
            {
                PrintInstructions();
                var input = Console.ReadKey();
                InputHandler(input.KeyChar);
            }
        }
        
        private void InputHandler(char input)
        {
            Console.WriteLine("");
            if(input == 'a')
            {
                this.AddUser();
            }
            else if (input == 'l')
            {
                this.DisplayUserList();
            }
            else if (input == 'q')
            {
                this.Quit();
            }
            else
            {
                Console.WriteLine("Unknown Command");
            }

        }
    

        private void PrintInstructions()
        {
            var str1 = @"a - add user";
            var str2 = @"l - list users";
            var str3 = @"q - quit";

            var instructions = new List<string> { str1, str2, str3 };

            Console.WriteLine("choose an option");
            foreach (var item in instructions)
            {
                this.PrintTab(item);
            }
        }

        public void Quit()
        {
            Console.WriteLine("Goodbye");
            System.Threading.Thread.Sleep(1000 * 1); // Sleep for 5 minutes
            this._isActive = false;
        }

        private void PrintTab(string str)
        {
            var tabStr = "\t" + str;
            Console.WriteLine(tabStr);

        }

        public void AddUser()
        {
            Console.WriteLine("Enter a username");
            var name = Console.ReadLine();
            var user = new UserViewModel();
            user.UserName = name;
            var action = new AddUserAction(user);
            this._actionDispatcher.Dispatch(action);
        }

        public void Render(UserViewModel[] users)
        {
            this._users = users;
            this.DisplayUserList();
        }

        public void DisplayUserList()
        {
            Console.WriteLine("User Collection:");

            foreach (var user in _users)
            {
                this.PrintTab(user.UserName);
            }
        }

        public void Render(UserViewModel user)
        {
            Console.WriteLine("user:");
            var id = "ID: " + user.Id;
            var username = "username: " + user.UserName;

            Console.WriteLine(id);
            Console.WriteLine(username);
        }

    }
}

using Controllers.Actions;
using Controllers.Controllers;
using Controllers.IViews;
using System;
using Views;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = Bootstrapper.Container)
            {
                var actionDispatcher = container.GetInstance<IActionDispatcher>();
                actionDispatcher.Dispatch(new ConnectToServerAction());
                var view = container.GetInstance<IUsersView>();
                ((UserView)view).Start();
            }
        }
    }
}

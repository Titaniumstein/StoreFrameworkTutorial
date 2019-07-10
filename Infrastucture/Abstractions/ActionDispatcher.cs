using Controllers.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Actions
{
    public class ActionDispatcher : IActionDispatcher
    {
        public void Dispatch<TAction>(TAction action) where TAction : IAction
        {
            var handler = Bootstrapper.Container.GetInstance<IActionHandler<TAction>>();
            handler.Handle(action);
        }

    }
}

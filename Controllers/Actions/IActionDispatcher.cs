using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Actions
{
    public interface IActionDispatcher
    {
        void Dispatch<TAction>(TAction action) where TAction : IAction;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Actions
{
    public interface IActionHandler<TAction> where TAction : IAction
    {
        void Handle(TAction action);

    }
}

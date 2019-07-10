using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFramework
{
    public class StoreBase<T> //: IStore<T>
    {
        protected T _state;
        protected IObjectCloner _objCloner;


        public StoreBase()
        {
            _objCloner = new ObjectCloner();
        }


        public virtual T GetCopyOfState()
        {
            var val = _state == null ? default(T) : _objCloner.DeepClone(_state);
            return val;
        }

        public virtual void WriteState(T state)
        {
            var val = state == null ? default(T) : _objCloner.DeepClone(state);
            _state = val;
            OnStateChanged();
        }

        public event EventHandler<T> StateChanged;

        protected virtual void OnStateChanged()
        {
            var state = this.GetCopyOfState();
            var handler = StateChanged;
            if (handler != null)
            {
                handler.Invoke(this, state);
            }
        }




        public void SubscribeToStateChange(EventHandler<T> callback)
        {
            StateChanged += callback;
        }

        public void UnsubscribeToStateChange(EventHandler<T> callback)
        {
            StateChanged -= callback;
        }

    }
}

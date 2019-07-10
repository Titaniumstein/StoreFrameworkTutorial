using Controllers.StoreKeys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers
{
    public interface IStoreReader
    {
        void Subscribe<TData>(IStoreKey<TData> storeKey, EventHandler<TData> callback);
        void Unsubscribe<TData>(IStoreKey<TData> storeKey, EventHandler<TData> callback);
        TData GetState<TData>(IStoreKey<TData> storeKey);
    }
}

using Controllers;
using Controllers.StoreKeys;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp;
using TestApp.Abstractions.Store;

namespace Infrastructure.Abstractions.Store
{
    public class StoreManager : IStoreManager, IStoreReader
    {
        public TData GetState<TData>(IStoreKey<TData> storeKey)
        {
            var dataType = typeof(TData);
            Type storeType = typeof(StoreWrapper<,>).MakeGenericType(storeKey.GetType(), dataType);
            dynamic store = Bootstrapper.Container.GetInstance(storeType);
            var state = store.GetCopyOfState();
            return state;
        }

        public void SaveData<TData>(IStoreKey<TData> storeKey, TData data)
        {
            var dataType = typeof(TData);
            Type storeType = typeof(StoreWrapper<,>).MakeGenericType(storeKey.GetType(), dataType);
            dynamic store = Bootstrapper.Container.GetInstance(storeType);
            store.WriteState(data);
        }


        public void Subscribe<TData>(IStoreKey<TData> storeKey, EventHandler<TData> callback)
        {
            var resultType = typeof(TData);
            Type handlerType = typeof(StoreWrapper<,>).MakeGenericType(storeKey.GetType(), resultType);
            dynamic store = Bootstrapper.Container.GetInstance(handlerType);
            store.SubscribeToStateChange(callback);

        }

        public void Unsubscribe<TData>(IStoreKey<TData> storeKey, EventHandler<TData> callback)
        {
            var resultType = typeof(TData);
            Type handlerType = typeof(StoreWrapper<,>).MakeGenericType(storeKey.GetType(), resultType);
            dynamic store = Bootstrapper.Container.GetInstance(handlerType);
            store.UnsubscribeToStateChange(callback);
        }



    }

}

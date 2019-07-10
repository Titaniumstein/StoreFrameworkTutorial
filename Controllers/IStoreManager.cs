using Controllers.StoreKeys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers
{
    public interface IStoreManager : IStoreReader
    {
        void SaveData<TData>(IStoreKey<TData> storeKey, TData data);
    }
}

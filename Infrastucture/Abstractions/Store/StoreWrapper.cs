using Controllers;
using Controllers.StoreKeys;
using StoreFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Abstractions.Store
{
    public class StoreWrapper<TStoreKey, TData> : StoreBase<TData>  where TStoreKey : IStoreKey<TData>
    {
    }

}

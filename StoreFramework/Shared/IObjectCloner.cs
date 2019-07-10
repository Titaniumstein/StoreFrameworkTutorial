using System;
using System.Collections.Generic;
using System.Text;

namespace StoreFramework
{
    public interface IObjectCloner
    {
        T DeepClone<T>(T obj);
    }
}

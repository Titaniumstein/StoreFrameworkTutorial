using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreFramework
{
    public class ObjectCloner : IObjectCloner
    {
        public T DeepClone<T>(T obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var deserialized = JsonConvert.DeserializeObject<T>(serialized);
            return deserialized;
        }
    }
}

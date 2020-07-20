using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionStyles.Uitilty
{
    public static  class SessionExtension
    {
        public static void SetObject(this Microsoft.AspNetCore.Http.ISession session , string key , object value)
        {
            session.SetObject(key, JsonConvert.SerializeObject(value));


        }
        public static T GetObject<T>(this ISession session , string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);

        }

    }
}

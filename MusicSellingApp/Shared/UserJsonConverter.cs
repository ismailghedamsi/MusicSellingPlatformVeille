using MusicSellingApp.Shared.Entitities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared
{

    public class UserJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(User));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            if (jo["FooBarBuzz"].Value<string>() == "Artist")
                return jo.ToObject<Artist>(serializer);

            if (jo["FooBarBuzz"].Value<string>() == "Fan")
                return jo.ToObject<Fan>(serializer);

            return null;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupang
{
    public partial class Api
    {
        private T DeserializeObject<T>(string json, JsonSerializerSettings jsonSerializerSettings)
        {
            T deserializeObject = JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
            return deserializeObject;
        }
        public T ToClass<T>(string json)
        {
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            jsonSerializerSettings.Error = (se, ev) => { ev.ErrorContext.Handled = true; };
            T deserializeObject = this.DeserializeObject<T>(json, jsonSerializerSettings);
            return deserializeObject;
        }

        private string SerializeObject(object value)
        {
            string serializeObject = JsonConvert.SerializeObject(value);
            return serializeObject;
        }
        public string ToJson(object value)
        {
            string serializeObject = this.SerializeObject(value);
            if (serializeObject == "null") { return null; }
            return serializeObject;
        }
    }
}

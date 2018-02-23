using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SearchJSON
{
    public static class JsonHelper
    {
        public static string FromClass<T>(T data, bool isEmptyToNull = false,
                                          JsonSerializerSettings jsonSettings = null)
        {
            string response = string.Empty;

            if (!EqualityComparer<T>.Default.Equals(data, default(T)))
                response = JsonConvert.SerializeObject(data, jsonSettings);

            return isEmptyToNull ? (response == "{}" ? "null" : response) : response;
        }


        public static List<T> ToClass<T>(string data, JsonSerializerSettings jsonSettings = null)
        {
            var response = default(List<T>);

            try
            {
                if (!string.IsNullOrEmpty(data))
                    response = jsonSettings == null
                        ? JsonConvert.DeserializeObject<List<T>>(data)
                        : JsonConvert.DeserializeObject<List<T>>(data, jsonSettings);
                                
            }
            catch(Newtonsoft.Json.JsonReaderException e)
            {
                Console.WriteLine("\n FILE DATA NOT IN CORRECT FORMAT/ INVALID VALUES ");
            }

            return response;
        }
    }
}

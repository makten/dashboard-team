using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Infrastructure.MessageQueue
{
    public class MessageSerializer
    {
        private static JsonSerializerSettings _serializerSettings;

        static MessageSerializer()
        {
            _serializerSettings = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            _serializerSettings.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });
        }

        /// <summary>
        /// Serialize an object to a JSON string.
        /// </summary>
        /// <param name="message">The value to serialize.</param>

        public static string Serialize(object message)
        {
            return JsonConvert.SerializeObject(message, _serializerSettings);
        }

        /// <summary>
        /// Deserialize JSON to an object.
        /// </summary>
        /// <param name="value">The JSON data to deserialize.</param>
        public static JObject DeserializeObject(string value)
        {
            return JsonConvert.DeserializeObject<JObject>(value, _serializerSettings);
        }
    }
}

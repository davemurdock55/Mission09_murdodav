using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mission09_murdodav.Infrastructure
{
    public static class SessionExtensions
    {
        // making a method to set a string to Json  to store in the session (passing it the session object, a key (string), and a value (object))
        public static void SetJson(this ISession session, string key, object value)
        {
            // getting the value object we passed into the method,
            // serializing it to Json, giving it a Session "key" that is the value of the key string we passed
            // then SETTING the resulting string to the session (accessible through the key)
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Receiving information from the Json object
        public static T GetJson<T>(this ISession session, string key)
        {
            // using the key to GET a "json" string and calling the returned string "sessionData"
            var sessionData = session.GetString(key);

            // checking to see if the sessionData is null
            // if it IS null, return the default type (T)?, if not, Deserialize the sessionData back to actual Json? and return that???
            return (sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData));
        }
    }
}

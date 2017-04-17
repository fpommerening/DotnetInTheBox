using System;
using System.Collections;

namespace FP.Spartakiade2017.Docker.WebHook.Service
{
    public class EnvironmentVariable
    {
        public static string GetValueOrDefault(string key, string defaultValue)
        {
            foreach (DictionaryEntry de in System.Environment.GetEnvironmentVariables())
            {
                if (de.Key?.ToString() == key)
                {
                    return de.Value.ToString();
                }
            }
            return defaultValue;
        }

        public static string GetValue(string key)
        {
            foreach (DictionaryEntry de in System.Environment.GetEnvironmentVariables())
            {
                if (de.Key?.ToString() == key)
                {
                    return de.Value.ToString();
                }
            }
            throw new ArgumentException($"Key {key} is missing  in environment variables");
        }
    }
}

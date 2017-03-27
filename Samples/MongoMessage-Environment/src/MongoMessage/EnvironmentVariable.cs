using System.Collections;

namespace FP.DotnetInTheBox.Environment
{
    public class EnvironmentVariable
    {
        public static string GetValueOrDefault(string key, string defaultValue)
        {
            foreach (DictionaryEntry de in System.Environment.GetEnvironmentVariables())
            {
                if (de.Key?.ToString() == key)
                {
                 //   Console.WriteLine($"GetEnvVar {key} - {de.Value}");
                    return de.Value.ToString();
                }
            }
            //Console.WriteLine($"GetEnvVar {key} - default - {defaultValue}");
            return defaultValue;
        }
    }
}

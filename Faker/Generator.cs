using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Faker
{
    public class Generator
    {
        private String pluginName;
        private Assembly assembly;
        private Dictionary<Type, Func<object>> typeDictionary;
        
        public Generator()
        {
            typeDictionary = new Dictionary<Type, Func<object>>();
            
            pluginName = "C:\\Users\\Dasha_2\\RiderProjects\\SPP2\\Plugins\\bin\\Debug\\net5.0\\Plugins.dll";
            if (!File.Exists(pluginName))
            {
                throw new Exception("Wrong plugin's path");
            }

            assembly = Assembly.LoadFile(pluginName);
            typeDictionary = fillDictionary(typeDictionary);
        }
        
        private Dictionary<Type, Func<object>> fillDictionary(Dictionary<Type, Func<object>> dictionary)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetInterface(typeof(IValueGenerator).ToString()) != null)
                {
                    var plugin = assembly.CreateInstance(type.FullName) as IValueGenerator;
                    if (!dictionary.ContainsKey(plugin.GetValueType()))
                        dictionary.Add(plugin.GetValueType(), plugin.GenerateValue);
                }
            }
            return dictionary;
        }
    }
}
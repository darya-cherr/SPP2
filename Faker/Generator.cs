using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Generators;

namespace Faker
{
    class Generator
    {
        private String pluginName;
        private Assembly assembly;
        private Dictionary<Type, Func<object>> typeDictionary;
        private ListGenerator collectionGenerator;
        private List<Type> cycleList;
        private Faker faker;

        public Generator()
        {
            typeDictionary = new Dictionary<Type, Func<object>>();
            collectionGenerator = new ListGenerator();

            cycleList = new List<Type>();
            pluginName = "C:\\Users\\Dasha_2\\RiderProjects\\SPP2\\Plugins\\bin\\Debug\\net5.0\\Plugins.dll";
            if (!File.Exists(pluginName))
            {
                throw new Exception("Wrong plugin's path");
            }

            assembly = Assembly.LoadFile(pluginName);
            typeDictionary = fillDictionary(typeDictionary);
        }
        public int user = 0;
        public int dog = 0;
        public void AddToCycle(Type t)
        {
            if (t.Equals(typeof(User)))
            {
                user++;
            }
            cycleList.Add(t);
        }

        public void RemoveFromCycle(Type t)
        {
            cycleList.Remove(t);
        }

        public void SetFaker(Faker faker)
        {
            this.faker = faker;
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
        List<Type> counter = new List<Type>();

        public object GenerateValue(Type t)
        {
            
            

            object obj = null;
            Func<object> generatorFunc = null;

            if (t.Equals(typeof(User)))
            {
                user++;
            }
            if (t.IsGenericType)
            {
                obj = collectionGenerator.GenerateList(t.GenericTypeArguments[0], this);
            }
            else if (typeDictionary.TryGetValue(t, out generatorFunc))
                obj = generatorFunc.Invoke();
            else if (!cycleList.Contains(t) || t.Equals(typeof(Dog)))
            {
                obj = faker.Create(t);
            }
            else if (!cycleList.Contains(t))
            {
                obj = faker.Create(t);
            }

            if (t.Equals(typeof(User)) && user==3)
            {
                obj = faker.Create(t);
            }
            return obj;
        }
    }
}
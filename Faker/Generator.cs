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
            cycleList.Add(t);
        }

        public void RemoveFromCycle(Type t)
        {
            cycleList.Remove(t);
        }
        
        public bool _Contains(Type t)
        {
            return cycleList.Contains(t);
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
        public int count1 = 0;
        private int flag = 0;
        public int k = 4;
        private int j = 0;
        public int count2 = 0;
        public object GenerateValue(Type t)
        {
            if (t == typeof(User) || t == typeof(Dog))
            {
                counter.Add(t);
            }
            
            object obj = null;
            Func<object> generatorFunc = null;
            
            if (t.IsGenericType)
            {
                
                obj = collectionGenerator.GenerateList(t.GenericTypeArguments[0], this);
            }
            else if (typeDictionary.TryGetValue(t, out generatorFunc))
                obj = generatorFunc.Invoke();
             
            else if (!cycleList.Contains(t) || t == typeof(Dog)|| t == typeof(Profile))
            {
                obj = faker.Create(t);
            }
            if (cycleList.Contains(t)){
                foreach (Type ty in counter)
                {
                    if (ty == typeof(User))
                    {
                        count1++;
                    }

                    if (ty == typeof(Dog))
                    {
                        count2++;
                    }
                    if (count1 > k+2 || count2 > k+2 )
                    {
                        counter.Clear();
                        break;
                    }
                }

                if ((count1 < k || count2 > 2*k ) && t == typeof(User))
                {
                    count1 = 0;
                    count2 = 0;
                    obj = faker.Create(t);
                    return obj;
                }
                count1 = 0;
                count2 = 0;
            }
            return obj;
        }
    }
}
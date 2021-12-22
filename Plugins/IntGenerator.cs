using System;
using Faker;

namespace Plugins
{
     class IntGenerator : IValueGenerator
    {
        private Random random = new Random();
        
        public object GenerateValue()
        {
            return random.Next(int.MinValue,int.MaxValue);
        }

        public Type GetValueType()
        {
            return typeof(int);
        }
    }
}
using System;
using Faker;

namespace Plugins
{
     class IntGenerator : IValueGenerator
    {
        private Random random = new Random();
        
        public object GenerateValue()
        {
            return random.Next(Int32.MinValue,Int32.MaxValue);
        }

        public Type GetValueType()
        {
            return typeof(Int32);
        }
    }
}
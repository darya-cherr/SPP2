using System;
using Faker;

namespace Plugins
{
     class BooleanGenerator : IValueGenerator
    {
        static Random random = new Random();
        
        public object GenerateValue()
        {
            return random.Next(2)==1;
        }

        public Type GetValueType()
        {
            return typeof(Boolean);
        }
    }
}
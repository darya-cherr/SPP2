using System;
using Faker;

namespace Generators
{
    public class BooleanGenerator : IValueGenerator
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
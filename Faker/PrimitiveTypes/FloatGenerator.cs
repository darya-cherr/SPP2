using System;
using Faker;

namespace Generators
{
    public class FloatGenerator : IValueGenerator
    {
        private Random random = new Random();
        
        public object GenerateValue()
        {
            return (float)random.NextDouble();
        }

        public Type GetValueType()
        {
            return typeof(float);
        }
    }
}
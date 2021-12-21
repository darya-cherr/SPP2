using System;
using Faker;

namespace Generators
{
    public class DoubleGenerator : IValueGenerator
    {

        public object GenerateValue()
        {
            return new Random().NextDouble();
        }

        public Type GetValueType()
        {
            return typeof(Double);
        }
    }
}
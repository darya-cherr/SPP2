using System;
using Faker;

namespace Generators
{
    public class LongGenerator : IValueGenerator
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        public object GenerateValue()
        {
            int result;
            do
            {
                result = random.Next();
            } while (result == 0);
            return (long)random.Next();
        }

        public Type GetValueType()
        {
            return typeof(Int64);
        }
    }
}
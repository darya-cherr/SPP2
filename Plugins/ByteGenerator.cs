using System;
using Faker;

namespace Plugins
{
    class ByteGenerator : IValueGenerator
    {
        private Random random = new Random();

        public object GenerateValue()
        {
            return (byte)(random.Next(byte.MinValue,byte.MaxValue));
        }

        public Type GetValueType()
        {
            return typeof(Byte);
        }
    }
}
using System;
using System.Text;
using Faker;

namespace Generators
{
    public class StringGenerator : IValueGenerator
    {
        private Random random = new Random();

        public object GenerateValue()
        {
            int length = random.Next(1, 20);
            string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int pos = random.Next(0, symbols.Length);
                result.Append(symbols[pos]);
            }
            return (String)result.ToString();
        }

        public Type GetValueType()
        {
            return typeof(String);
        }
    }
}
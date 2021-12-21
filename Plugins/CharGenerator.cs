using System;
using Faker;

namespace Plugins
{
    public class CharGenerator : IValueGenerator
    {
        private Random random = new Random();
        private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public object GenerateValue()
        {
            char ch = chars[random.Next(chars.Length)];
            return ch;
        }

        public Type GetValueType()
        {
            return typeof(Char);
        }
    }
}
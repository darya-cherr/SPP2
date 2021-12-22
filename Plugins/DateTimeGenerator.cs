using System;
using Faker;

namespace Plugins
{
    class DateTimeGenerator : IValueGenerator
    {
        private Random random = new Random((int)DateTime.Now.Ticks);
        
        public object GenerateValue()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            long ticks = start.AddDays(random.Next(range)).Ticks +
                         (long)random.Next();
            return new DateTime(ticks);
        }

        public Type GetValueType()
        {
            return typeof(DateTime);
        }
    }
}
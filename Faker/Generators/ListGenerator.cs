using System;
using System.Collections;
using System.Collections.Generic;
using Faker;

namespace Generators
{
    class ListGenerator
    {
        private Random random;
        
        public ListGenerator()
        {
            random = new Random((int)DateTime.Now.Ticks);
        }

        public object GenerateList(Type type, Generator generator)
        {
            object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            int count = (Byte)random.Next();

            for (int i = 0; i < count; i++)
            {
                ((IList)list).Add(generator.GenerateValue(type));
            }
            return list;
        }

    }
}
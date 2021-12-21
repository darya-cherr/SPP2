using System;
using Faker;

namespace Generators
{
    public class ShortGenerator : IValueGenerator
    {
         private Random random = new Random((int)DateTime.Now.Ticks);
        
                  public object GenerateValue()
                  {
                       int result;
                       do
                       {
                            result = random.Next();
                       } while (result == 0);
                       return (Int16)random.Next();
                  }
        
                  public Type GetValueType()
                  {
                       return typeof(Int16);
                  }
    }
}
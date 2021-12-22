using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Faker
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            User user = faker.Create<User>();
            Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));
        }
    }
}
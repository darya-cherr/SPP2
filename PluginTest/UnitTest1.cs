using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Faker;
using NUnit.Framework;

namespace PluginTest
{
    public class Tests
    {
        [Test]
        public void PluginLoadTest()
        {
           String pluginName = "C:\\Users\\Dasha_2\\RiderProjects\\SPP2\\Plugins\\bin\\Debug\\net5.0\\Plugins.dll";
           Assert.AreEqual("C:\\Users\\Dasha_2\\RiderProjects\\SPP2\\Plugins\\bin\\Debug\\net5.0\\Plugins.dll", pluginName); 
           Assembly assembly = Assembly.LoadFile(pluginName);
           Assert.AreEqual("Plugins.dll", assembly.ManifestModule.Name);
        }
        
        private Bar bar;
        private Faker.Faker faker;
        private User user;
        private Foo foo;
        [SetUp]
        public void Initialization()
        {
            faker = new Faker.Faker();
            bar = faker.Create<Bar>();
            user = faker.Create<User>();
            foo = faker.Create<Foo>();
        }
        [Test] 
        public void TestGenerateClass()
        {
            Assert.True(bar!=null);
        }
        [Test]
        public void TestGenerateFloat()
        {
            Assert.True(user.money != 0f);
            Assert.True(user.money is float);
        }
        [Test]
        public void TestGenerateString()
        {
            Assert.True(user.name != null);
            Assert.True(user.name is string);
        }
        
        [Test]
        public void TestGenerateList()
        {
            Assert.True(user.dogs.Count() > 0);
            foreach (Dog dog in user.dogs)
            {
                Assert.True(dog!=null);
            }
        }
        [Test]
        public void TestGenerateListInt()
        {
            Assert.True(foo.list.Count > 0);
            foreach (int num in foo.list)
            {
                Assert.True(num != 0);
            }
        }
        
    }
}
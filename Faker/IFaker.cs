using System;

namespace Faker
{
    public interface IFaker
    {
        object Create(Type objectType);
    }
}
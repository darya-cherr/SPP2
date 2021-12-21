using System;

namespace Faker
{
    public interface IValueGenerator
    {
        object GenerateValue();
        Type GetValueType();
    }
}
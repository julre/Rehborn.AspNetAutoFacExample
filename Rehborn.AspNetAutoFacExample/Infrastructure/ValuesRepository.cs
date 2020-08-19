using System.Collections.Generic;
using Rehborn.AspNetAutoFacExample.Domain;

namespace Rehborn.AspNetAutoFacExample.Infrastructure
{
    public class ValuesRepository : IValuesRepository
    {
        public IEnumerable<Value> GetAll()
        {
            yield return Value.Create("Foobar");
            yield return Value.Create("Foo");
            yield return Value.Create("Bar");
            yield return Value.Create("Blub");
        }
    }
}
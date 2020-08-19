using System.Collections.Generic;
using Rehborn.AspNetAutoFacExample.Domain.SeedWork;

namespace Rehborn.AspNetAutoFacExample.Domain
{
    public interface IValuesRepository : IRepository<Value>
    {
        IEnumerable<Value> GetAll();
    }
}
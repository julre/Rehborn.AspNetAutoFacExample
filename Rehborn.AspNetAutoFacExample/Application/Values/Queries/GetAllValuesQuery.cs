using System.Collections.Generic;
using MediatR;
using Rehborn.AspNetAutoFacExample.Domain;

namespace Rehborn.AspNetAutoFacExample.Application.Values.Queries
{
    public class GetAllValuesQuery : IRequest<IEnumerable<Value>>
    {
        public bool AddAdditional { get; set; } = true;
    }
}
using System.Collections.Generic;
using MediatR;

namespace Rehborn.AspNetAutoFacExample.Application.Values.Queries
{
    public class GetAllValuesQuery : IRequest<IEnumerable<ValueDto>>
    {
        public bool AddAdditional { get; set; } = true;
    }
}
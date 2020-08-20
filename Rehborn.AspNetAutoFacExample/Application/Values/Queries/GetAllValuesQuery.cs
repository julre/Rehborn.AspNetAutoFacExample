using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediatR;
using Rehborn.AspNetAutoFacExample.Domain;

namespace Rehborn.AspNetAutoFacExample.Application.Values.Queries
{
    public class GetAllValuesQuery : IRequest<IEnumerable<Value>>
    {
        public bool AddAdditional { get; set; } = true;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rehborn.AspNetAutoFacExample.Controllers;
using Rehborn.AspNetAutoFacExample.Domain;

namespace Rehborn.AspNetAutoFacExample.Application.Values.Queries
{
    public class GetAllValuesHandler : IRequestHandler<GetAllValuesQuery, IEnumerable<Value>>
    {
        private readonly IValuesRepository _valuesRepository;
        private readonly ILogger<ValuesController> _logger;
        private readonly MyTestConfig _myTestConfig;

        public GetAllValuesHandler(IValuesRepository valuesRepository, ILogger<ValuesController> logger, IOptionsMonitor<MyTestConfig> myTestConfig)
        {
            _valuesRepository = valuesRepository;
            _logger = logger;
            _myTestConfig = myTestConfig.CurrentValue;
        }
        public Task<IEnumerable<Value>> Handle(GetAllValuesQuery request, CancellationToken cancellationToken)
        {
            var values = _valuesRepository.GetAll().ToList();
            if (request.AddAdditional)
            {
                var additionalValue = Value.Create(_myTestConfig.MyTestValue.ToString());
                _logger.LogInformation("Additional Value is: {@additionalValue} ", additionalValue);
                values.Add(additionalValue);
            }
            return Task.FromResult(values.AsEnumerable());
        }
    }
}
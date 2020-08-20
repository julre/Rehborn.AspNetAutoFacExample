using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rehborn.AspNetAutoFacExample.Domain;

namespace Rehborn.AspNetAutoFacExample.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IValuesRepository _valuesRepository;
        private readonly ILogger<ValuesController> _logger;
        private readonly MyTestConfig _myTestConfig;

        public ValuesController(IValuesRepository valuesRepository, ILogger<ValuesController> logger, IOptionsMonitor<MyTestConfig> myTestConfig)
        {
            _valuesRepository = valuesRepository;
            _logger = logger;
            _myTestConfig = myTestConfig.CurrentValue;
        }

        // GET api/values
        public IEnumerable<Value> Get()
        {
            
            var values = _valuesRepository.GetAll().ToList();
            var additionalValue = Value.Create(_myTestConfig.MyTestValue.ToString());
            _logger.LogInformation("Additional Value is: {@additionalValue} ", additionalValue);
            values.Add(additionalValue);
            return values;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

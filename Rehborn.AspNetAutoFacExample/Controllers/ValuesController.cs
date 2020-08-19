using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Extensions.Logging;
using Rehborn.AspNetAutoFacExample.Domain;

namespace Rehborn.AspNetAutoFacExample.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IValuesRepository _valuesRepository;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IValuesRepository valuesRepository, ILogger<ValuesController> logger)
        {
            _valuesRepository = valuesRepository;
            _logger = logger;
        }

        // GET api/values
        public IEnumerable<Value> Get()
        {
            _logger.LogTrace("TestMessage");
            return _valuesRepository.GetAll();
            //return new string[] { "value1", "value2" };
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Newtonsoft.Json;
using DataShunt.Models;

namespace DataShunt.Controllers
{
    [ApiController]
    [Route("api/v1/generic")]
    public class GenericDataController : ControllerBase
    {
        private readonly ILogger<GenericDataController> _logger;
        private readonly MSSQLContext _dbcontext;

        public GenericDataController(ILogger<GenericDataController> logger, MSSQLContext dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;
        }

        [HttpGet("sampledevices/getbyname/{name}")]
        public IEnumerable<SampleGovernment> Get(string name)
        {
            Console.WriteLine($"GenericDataController sampledevices/getbyname/{name} called...");
            var sampleGovernmentDevices = _dbcontext.SampleGovernment
                .Where(x => x.Name.StartsWith(name))
                .ToList();

            Console.WriteLine($"Results: {sampleGovernmentDevices.Count}");
            
            return sampleGovernmentDevices;            
        }
    }
}
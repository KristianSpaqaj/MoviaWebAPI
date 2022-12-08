using Microsoft.AspNetCore.Mvc;
using MoviaWebAPI.Manager;
using MoviaWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviaWebAPI.Controllers
{
    [Route("api/BusLine")]
    [ApiController]
    public class BusLineController : ControllerBase
    {
        public BusLineManager _busLineManager = new();

        // GET api/<BusLineController>/5
        [HttpGet("line/{line}/{amount}")]
        public List<string> Get(string line, int amount)
        {
            return _busLineManager.Get(line,amount);
        }
        [HttpGet("between/{from}/{to}")]
        public List<string> Get(DateTime from, DateTime to)
        {
            return _busLineManager.Get(from,to);
        }

        // POST api/<BusLineController>
        [HttpPost]
        public BusLine Post([FromBody] BusLine value)
        {
            return _busLineManager.Post(value);
        }
    }
}

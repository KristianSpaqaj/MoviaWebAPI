using Microsoft.AspNetCore.Http.HttpResults;
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
        private BusLineManager _busLineManager = new();

        // GET api/<BusLineController>/
        
        [HttpGet("line/{line}/{amount}")]
        public IActionResult Get(string line, int amount)
        {
            if (amount < 1)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_busLineManager.Get(line, amount));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
            Console.WriteLine(value.Message);
            return _busLineManager.Post(value);
        }
    }
}

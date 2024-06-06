using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestSample.CrtlSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        public string GetName()
        {
            return "hello kitty";
        }

        [HttpGet("SayMyName")]
        public string GetDeveloperName()
        {
            return "Mahdi is here...";
        }

        [HttpGet("Name/{id}")]
        public string GetDeveloperNameById(int id)
        {
            return $"Mahdi is here... id = {id}";
        }

        [HttpGet("Result/{id}")]
        public IActionResult GetResult(int id)
        {
            return Ok( $"Mahdi is here... id = {id}");
        }
    }
}

using HttpClientDirect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HttpClientDirect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                var result = await client.GetStringAsync("/posts");
                var finalResult = JsonConvert.DeserializeObject<List<Posts>>(result);
                return Ok(finalResult);
            }
        }
    }
}

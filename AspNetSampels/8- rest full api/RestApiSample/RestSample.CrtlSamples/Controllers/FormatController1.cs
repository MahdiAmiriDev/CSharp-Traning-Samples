using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestSample.CrtlSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController1 : ControllerBase
    {

        public string GetStr()
        {
            return "hello world";
        }

        public int GetInt() => 1;

        public object GetObject() => new
            {
                Fname = "mahdi",
                Lname = "Amiri"
            };
        
    }
}

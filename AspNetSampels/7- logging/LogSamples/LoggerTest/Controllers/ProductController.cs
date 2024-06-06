using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggerTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ILogger _loggerFactory;

        public ProductController(ILogger<ProductController> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _loggerFactory = loggerFactory.CreateLogger("test for bussines log");
        }

        [HttpGet("GetProductInfo")]
        public IActionResult GetProductInfo(int id)
        {

            _logger.LogInformation("information log for {ID}", id);

            _loggerFactory.LogInformation("information log for {ID}", id);


            var result = new
            {
                ProductId = id,
                ProductName = "Honey"
            };


            //return Accepted(result);

            //return Accepted(new
            //{
            //    ProductId = id,
            //    ProductName = "Honey"
            //});

            return Ok(new
            {
                ProductId = id,
                ProductName = "Honey"
            });
        }
    }
}

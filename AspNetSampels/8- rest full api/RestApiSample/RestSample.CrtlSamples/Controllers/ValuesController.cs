using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiSample;

namespace RestSample.CrtlSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProductDbContext _productDbContext;

        public ValuesController(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public IActionResult GetProductList()
        {
            var products = _productDbContext.Products.ToList();

            return Ok(products);
        }

        public IActionResult GetProductListFromMethodDi([FromServices] ProductDbContext productDbContext)
        {
            var products = productDbContext.Products.ToList();

            return Ok(products);
        }

        [HttpGet("GetEntity/{id}")]
        public IActionResult GetEntity([FromServices] ProductDbContext productDbContext , int id)
        {
            var products = productDbContext.Products.FirstOrDefault(x => x.Id == id);

            if(products == null)
                return NotFound();

            return Ok(products);
        }

        
        [HttpGet("AddProduct")]
        public async Task<IActionResult> GetProductListAsync([FromBody] Product product)
        {
            //اگر خود فریم ورک چک نکنه مجبور هستیم خودمان چک کنیم که ولید هست یا نه
            // بر اساس محدودیت های با اتتریبیوت قرار دادیم
            if(ModelState.IsValid)
           await _productDbContext.Products.AddAsync(product);

            return Ok();
        }

        [HttpGet("Google")]
        public IActionResult GoToGoogle()
        {
            return Redirect("http://goggle.com");
        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using SwiggyApp.Models;

namespace SwiggyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _configuration; 
        private readonly UserContext _userContext;
        public ProductsController(IConfiguration configuration,UserContext userContext)
        {
            _configuration = configuration;
            _userContext=userContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _userContext.Products.ToListAsync();
            return Ok(products);
        }
        [HttpPost]

        public async Task<IActionResult> AddProducts([FromBody] Products products)
        {
           await _userContext.Products.AddAsync(products);
            await _userContext.SaveChangesAsync();
            return Ok(products);
        }
    }
}

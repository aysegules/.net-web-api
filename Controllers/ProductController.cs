using Microsoft.AspNetCore.Mvc;
using ProductHandler.Models;

namespace ProductHandler.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController(TestDbContext context) : Controller
    {
        private readonly TestDbContext _context = context;

        [HttpGet]
        public  ActionResult<List<Product>> GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            product.ProductName = updatedProduct.ProductName;
            product.SupplierName = updatedProduct.SupplierName;
            product.UnitPrice = updatedProduct.UnitPrice;
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct (int id) {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

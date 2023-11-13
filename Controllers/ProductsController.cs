using ApiCatalog.Context;
using ApiCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalog.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get(){
            var products = _context.Products.AsNoTracking().ToList();

            if(products is null){
                return NotFound("Resource Not Found.");
            }

            return products;
        }


        [HttpGet("{id:int}", Name="product")]
        public ActionResult<Product> Get(int id){
            var product = _context.Products.AsNoTracking().FirstOrDefault(product => product.Id == id);
            
            if(product == null){
                return NotFound("Resource Not Found");
            }

            return product;
        }

        [HttpPost]
        public ActionResult Post(Product product){

            if(product is null){
                return BadRequest();
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("product", new {id = product.Id}, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product product){
            if(id != product.Id){
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        } 

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var product = _context.Products.FirstOrDefault(product => product.Id == id);

            if(product is null){
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }

    }
}
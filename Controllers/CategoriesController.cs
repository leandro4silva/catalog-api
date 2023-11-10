using ApiCatalog.Context;
using ApiCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalog.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get(){
            var category = _context.Categories.ToList();

            if(category is null){
                return NotFound("Resource not found.");
            }

            return category;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Category> Get(int id){
            var category = _context.Categories.FirstOrDefault(product => product.Id == id);

            if(category is null){
                return NotFound("Resource not found.");
            }

            return category;
        }
    }
}
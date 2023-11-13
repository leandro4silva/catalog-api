using ApiCatalog.Context;
using ApiCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var category = _context.Categories.AsNoTracking().Include(category => category.Products).ToList();
                return Ok(category);
            }
            catch (Exception)
            {     
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name="category")]
        public ActionResult<Category> Get(int id){
            try
            {
                var category = _context.Categories.AsNoTracking().Include(category => category.Products).FirstOrDefault(product => product.Id == id);

                if(category is null){
                    return NotFound($"Categoria com o id={id} não encontrada...");
                }

                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }     
        }

        [HttpPost]
        public ActionResult Post(Category category){
            try
            {
                if(category is null){
                    return BadRequest();
                }

                _context.Categories.Add(category);
                _context.SaveChanges();

                return new CreatedAtRouteResult("category", new {id = category.Id}, category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category){
            try
            {   
                if(id != category.Id){
                    return BadRequest();
                }

                _context.Entry(category).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            try
            {
                var category = _context.Categories.FirstOrDefault(category => category.Id == id);

                if(category is null){
                    return NotFound("Category not found");
                }

                _context.Categories.Remove(category);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }
        }
    }
}
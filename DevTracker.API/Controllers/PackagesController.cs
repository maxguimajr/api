using DevTracker.API.Entities;
using DevTracker.API.Models;
using DevTracker.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevTracker.API.Controllers
{
    [ApiController]
    [Route("api/packages")]
    public class PackagesController : ControllerBase
    {

        private readonly DevTrackerContext _context;
        public PackagesController(DevTrackerContext context)
        {
            _context = context;
        }

        //GET   api/packages
        [HttpGet]
        public IActionResult GetAll()
        {
            var packages = _context.Packages;
            return Ok(packages);
        }


        //GET  api/packages/{code}
        [HttpGet("{code}")]

        public IActionResult GetByCode(string code)
        {
            var package = _context
            .Packages
            .SingleOrDefault(p => p.Code == code);

            if(package == null){
                return NotFound();
            }

            return Ok(package);
        }

        //POST api/packages
        [HttpPost]

        public IActionResult Post(AddPackageInputModel model)
        {
            if(model.Title.Length < 10){
                return BadRequest("Tamanho do titulo é menor que 10 caracters");
            }
            
            var package = new Package(model.Title, model.Weight);

            _context.Packages.Add(package);

            return CreatedAtAction("GetByCode", new {code = package.Code},package);
        }

        //POST api/packages/1212121-12121212/updates
        [HttpPost("{code}/updates")]
        public IActionResult PostUpdate(string code, AddPackageUpdateInputModel model)
        {
            var package = _context.Packages.SingleOrDefault(p => p.Code == code);
                
                if(package == null){
                
                return NotFound();
                
                }


            package.AddUpdate(model.Status, model.Delivered);

            return NoContent();
        }
    }
}
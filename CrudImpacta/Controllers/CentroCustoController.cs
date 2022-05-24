using CrudImpacta.Entidades;
using CrudImpacta.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudImpacta.Controllers
{

    [ApiController]
    [Route("api/centrocusto")]
    public class CentroCustoController : ControllerBase
    {
        private readonly ApiContext _context;

     public CentroCustoController(ApiContext context)
     {
         _context = context;
     }

     [HttpGet("{codigo}")]
     public IActionResult GetByCode(int codigo)
     {
         var centrocusto = _context.CentroCusto.SingleOrDefault(p => p.Codigo == codigo);
         
         if (centrocusto == null)
         {
             return NotFound();
         }
         return Ok(centrocusto);
     }

     [HttpGet]
     public IActionResult GetAll()
     {
         var centrocusto = _context.CentroCusto;
         return Ok(centrocusto);

     }
     [HttpPost]
     public IActionResult Post(CentroCusto model)
     {
         var centrocusto = new CentroCusto(model.Codigo, model.Nome, (DateTime)model.DataInicio, (DateTime)model.DataFim);
         _context.CentroCusto.Add(centrocusto);
         _context.SaveChanges();

         return Ok();
     }

     [HttpPut("{codigo}")]
     public IActionResult Put(AddCentroCusto model, int codigo)
     {
         var centrocusto = _context.CentroCusto.SingleOrDefault(p => p.Codigo == codigo);
         

         return Ok();

     }

    }
}
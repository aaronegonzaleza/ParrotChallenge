using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {

        private readonly APIContext _context;

        public ReporteController(APIContext context)
        {
            _context = context;
        }

        // GET api/<ReporteController>/5
        [HttpGet("{finicio}/{ffin}")]
        public ActionResult Get(DateTime finicio, DateTime ffin)
        {
           
                //var x = _context.Ordenes.Include(i => i.Detalles).Include(i => i.Usuario);
                var reporte = _context.DetallesOrdenes.Include(i => i.Producto).Include(i => i.Orden).Where(w => w.Orden.Fecha >= finicio && w.Orden.Fecha <= ffin).ToList().GroupBy(gb => gb.Producto.NombreProducto).OrderByDescending(ob => ob.Sum(S => S.Cantidad)).ToList().Select(s => new { NombreProducto = s.Key, CantidadTotal = s.Sum(s => s.Cantidad), PrecionTotal = s.Sum(s => s.Orden.Total) }).ToList();
                return Ok(reporte);
          
       
    }
}

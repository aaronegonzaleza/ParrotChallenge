using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Context;
using API.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly APIContext _context;

        public OrdenesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Ordenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenes()
        {
            return await _context.Ordenes.ToListAsync();
        }

        // GET: api/Ordenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orden>> GetOrden(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);

            if (orden == null)
            {
                return NotFound();
            }

            return orden;
        }

        // PUT: api/Ordenes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrden(int id, Orden orden)
        {
            if (id != orden.OrdenId)
            {
                return BadRequest();
            }

            _context.Entry(orden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ordenes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Orden>> PostOrden(Orden orden)
        {
            if (!_context.Usuarios.Any(a => a.Email == orden.Usuario.Email))
                return Unauthorized("Usuario No Existe");
            else
            {
                orden.Usuario = _context.Usuarios.Find(orden.Usuario.Email);
            }
            
            orden.Detalles = orden.Detalles.GroupBy(gb => gb.Producto.NombreProducto).Select(s => new DetalleOrden() { Producto = new Producto() { NombreProducto = s.Key, PrecioUnitario = s.Average(a => a.Producto.PrecioUnitario) },Cantidad = s.Sum(s=> s.Cantidad) }).ToList();
           

            foreach(var d in orden.Detalles)
            {
                if (!_context.Productos.Any(a => a.NombreProducto == d.Producto.NombreProducto))
                {
                    _context.Productos.Add(d.Producto);
                }
                else
                {
                    d.Producto = _context.Productos.Where(w => w.NombreProducto == d.Producto.NombreProducto).FirstOrDefault();
                }
            }
            //orden.Productos = orden.Productos.GroupBy(gb => gb.NombreProducto).Select(s => new Producto() { NombreProducto = s.Key, Cantidad = s.Sum(s => s.Cantidad), PrecioUnitario = s.Average(s => s.PrecioUnitario) }).ToList();
            //orden.Usuario = _context.Usuarios.Find(orden.Usuario.Email);
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrden", new { id = orden.OrdenId }, null);
        }

        // DELETE: api/Ordenes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orden>> DeleteOrden(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();

            return orden;
        }

        private bool OrdenExists(int id)
        {
            return _context.Ordenes.Any(e => e.OrdenId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        [Column(TypeName = "Money")]
        public decimal PrecioUnitario { get; set; }

        public List<DetalleOrden> DetalleOrdens;
    }
}

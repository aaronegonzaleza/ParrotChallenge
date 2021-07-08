using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Orden
    {
        public int OrdenId { get; set; }        
        public Usuario Usuario { get; set; }
        [Column(TypeName = "Money")]
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleOrden> Detalles { get; set; }
    }
}

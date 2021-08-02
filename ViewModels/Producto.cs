using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Models
{
    public class Producto
    {
        public int Id{get; set;}
        public string Nombre{get; set;}
        public string CodBarra { get; set; }
        public decimal Precio { get; set; }


    }
}

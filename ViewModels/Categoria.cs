using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Models
{
    public class Categoria
    {
        public int Id {get; set;}
        public string Nombre{get; set;}
        public Subcategoria _subcategoria { get; set; }
     }
}

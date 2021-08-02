using ApiRestProducto.DataAccess;
using BuildRestApiNetCore.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Models
{
    public class SubcategoriaDTO 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

}

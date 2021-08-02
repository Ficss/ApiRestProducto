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
    public class Marca
    {
        [Key]
        [Required]
        [Display(Name = "Número de marca")]
        [Range(1, Double.MaxValue, ErrorMessage = "El valor del id debe ser mayor a 0")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de marca")]
        public string Nombre{ get; set; }

        //[ForeignKey("Producto")]
        //public int productoId { get; set; }

        //[ForeignKey("Producto")]
        public ICollection<Producto> Producto { get; set; }
    }

    public static class MarcaSeed
    {
        public static void InitData(BBDDContext context)
        {
            var rnd = new Random();

            var nombre = new[] { "Nike", "Adidas", "Under Armour", "Reebook", "Puma" };

            context.Marcas.AddRange(6.Times(x =>
            {
                var productId = x;
                var adjective = nombre[rnd.Next(0,5)];
                return new Marca
                {
                    Id = productId,
                    Nombre = $"{adjective}"
                };
            }));

            context.SaveChangesAsync();
        }
    }
}

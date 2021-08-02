using ApiRestProducto.DataAccess;
using BuildRestApiNetCore.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Models
{
    public class Producto
    {
        [Key]
        [Required]
        [Display(Name = "Número de producto")]
        [Range(1, Double.MaxValue, ErrorMessage = "El valor del id debe ser mayor a 0")]
        public int Id{get; set;}
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre{get; set;}
        [Required]
        [Display(Name = "Código de barra")]
        public string CodBarra { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }


        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

    }

    public static class ProductSeed
    {
        public static void InitData(BBDDContext context)
        {
            //var rnd = new Random();

            //var _nombre = new[] { "Small", "Ergonomic", "Rustic", "Smart", "Sleek" };
            //var _codbarra = new[] { "Steel", "Wooden", "Concrete", "Plastic", "Granite", "Rubber" };

            //context.Products.AddRange(900.Times(x =>
            //{
            //    var adjective = _nombre[rnd.Next(0, 5)];
            //    var material = materials[rnd.Next(0, 5)];
            //    var department = departments[rnd.Next(0, 5)];
            //    var productId = $"{x,-3:000}";

            //    return new Producto
            //    {
            //        ProductNumber = $"{department.First()}{name.First()}{productId}",
            //        Name = $"{adjective} {material} {name}",
            //        Price = (double)rnd.Next(1000, 9000) / 100,
            //        Department = department
            //    };
            //}));

            //context.SaveChanges();
        }
    }
}


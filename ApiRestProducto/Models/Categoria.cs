using ApiRestProducto.DataAccess;
using BuildRestApiNetCore.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        [Display(Name = "Número de categoria")]
        [Range(1, Double.MaxValue, ErrorMessage = "El valor del id debe ser mayor a 0")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de categoria")]
        public string Nombre { get; set; }
        
        public ICollection<Producto> Producto { get; set; }
        public ICollection<SubcategoriaDTO> Subcategoria { get; set; }
    }

    public static class CategoriaSeed
    {
        public static void InitData(BBDDContext context)
        {
            var rnd = new Random();

            var nombre = new[] { "Zapatillas", "Pantalones", "Shorts", "Camisetas", "Poleras", "Polerones", "Chaquetas" };

            context.Categorias.AddRange(7.Times(x =>
            {
                var _categoriaId = x;
                var _nombre = nombre[x-1];
                
                return new Categoria
                {
                    Id = _categoriaId,
                    Nombre = $"{_nombre}"
                    
                };
            }));

            context.SaveChangesAsync();
        }
    }
}

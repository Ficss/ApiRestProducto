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
    public class Subcategoria
    {
        [Key]
        [Required]
        [Display(Name = "Número de subcategoria")]
        [Range(1, Double.MaxValue, ErrorMessage = "El valor del id debe ser mayor a 0")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de subcategoria")]
        public string Nombre { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }

    public static class SubcategoriaSeed
    {
        public static void InitData(BBDDContext context)
        {
            var rnd = new Random();

            var nombre = new[] { "Fútbol", "Running", " Training", "Estilo de vida", "Basketball"};
            

            context.Subcategorias.AddRange(5.Times(x =>
            {
                var _subcategoriaId = x;
                var _nombre = nombre[x - 1];
                var _categoriaId = x;
                return new Subcategoria
                {
                    Id = _subcategoriaId,
                    Nombre = $"{_nombre}",
                    CategoriaId = _categoriaId
                };
            }));

            context.SaveChangesAsync();
        }
    }
}

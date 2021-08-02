using ApiRestProducto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRestProducto.DataAccess
{
    public class BBDDContext : DbContext, IBBDDContext
    {
        public BBDDContext(DbContextOptions<BBDDContext> options) : base(options)
        {

        }
        public DbSet<Producto> Products { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Categoria> Categorias{ get; set; }
        public DbSet<Subcategoria> Subcategorias{ get; set; }
        public DbSet<SubcategoriaDTO> SubcategoriasDTO { get; set; }

        public int SaveChanges(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

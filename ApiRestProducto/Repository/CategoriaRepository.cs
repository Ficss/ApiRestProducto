using ApiRestProducto.DataAccess;
using ApiRestProducto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Repository
{
    public class CategoriaRepository : IDataRepository<Categoria>
    {
        private readonly IBBDDContext _categoriaDb;
        public CategoriaRepository(IBBDDContext context)
        {
            _categoriaDb = context;
        }

        public void Add(Categoria model)
        {
            _categoriaDb.Categorias.AddAsync(model);
            _categoriaDb.SaveChangesAsync();
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _categoriaDb.Categorias.ToList();
        }

        public Categoria Get(int id)
        {
            return _categoriaDb.Categorias.Find(id);
        }

        public void Change(Categoria model, Categoria entity)
        {

            model.Nombre = entity.Nombre;
            _categoriaDb.Categorias.Update(model);
            _categoriaDb.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = Get(id);

            _categoriaDb.Categorias.Remove(entity);
            _categoriaDb.SaveChangesAsync();

        }
    }
}

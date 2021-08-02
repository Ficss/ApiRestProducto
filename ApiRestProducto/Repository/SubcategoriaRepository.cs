using ApiRestProducto.DataAccess;
using ApiRestProducto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Repository
{
    public class SubcategoriaRepository : IDataRepository<Subcategoria>
    {
        private readonly IBBDDContext _subcategoriaDb;
        public SubcategoriaRepository(IBBDDContext context)
        {
            _subcategoriaDb = context;
        }

        public void Add(Subcategoria model)
        {
            _subcategoriaDb.Subcategorias.AddAsync(model);
            _subcategoriaDb.SaveChangesAsync();
        }

        public IEnumerable<Subcategoria> GetAll()
        {
            return _subcategoriaDb.Subcategorias.ToList();
        }

        public Subcategoria Get(int id)
        {
            return _subcategoriaDb.Subcategorias.Find(id);
        }

        public void Change(Subcategoria model, Subcategoria entity)
        {
            model.Nombre = entity.Nombre;
            _subcategoriaDb.Subcategorias.Update(model);
            _subcategoriaDb.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = Get(id);
            _subcategoriaDb.Subcategorias.Remove(entity);
            _subcategoriaDb.SaveChangesAsync();

        }
    }
}

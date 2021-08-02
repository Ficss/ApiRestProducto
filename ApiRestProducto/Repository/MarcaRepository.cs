using ApiRestProducto.DataAccess;
using ApiRestProducto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Repository
{
    public class MarcaRepository : IDataRepository<Marca>
    {
        private readonly IBBDDContext _marcaDb;
        public MarcaRepository(IBBDDContext context)
        {
            _marcaDb = context;
        }

        public void Add(Marca model)
        {
            _marcaDb.Marcas.AddAsync(model);
            _marcaDb.SaveChangesAsync();
        }

        public IEnumerable<Marca> GetAll()
        {
            return _marcaDb.Marcas.ToList();
        }

        public Marca Get(int id)
        {
            return _marcaDb.Marcas.Find(id);
        }

        public void Change(Marca model, Marca entity)
        {
            model.Nombre = entity.Nombre;
            _marcaDb.Marcas.Update(model);
            _marcaDb.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = Get(id);

            _marcaDb.Marcas.Remove(entity);
            _marcaDb.SaveChangesAsync();

        }
    }
}

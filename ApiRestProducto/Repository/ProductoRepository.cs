using ApiRestProducto.DataAccess;
using ApiRestProducto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Repository
{
    public class ProductoRepository : IDataRepository<Producto>
    {
        private readonly IBBDDContext _productoDb;
        public ProductoRepository(IBBDDContext context)
        {
            _productoDb = context;
        }

        public void Add(Producto model)
        {
            _productoDb.Products.AddAsync(model);
            _productoDb.SaveChangesAsync();
        }

        public IEnumerable<Producto> GetAll()
        {
            return _productoDb.Products.ToList();
        }

        public Producto Get(int id)
        {
            return _productoDb.Products.Find(id);
        }

        public void Change(Producto model, Producto entity)
        {
            model.Nombre = entity.Nombre;
            _productoDb.Products.Update(model);
            _productoDb.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = Get(id);
            _productoDb.Products.Remove(entity);
            _productoDb.SaveChangesAsync();

        }
    }
}

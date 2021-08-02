using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProducto.Repository
{
    public interface IDataRepository<TEntity>
    {
        void Add(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Change(TEntity dbEntity, TEntity entity);
        Task Delete(int id);
    }
}

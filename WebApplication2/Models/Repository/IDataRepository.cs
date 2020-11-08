using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.Repository
{
    public interface IDataRepository<TEntity, TDTO>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task<TDTO> GetDto(int id);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
    }
}

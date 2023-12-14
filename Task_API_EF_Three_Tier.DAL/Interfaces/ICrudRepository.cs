using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_API_EF_Three_Tier.DAL.Interfaces
{
    public interface ICrudRepository<TKey, TEntity> : IReadRepository<TKey, TEntity>
    {
        Task<int> Create(TEntity entity);

        Task<bool> Update(TEntity oldEntity, TEntity entity);

        Task<bool> Delete(TEntity entity);

    }
}

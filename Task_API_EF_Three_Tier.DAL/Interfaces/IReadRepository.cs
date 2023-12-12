using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_API_EF_Three_Tier.DAL.Interfaces
{
    public interface IReadRepository<TKey, TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(TKey id);


    }
}

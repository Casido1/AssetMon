using AssetMon.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Repositories.Implementation
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public void Create(T Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T Entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}

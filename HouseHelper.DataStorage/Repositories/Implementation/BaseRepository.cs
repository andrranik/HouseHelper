using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseHelper.DataStorage.Repositories.Interfaces;

namespace HouseHelper.DataStorage.Repositories.Implementation
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        #region get data

        public abstract IEnumerable<T> Get();
        public abstract T Get(Guid id);
        public abstract Task<IEnumerable<T>> GetAsync(/*Filter*/);
        public abstract Task<T> GetAsync(Guid id);
        
        #endregion

        #region insert data

        public abstract Task<Guid> Insert(T item);
        
        #endregion

        #region update data

        public abstract Task<Guid> Update(T item);

        #endregion

        #region delete data

        public abstract Task Delete(Guid id);

        #endregion
    }
}
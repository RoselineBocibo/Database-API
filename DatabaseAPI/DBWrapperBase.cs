using System.Collections.Generic;

namespace DatabaseAPI
{
    public abstract class DBWrapperBase<B> : IDBWrapper<B>
    {
        public DBWrapperBase()
        {
            
        }
        public abstract int CreatEntity(B entity);
        public abstract int Delete(B entity);
        public abstract IEnumerable<B> Select(B entity);
        public abstract int Update(B entity);
    }
}

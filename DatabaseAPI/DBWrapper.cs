using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;


namespace DatabaseAPI
{
    public class DBWrapper<C> : DBWrapperBase<C> 
        where C : class
    {
        private readonly DatabaseContext<C> databaseContext;
        private DbSet<C> entities;

        public DBWrapper(DatabaseContext<C> databaseContext)
        {
            this.databaseContext = databaseContext;
            entities = databaseContext.Set<C>();
        }

        public override int CreatEntity(C entity)
        {
            entities.Add(entity);
            var rowCount = databaseContext.SaveChanges();
            return rowCount;
        }

        public override int Delete(C entity)
        {
            databaseContext.Entry<C>(entity).State = EntityState.Deleted;
                
            var rowCount = databaseContext.SaveChanges();
            return rowCount;
        }

        public override IEnumerable<C> Select(C entity)
        {
            return entities.AsEnumerable();
        }

        public override int Update(C entity)
        {
            databaseContext.Entry<C>(entity).State = EntityState.Modified;
            var rowCount = databaseContext.SaveChanges();
            return rowCount;
        }
    }
}

using System.Data.Entity;

namespace DatabaseAPI
{
    public class DatabaseContext<T> : DbContext  where T : class
    {
        public DatabaseContext() : base("DatabaseConnection")
        {
            
        }
    
        public DbSet<T> Entity { get; set; }

    }
}

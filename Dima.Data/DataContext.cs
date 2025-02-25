using Dima.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Dima.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get { return Set<User>(); } }

        public DataContext()
        {
            Database.EnsureCreated();
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}

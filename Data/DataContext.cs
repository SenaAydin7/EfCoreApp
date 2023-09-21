using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class DataContext: DbContext
    {
        public  DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {

        }
        public DbSet<Shops>Shops => Set<Shops>();
        public DbSet<Cars>Car => Set<Cars>();
        public DbSet<ShopReg>ShopReg => Set<ShopReg>();
        public DbSet<Owner>Owners => Set<Owner>();
    }
}   //code-first => entity, dbcontext => database (sqlite)
    //databse-first => sql server
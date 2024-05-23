using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace API.db
{
    public class appContext : DbContext
    {
        public appContext(DbContextOptions<appContext> db) : base(db)
        {
            Database.EnsureCreated();
        }
    }
}

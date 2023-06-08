using Microsoft.EntityFrameworkCore;

namespace testWebApiCore.DBContext
{
    public class DbContext2 : DbContext
    {
        public DbContext2(DbContextOptions options)
          : base(options)
        {

        }
    }
}

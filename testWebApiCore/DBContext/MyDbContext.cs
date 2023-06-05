using Microsoft.EntityFrameworkCore;
using testWebApiCore.Models;

namespace testWebApiCore.DBContext
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions options)
          : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


    }
}

using Microsoft.EntityFrameworkCore;
using Next2App4.Models;

namespace Next2App4.Data
{
    public class Next2DbContext : DbContext
    {

        public Next2DbContext(DbContextOptions<Next2DbContext> options) : base(options) { }


        public DbSet<Employee> Employees { get; set; }
        public DbSet <Student> Students { get; set; }  

        public DbSet<Course> courses { get; set; }

    }
}

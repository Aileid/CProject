using System.Data.Entity;

namespace CProject
{
    public class Context : DbContext
    {
        

        public Context() : base("Data Source=.\\SQLEXPRESS;Initial Catalog=CPROJECT;Integrated Security=False;Password=admin;User ID=admin")
        {

        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}

using DatabaseImplements.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplements
{
    class DatabaseImplement : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
                base.OnConfiguring(optionsBuilder);
            }
        }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}

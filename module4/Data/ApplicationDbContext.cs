using Microsoft.EntityFrameworkCore;
using module4.Domain;

namespace module4.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {

        }

        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set;}
        
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //         // modelBuilder.Entity<Product>().ToTable("Produto");
    //         // modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(100);

    //         // modelBuilder.Entity<Category>().ToTable("Categoria");
    //         // modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired().HasMaxLength(100);

    //         /*
    //             adicioanndo Migrations:                                 dotnet ef migrations add InitialCreate
    //             Voltando um mIgrations especifico:                      dotnet ef database update "NomeDaMigrarion"
    //             Removevendo todos migrations que não form para o DB:    dotnet ef migrations remove                

    //          */
            
    //    }
    }
}
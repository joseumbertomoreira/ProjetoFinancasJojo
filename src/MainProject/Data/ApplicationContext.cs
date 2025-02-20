using MainProject.Data.Configurations;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MainProject.Data;

public class ApplicationContext : DbContext
{

    public DbSet<ClasseCompra> ClassesCompra { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClasseCompraConfiguration());
    }

}

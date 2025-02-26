using MainProject.Data.Configurations;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MainProject.Data;

public class ApplicationContext : DbContext
{

    public DbSet<ClasseCompra> ClassesCompra { get; set; }
    public DbSet<TipoPagamento> TiposPagamento { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClasseCompraConfiguration());
        modelBuilder.ApplyConfiguration(new TipoPagamentoConfiguration());
        modelBuilder.ApplyConfiguration(new CompraConfiguration());
        modelBuilder.ApplyConfiguration(new PagamentoConfiguration());
    }

}

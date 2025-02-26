using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainProject.Data.Configurations;

public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.ToTable("Pagamento");
        builder.HasKey(p => p.Id);
        builder.Property(c => c.Valor).HasColumnType("DECIMAL(18,2)");
        builder.Property(c => c.NumeroParcela).HasColumnType("INT");
        builder.Property(c => c.DataPagamento).HasColumnType("DATE");

        builder.HasOne(p => p.TipoPagamento)
               .WithMany()
               .HasForeignKey(p => p.TipoPagamentoId);

        builder.HasOne(p => p.Compra)
               .WithMany(c => c.Pagamentos)
               .HasForeignKey(p => p.CompraId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}

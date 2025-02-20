using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainProject.Data.Configurations;

public class TipoPagamentoConfiguration : IEntityTypeConfiguration<TipoPagamento>
{
    public void Configure(EntityTypeBuilder<TipoPagamento> builder)
    {
        builder.ToTable("TipoPagamento");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasColumnType("VARCHAR(60)");
        builder.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
    }
}

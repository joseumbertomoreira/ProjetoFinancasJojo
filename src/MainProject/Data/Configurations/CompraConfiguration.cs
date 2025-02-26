using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainProject.Data.Configurations;

public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("Compra");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
            
        builder.Property(c => c.QtdParcela).HasColumnType("INT");
        builder.Property(c => c.ParcelasPagas).HasColumnType("INT");
        builder.Property(c => c.DataCompra).HasColumnType("DATE");

        builder.HasOne(c => c.ClasseCompra)
               .WithMany()
               .HasForeignKey("ClasseCompraId")
               .IsRequired();

    }
}

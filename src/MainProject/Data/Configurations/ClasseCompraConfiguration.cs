using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainProject.Data.Configurations;

public class ClasseCompraConfiguration : IEntityTypeConfiguration<ClasseCompra>
{
    public void Configure(EntityTypeBuilder<ClasseCompra> builder)
    {
        builder.ToTable("ClasseCompra");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasColumnType("VARCHAR(60)");
        builder.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
    }
}

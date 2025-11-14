using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupllyHub.Business.Models;

namespace SupllyHub.Data.Mappings;
public class SupplierMapping : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Document)
            .IsRequired()
            .HasColumnType("varchar(14)");

        // 1 : 1
        builder.HasOne(p => p.Address)
            .WithOne(e => e.Supplier);

        // 1 : N
        builder.HasMany(p => p.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);


        builder.ToTable("TBSUPPLIER");
    }
}
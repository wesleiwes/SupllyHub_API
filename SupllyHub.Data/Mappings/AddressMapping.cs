using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupllyHub.Business.Models;

namespace SupllyHub.Data.Mappings;
public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(p=>p.Id);

        builder.Property(a => a.Street)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(a => a.Number)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(a => a.ZipCode)
            .HasColumnType("varchar(250)");

        builder.Property(a => a.Neighborhood)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(a => a.City)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(a => a.State)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.ToTable("TBADDRESS");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferGen.Entities.Models;
using System.Reflection.Emit;

namespace OfferGen.Repository.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(c => c.Id)
                 .HasDefaultValueSql("NEWSEQUENTIALID()");

        // indeksi za brzu pretragu    
        builder.HasIndex(c => c.TaxIdentifier)
            .HasDatabaseName("IX_Company_TaxIdentifier")
        .IsUnique();

        builder.HasIndex(c => c.RegistrationNumber)
           .HasDatabaseName("IX_Company_RegistrationNumber")
           .IsUnique();

        // OwnsOne koristi se da bi se oznacilo da je Address deo entiteta Company, a ne zaseban entitet u bazi. EF core ce tretirati ovaj slozeni tip kao deo tabele Company
        builder.OwnsOne(c => c.CompanyAddress);

        builder.OwnsOne(c => c.CompanyContactInfo);
    }
}

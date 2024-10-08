using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferGen.Entities.Models;

namespace OfferGen.Repository.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Clients>
{
    public void Configure(EntityTypeBuilder<Clients> builder)
    {
       builder.Property(cl => cl.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.HasIndex(cl => cl.TaxIdentifier)
           .HasDatabaseName("IX_Clients_TaxIdentifier")
        .IsUnique();

        builder.HasIndex(cl => cl.RegistrationNumber)
           .HasDatabaseName("IX_Clients_RegistrationNumber")
        .IsUnique();

        builder.OwnsOne(cl => cl.ClientAddress);

        builder.OwnsOne(cl => cl.ClientContactInfo);
    }
}

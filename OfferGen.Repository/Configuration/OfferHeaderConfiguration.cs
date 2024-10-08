using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferGen.Entities.Models;
using OfferGen.Entities.Models.CompanyRelations;
using System.Reflection.Emit;

namespace OfferGen.Repository.Configuration;

public class OfferHeaderConfiguration : IEntityTypeConfiguration<OfferHeader>
{
    public void Configure(EntityTypeBuilder<OfferHeader> builder)
    {
        builder.HasIndex(of => of.CompanyId)
              .HasDatabaseName("IX_OfferHeader_CompanyId");

       builder.HasOne(of => of.Company)
            .WithOne(c => c.OfferHeader)
            .HasForeignKey<OfferHeader>(of => of.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

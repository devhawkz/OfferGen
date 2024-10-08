using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferGen.Entities.Models.CompanyRelations;
using System.Reflection.Emit;

namespace OfferGen.Repository.Configuration;

public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccounts>
{
    public void Configure(EntityTypeBuilder<BankAccounts> builder)
    {
        builder.Property(ba => ba.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.HasIndex(ba => ba.CompanyId)
            .HasDatabaseName("IX_BankAccounts_CompanyId");

        builder.OwnsOne(ba => ba.AccountDetails);

        builder.HasOne(ba => ba.Company)
            .WithMany(c => c.Accounts)
            .HasForeignKey(ba => ba.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

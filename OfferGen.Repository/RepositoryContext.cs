using Microsoft.EntityFrameworkCore;
using OfferGen.Entities.Models;
using OfferGen.Entities.Models.CompanyRelations;

namespace OfferGen.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<OfferHeader> OfferHeaders { get; set; }
        public DbSet<BankAccounts> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .Property(c => c.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            
            // OwnsOne koristi se da bi se oznacilo da je Address deo entiteta Company, a ne zaseban entitet u bazi. EF core ce tretirati ovaj slozeni tip kao deo tabele Company
            modelBuilder.Entity<Company>()
                .OwnsOne(c => c.Address); 

            modelBuilder.Entity<Company>()
                .OwnsOne(c => c.Email);

            modelBuilder.Entity<BankAccounts>()
                .Property(ba => ba.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<BankAccounts>()
                .OwnsOne(ba => ba.AccountDetails);
        }
    }
}

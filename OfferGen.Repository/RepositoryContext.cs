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
        public DbSet<BankAccounts> OfferHeaders { get; set; }
        public DbSet<BankAccounts> BankAccounts { get; set; }

        public DbSet<Clients> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryContext).Assembly);
        }
    }
}

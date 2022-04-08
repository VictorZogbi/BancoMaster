using MasterBank.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterBank.Data.Context
{
    public class MasterBankDbContext : DbContext
    {
        public MasterBankDbContext(DbContextOptions<MasterBankDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MasterBankDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
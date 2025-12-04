


using ChequeBook.Domain;
using ChequeBook.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ChequeBook.Infrastructure.DataConnection
{
    public class CQDataConnection : DbContext
    {
        public CQDataConnection(DbContextOptions<CQDataConnection> options)
          : base(options)
        {
        }

        ////Entity       

        public DbSet<Menu> Menu { get; set; }
        public DbSet<Bank> Bank { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().HasKey(c => c.BankId);
            modelBuilder.Entity<Menu>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}

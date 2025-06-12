using Microsoft.EntityFrameworkCore;
using Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities;

namespace Visionamos.MyKeys.DataAccess.OpenBanking.Context
{
    public class ManageKeysDbContext : DbContext
    {
        public DbSet<KeyCustomer> KeyCustomers { get; set; }
        public DbSet<KeyProcess> KeyProcess { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<KeyState> KeyStates { get; set; }

        public ManageKeysDbContext(DbContextOptions<ManageKeysDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KeyCustomer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("KCM_GGID");
                entity.Property(e => e.Date).HasMaxLength(8);
                entity.Property(e => e.Hour).HasMaxLength(6);
                entity.Property(e => e.Sequence).HasMaxLength(16);
                entity.Property(e => e.Channel).HasMaxLength(10);
                entity.Property(e => e.TypeKeyCustomer).HasMaxLength(1);
                entity.Property(e => e.ValueKeyCustomer).HasMaxLength(16);
                entity.Property(e => e.SourceEntity).HasMaxLength(10);
                entity.Property(e => e.SourceNumberAccount).HasMaxLength(34);
                entity.Property(e => e.SourceTypeAccountDescription).HasMaxLength(100);
                entity.Property(e => e.SourceIdentification).HasMaxLength(20);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.SecondName).HasMaxLength(50).IsRequired(false);
                entity.Property(e => e.SurName).HasMaxLength(50);
                entity.Property(e => e.SecondSurName).HasMaxLength(50).IsRequired(false);
                entity.Property(e => e.User).HasMaxLength(50);

                // Relaciones
                entity.HasOne(k => k.KeyProcess)
                    .WithMany(propa => propa.KeyCustomers)
                    .HasForeignKey(k => k.ProcessKeyCustomerCode);

                entity.HasOne(k => k.AccountType)
                    .WithMany(a => a.KeyCustomers)
                    .HasForeignKey(k => k.SourceAccountTypeCode);

                entity.HasOne(k => k.DocumentType)
                    .WithMany(d => d.KeyCustomers)
                    .HasForeignKey(k => k.SourceIdentificationTypeCode);

                entity.HasOne(k => k.KeyState)
                    .WithMany(s => s.KeyCustomers)
                    .HasForeignKey(k => k.KeyStateCode);

                // Índices
                entity.HasIndex(e => e.ValueKeyCustomer).IsUnique();
                entity.HasIndex(e => e.SourceIdentification);
                entity.HasIndex(e => e.Sequence).IsUnique();
                entity.HasIndex(e => new { e.SourceIdentification, e.ValueKeyCustomer });
            });

            modelBuilder.Entity<KeyProcess>().HasKey(p => p.Code);
            modelBuilder.Entity<AccountType>().HasKey(p => p.Code);
            modelBuilder.Entity<DocumentType>().HasKey(p => p.Code);
            modelBuilder.Entity<KeyState>().HasKey(p => p.Code);
            base.OnModelCreating(modelBuilder);
        }
    }
}
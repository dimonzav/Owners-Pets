namespace DataAccess
{
    using System;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;
    using DataAccess.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public partial class OwnerPetsContext : DbContext
    {
        public OwnerPetsContext(DbContextOptions<OwnerPetsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }

        public virtual DbSet<Pet> Pets { get; set; }


        public IDbContextTransaction BeginTransaction()
        {
            return this.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }
}

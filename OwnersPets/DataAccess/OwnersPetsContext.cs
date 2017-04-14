using System;

namespace DataAccess
{
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using DataAccess.Entities;

    public partial class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

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

        public virtual DbSet<Owner> Owners { get; set; }

        public virtual DbSet<Pet> Pets{ get; set; }
    }
}

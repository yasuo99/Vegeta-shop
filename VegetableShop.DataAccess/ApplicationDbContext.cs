using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VegetableShop.Domain.Models;
using VegetableShop.Domain.Models.BaseModel;

namespace VegetableShop.DataAccess
{
    public class ApplicationDbContext: IdentityDbContext<Account, Role, Guid, IdentityUserClaim<Guid>, AccountRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        //{
        //    dbContextOptionsBuilder.UseSqlServer();
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("VS");
            builder.Entity<Account>(account =>
            {
                account.HasMany(m => m.Orders).WithOne(o => o.Account).OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.Entity<AccountAddress>(accountAddress =>
            {
                accountAddress.HasKey(key => new { key.AccountId, key.AddressId });
            });

            builder.Entity<ProviderAddress>(providerAddress =>
            {
                providerAddress.HasKey(key => new { key.ProviderId, key.AddressId });
            });
            builder.Entity<OTP>(otp =>
            {
                otp.Property(prop => prop.Method).HasConversion<int>();
            });
            builder.Entity<Order>(order =>
            {
                order.Property(prop => prop.OrderStatuses).HasConversion<string>();
            });
            builder.Entity<OrderDetail>(orderDetail =>
            {
                orderDetail.HasKey(key => new { key.OrderId, key.ProductId });
            });
            builder.Entity<Question>(question =>
            {
                question.HasKey(key => new { key.AccountId, key.ProductId });
                question.HasOne(o => o.Account).WithMany(m => m.Questions).OnDelete(DeleteBehavior.Cascade);
                question.HasOne(o => o.Product).WithMany(m => m.Questions).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<Review>(review =>
            {
                review.HasKey(key => new { key.OrderId, key.ProductId });
            });
;        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is AuditEntity<Guid> && (e.State == EntityState.Modified || e.State == EntityState.Added)).ToList();
            var httpContextAccessor = this.GetService<IHttpContextAccessor>();
            if(entries.Count > 0)
            {
                foreach(var entry in entries)
                {
                    if(entry.State == EntityState.Added)
                    {
                        ((AuditEntity<Guid>)entry.Entity).CreateAt = DateTime.Now;
                        ((AuditEntity<Guid>)entry.Entity).CreatedBy = httpContextAccessor.HttpContext.User.Identity.Name ?? "System";
                    }
                    if(entry.State == EntityState.Modified)
                    {
                        Entry((AuditEntity<Guid>)entry.Entity).Property(p => p.CreateAt).IsModified = false;
                        Entry((AuditEntity<Guid>)entry.Entity).Property(p => p.CreatedBy).IsModified = false;
                        ((AuditEntity<Guid>)entry.Entity).ModifiedAt = DateTime.Now;
                        ((AuditEntity<Guid>)entry.Entity).ModifiedBy = httpContextAccessor.HttpContext.User.Identity.Name ?? "System";
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

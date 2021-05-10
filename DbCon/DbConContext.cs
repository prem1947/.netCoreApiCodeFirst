using Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DbCon
{
    public class DbConContext : DbContext
    {
        public DbConContext(DbContextOptions<DbConContext> options): base(options)
        {
            
        }
        public virtual DbSet<EmployeeDomain> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

namespace StonksWeb
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=Database")
        {
        }

        public virtual DbSet<DBFinancialPlan> DBFinancialPlans { get; set; }
        public virtual DbSet<DBUser> DBUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBUser>()
                .HasMany(e => e.DBFinancialPlans)
                .WithRequired(e => e.DBUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DBUser>()
                .HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}

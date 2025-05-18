using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistance
{
   public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>()
                .HasMany(a => a.SubCategories)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(a => a.Id).IsClustered();
                entity.Property(a => a.Id).ValueGeneratedOnAdd();
                entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(a => a.Status)
                .IsRequired();

            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(a => a.Status)
                .IsRequired();

            });
        }
    }
}

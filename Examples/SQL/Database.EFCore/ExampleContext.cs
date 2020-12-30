using System;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.EFCore
{
    public partial class ExampleContext : DbContext
    {
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        
        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<BookEntity>(entity =>
            {
                entity.ToTable("Book");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(d => d.Author);
            });

            modelBuilder.Entity<AuthorEntity>(entity =>
            {
                entity.ToTable("Author");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });
            
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 1, Name = "Freezing" });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 2, Name = "Bracing" });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 3, Name = "Chilly" });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 4, Name = "Cool" });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 5, Name = "Mild" });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 6, Name = "Warm" });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 7, Name = "Balmy" });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 8, Name = "Hot" });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 9, Name = "Sweltering" });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity { Id = 10, Name = "Scorching" });
            
            modelBuilder.Entity<BookEntity>().HasData(new
            {
                Id = 1, 
                TimeStamp = new DateTime(2020, 1, 1),
                Title = "Test",
                AuthorId = 3
            });
            
            modelBuilder.Entity<BookEntity>().HasData(new
            {
                Id = 2, 
                TimeStamp = new DateTime(2020, 1, 2),
                Title = "Example",
                AuthorId = 5
            });
            
            modelBuilder.Entity<BookEntity>().HasData(new
            {
                Id = 3, 
                TimeStamp = new DateTime(2020, 1, 3),
                Title = "Sample",
                AuthorId = 1
            });
            
            //modelBuilder.Entity<WeatherEntity>().OwnsOne(p => p.Summary).HasData(new { Date = new DateTime(2020, 1, 1), Temperature = -1, Name = "Chill" });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

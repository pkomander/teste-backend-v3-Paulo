using Aiko.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aiko.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
            
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Play> Plays { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Play>().HasData(
                new Play
                {
                    PlayId = 1,
                    Nome = "Hamlet",
                    Lines = 4024,
                    Type = "tragedy"
                }
            );

            builder.Entity<Play>().HasData(
                new Play
                {
                    PlayId = 2,
                    Nome = "As You Like It",
                    Lines = 2670,
                    Type = "comedy"
                }
            );

            builder.Entity<Play>().HasData(
                new Play
                {
                    PlayId = 3,
                    Nome = "Othello",
                    Lines = 3560,
                    Type = "tragedy"
                }
            );

            builder.Entity<Invoice>().HasData(
                new Invoice
                {
                    InvoiceId = 1,
                    Custumer = "BigCo"                }
            );

            builder.Entity<Performance>().HasData(
                new Performance
                {
                    PerformanceId = 1,
                    PlayId = 1,
                    Audience = 55,
                    InvoiceId = 1
                }
            );

            builder.Entity<Performance>().HasData(
                new Performance
                {
                    PerformanceId = 2,
                    PlayId = 2,
                    Audience = 35,
                    InvoiceId = 1
                }
            );

            builder.Entity<Performance>().HasData(
                new Performance
                {
                    PerformanceId = 3,
                    PlayId = 3,
                    Audience = 40,
                    InvoiceId = 1
                }
            );


        }
    }
}

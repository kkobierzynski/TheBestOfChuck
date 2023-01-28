using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestOfChuck.Entities
{
    public class ChuckJokeDbContext : DbContext
    {
        
        private string _connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:SQLiteConnectionString");

        public DbSet<ChuckJoke> ChuckJokes { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuckJoke>()
                .Property(p => p.Joke)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<ChuckJoke>()
                .Property(p => p.Date)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

    }
}

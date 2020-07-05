using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ehrmadesimple.Models;

namespace ehrmadesimple.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientInfo> ClientInfoes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<InitialQuestionAnswer> InitialQuestionAnswers { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options): base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasMany(b => b.Appointments)
                .WithOne(a => a.Bill)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Bills)
                .WithOne(b => b.Client)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Sessions)
                .WithOne(s => s.Client)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Client>()
                .HasMany(c => c.ClientInfoes)
                .WithOne(s => s.Client)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasMany(c => c.InitialQuestionAnswers)
                .WithOne(s => s.Client)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Bill>()
                .Property(c => c.Timestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Client>()
                .Property(c=>c.FirstJoined)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Event>()
                .Property(c => c.Timestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<InitialQuestionAnswer>()
                .Property(c => c.Timestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Session>()
                .Property(c => c.Timestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}

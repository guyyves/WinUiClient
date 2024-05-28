using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinUiClient.Data
{
    internal class AppDbContext : DbContext
    {   
        public DbSet<Bewoner> Bewoners { get; set; }
        public DbSet<Gebouw> Gebouwen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MariaDbServerVersion(new Version(5, 7, 33));
            optionsBuilder.UseMySql("server=localhost;database=csd_devcitysim;user=root;password=;", serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Bewoner>().HasData
                (
                    new Bewoner { Id = 1, Name = "John Doe", BirthDate = new DateOnly(1980, 5, 15), Job = "Engineer" },
                    new Bewoner { Id = 2, Name = "Alice Smith", BirthDate = new DateOnly(1992, 8, 20), Job = "Teacher" },
                    new Bewoner { Id = 3, Name = "Bob Johnson", BirthDate = new DateOnly(1975, 3, 10), Job = "Doctor" },
                    new Bewoner { Id = 4, Name = "Emily Davis", BirthDate = new DateOnly(1988, 12, 5), Job = "Artist" },
                    new Bewoner { Id = 5, Name = "Michael Wilson", BirthDate = new DateOnly(1995, 6, 30), Job = "Lawyer" },
                    new Bewoner { Id = 6, Name = "Sophia Brown", BirthDate = new DateOnly(1983, 2, 18), Job = "Software Developer" },
                    new Bewoner { Id = 7, Name = "Oliver Taylor", BirthDate = new DateOnly(1990, 7, 12), Job = "Accountant" },
                    new Bewoner { Id = 8, Name = "Mia Anderson", BirthDate = new DateOnly(1978, 9, 25), Job = "Nurse" },
                    new Bewoner { Id = 9, Name = "Liam Wilson", BirthDate = new DateOnly(1987, 4, 8), Job = "Marketing Manager" },
                    new Bewoner { Id = 10, Name = "Ava Martinez", BirthDate = new DateOnly(1993, 1, 22), Job = "Chef" },
                    new Bewoner { Id = 11, Name = "Noah Lee", BirthDate = new DateOnly(1976, 11, 14), Job = "Mechanic" },
                    new Bewoner { Id = 12, Name = "Emma Johnson", BirthDate = new DateOnly(1989, 10, 3), Job = "Dentist" },
                    new Bewoner { Id = 13, Name = "William Davis", BirthDate = new DateOnly(1997, 7, 28), Job = "Architect" },
                    new Bewoner { Id = 14, Name = "Charlotte White", BirthDate = new DateOnly(1984, 4, 7), Job = "Teacher" },
                    new Bewoner { Id = 15, Name = "James Harris", BirthDate = new DateOnly(1979, 6, 9), Job = "Pharmacist" },
                    new Bewoner { Id = 16, Name = "Isabella Clark", BirthDate = new DateOnly(1991, 9, 17), Job = "Software Developer" },
                    new Bewoner { Id = 17, Name = "Benjamin King", BirthDate = new DateOnly(1986, 3, 26), Job = "Electrician" },
                    new Bewoner { Id = 18, Name = "Sophia Miller", BirthDate = new DateOnly(1994, 5, 4), Job = "Consultant" },
                    new Bewoner { Id = 19, Name = "Alexander Scott", BirthDate = new DateOnly(1981, 12, 19), Job = "Writer" },
                    new Bewoner { Id = 20, Name = "Grace Turner", BirthDate = new DateOnly(1977, 8, 11), Job = "Software Developer" }

                );

            modelBuilder.Entity<Gebouw>().HasData
                (
                    new Gebouw { Id = 1, Name = "Name", Type = "type", Location= "house" },
                    new Gebouw { Id = 2, Name = "Curio", Type = "Gevangenis", Location = "Breda" },
                    new Gebouw { Id = 3, Name = "Makro", Type = "Loots", Location = "Breda" }
                );
        }
    }


}

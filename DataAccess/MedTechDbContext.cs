using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{   
    public class MedTechDbContext : DbContext
    {
        public MedTechDbContext(DbContextOptions<MedTechDbContext> options)
            : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set;}
        public DbSet<Quality> Qualitys { get; set; }
        public DbSet<Protect> Protects { get; set; }
        public DbSet<Craft> Crafts { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Dental> Dentals { get; set;}
        public DbSet<Professional> Professionals { get; set;}
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}

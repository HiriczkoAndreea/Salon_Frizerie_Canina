using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salon_Frizerie_Canina.Models;

namespace Salon_Frizerie_Canina.Data
{
    public class Salon_Frizerie_CaninaContext : DbContext
    {
        public Salon_Frizerie_CaninaContext (DbContextOptions<Salon_Frizerie_CaninaContext> options)
            : base(options)
        {
        }

        public DbSet<Salon_Frizerie_Canina.Models.Service> Service { get; set; } = default!;

        public DbSet<Salon_Frizerie_Canina.Models.Dog> Dog { get; set; }

        public DbSet<Salon_Frizerie_Canina.Models.Customer> Customer { get; set; }

        public DbSet<Salon_Frizerie_Canina.Models.Appointment> Appointment { get; set; }

        public DbSet<Salon_Frizerie_Canina.Models.Breed> Breed { get; set; }

        public DbSet<Salon_Frizerie_Canina.Models.Gender> Gender { get; set; }
    }
}

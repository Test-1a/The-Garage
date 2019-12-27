using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using The_Garage.Models;

namespace The_Garage.Data
{
    public class The_GarageContext : DbContext
    {
        public The_GarageContext (DbContextOptions<The_GarageContext> options)
            : base(options)
        {
        }

        public DbSet<The_Garage.Models.Vehicles> Vehicles { get; set; }

        public DbSet<The_Garage.Models.Members> Members { get; set; }
    }
}

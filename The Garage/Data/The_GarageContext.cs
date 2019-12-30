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
        public The_GarageContext(DbContextOptions<The_GarageContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Types>()
                .HasData(
                new Types { Id = 1, TypeOfVehicle = "Car" },
                new Types { Id = 2, TypeOfVehicle = "Bus" },
                new Types { Id = 3, TypeOfVehicle = "Boat" },
                new Types { Id = 4, TypeOfVehicle = "Airplane" },
                new Types { Id = 5, TypeOfVehicle = "Motorcycle" }
                );

            modelBuilder.Entity<Members>()
                .HasData(
                new Members { Id = 1, FirstName = "Jeon", LastName = "James" },
                new Members { Id = 2, FirstName = "Rod", LastName = "Rodsson" },
                new Members { Id = 3, FirstName = "Mikael", LastName = "Mickesson" },
                new Members { Id = 4, FirstName = "Moha", LastName = "Mohammedsson" }
                );

            modelBuilder.Entity<Vehicles>()
                .HasData(
                new Vehicles { Id = 1, RegNr = "ABCG123", Model = "Sports", Brand = "Volvo", NumnOfWheels = 4, Color = "Blue", TimeOfParking = DateTime.Now, TypeId = 1, MemberId = 1 },
                new Vehicles { Id = 2, RegNr = "ABCG123", Model = "Sports", Brand = "Volvo", NumnOfWheels = 4, Color = "Blue", TimeOfParking = DateTime.Now, TypeId = 3, MemberId = 2 },
                new Vehicles { Id = 3, RegNr = "ASD678", Model = "Business", Brand = "BMW", NumnOfWheels = 4, Color = "Green", TimeOfParking = DateTime.Now, TypeId = 3, MemberId = 2 },
                new Vehicles { Id = 4, RegNr = "ABC456", Model = "Travel", Brand = "Airbus", NumnOfWheels = 4, Color = "Black", TimeOfParking = DateTime.Now, TypeId = 4, MemberId = 3 },
                new Vehicles { Id = 5, RegNr = "XXX789", Model = "Sedan", Brand = "Volvo", NumnOfWheels = 4, Color = "Blue", TimeOfParking = DateTime.Now, TypeId = 5, MemberId = 4 }
                );
        }

        public DbSet<The_Garage.Models.Vehicles> Vehicles { get; set; }

        public DbSet<The_Garage.Models.Members> Members { get; set; }
    }
}

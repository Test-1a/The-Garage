using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Garage.Models
{
    public class Types
    {
        public int Id { get; set; }
        public string TypeOfVehicle { get; set; }
        public Vehicles Vehicle { get; set; }
    }
}

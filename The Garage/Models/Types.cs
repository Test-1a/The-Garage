using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Garage.Models
{
    public class Types
    {
        public int Id { get; set; }

        [Display(Name = "Type of Vehicle")]
        public string TypeOfVehicle { get; set; }

        public ICollection<Vehicles> Vehicle { get; set; }
    }
}

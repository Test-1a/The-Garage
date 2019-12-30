using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Garage.Models
{
    public class DetailViewModel
    {
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Start Time of Parking")]
        public DateTime TimeOfParking { get; set; }

        [Display(Name = "Number Of Wheels")]
        public int NumnOfWheels { get; set; }

        public string Color { get; set; }

        [Display(Name = "Model of Vehicle")]
        public string ModelOfVehicle { get; set; }

        [Display(Name = "Brand of Vehicle")]
        public string Brand { get; set; }

        public int TypeId { get; set; }
        public int MemberId { get; set; }
        public string Type { get; set; }
        public string Member { get; set; }
    }
}

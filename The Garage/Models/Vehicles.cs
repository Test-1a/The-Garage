using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Garage.Models
{
    public class Vehicles
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to write a Registration Number")]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        
        [Display(Name = "Start Time of Parking")]
        public DateTime TimeOfParking { get; set; }

        [Range(0, 99, ErrorMessage = "No more than 99 wheels")]
        [Display(Name = "Number Of Wheels")]
        public int NumnOfWheels { get; set; }

        public string Color { get; set; }
        [Display(Name = "Model of Vehicle")]
        public string Model { get; set; }
        [Display(Name = "Brand of Vehicle")]
        public string Brand { get; set; }

        public int TypeId { get; set; }
        public int MemberId { get; set; }

        public Types Type { get; set; }
        public Members Member { get; set; }
    }
}

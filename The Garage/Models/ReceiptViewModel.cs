using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Garage.Models
{
    public class ReceiptViewModel
    {
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        [Display(Name = "Time of Parking")]
        public DateTime TimeOfParking { get; set; }

        [Display(Name = "Time of Unparking")]
        public DateTime TimeOfUnParking { get; set; }

        [Display(Name = "Total Time Parked")]
        public string TotalTime { get; set; }

        [Display(Name = "Total Price (100KR per hour)")]
        public string Price { get; set; }
        public int NumnOfWheels { get; set; }

        public string Color { get; set; }

        [Display(Name = "Model of Vehicle")]
        public string Model { get; set; }

        [Display(Name = "Brand of Vehicle")]
        public string Brand { get; set; }

        public string Type { get; set; }
        public string Member { get; set; }

    }
}

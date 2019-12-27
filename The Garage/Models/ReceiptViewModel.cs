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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Garage.Models
{
    public class DetialViewModel
    {
        public string RegNr { get; set; }       
        public DateTime TimeOfParking { get; set; }        
        public int NumnOfWheels { get; set; }
        public string Color { get; set; }
        public string ModelOfVehicle { get; set; }
        public string Brand { get; set; }
        public int TypeId { get; set; }
        public int MemberId { get; set; }
        public string Type { get; set; }
        public string  Member { get; set; }
    }
}

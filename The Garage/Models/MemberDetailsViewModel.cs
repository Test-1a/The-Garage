using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Garage.Models
{
    public class MemberDetailsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfVehicles { get; set; }
        public IEnumerable<Vehicles> TheVehicles { get; set; }
    }
}

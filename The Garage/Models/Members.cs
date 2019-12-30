using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Garage.Models
{
    public class Members
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Vehicles> Vehicle { get; set; }
    }
}

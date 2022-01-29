using System;
using System.Collections.Generic;
using System.Text;

namespace HouseRent.Domain.Models
{
   public class Locations
    {
        public int Id { get; set; }
        public string  LocationName { get; set; }

        public List<SubLocations> SubLocationsId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HouseRent.Domain.Models
{
    public class SubLocations
    {
        public int Id { get; set; }
        public string SubLocName { get; set; }

        public int LocationId { get; set; }
        public Locations Location { get; set; }

        public List<Rooms> RoomsId { get; set; }
    }
}

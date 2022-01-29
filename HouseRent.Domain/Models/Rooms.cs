using System;
using System.Collections.Generic;
using System.Text;

namespace HouseRent.Domain.Models
{
    public class Rooms
    {
        public int Id { get; set; }
        public string RoomDesc { get; set; }
        public DateTime StartingDate { get; set; }


        public string  Comments { get; set; }


        public int TenantId { get; set; }
        public TenantDetails Tenant { get; set; }

        public int SubLocationId { get; set; }
        public SubLocations SubLocation { get; set; }
        //public Location LocationId { get; set; }

        public List<Payments> Payment { get; set; }
    }
}

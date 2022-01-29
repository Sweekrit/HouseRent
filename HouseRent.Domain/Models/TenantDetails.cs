using System;
using System.Collections.Generic;
using System.Text;

namespace HouseRent.Domain.Models
{
    public class TenantDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Comments { get; set; }


        public List<Rooms> Room { get; set; }




    }
}

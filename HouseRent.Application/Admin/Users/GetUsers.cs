using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseRent.Application.Admin.Users
{
   public class GetUsers
    {
        private ApplicationDbContext _ctx;

        public GetUsers(ApplicationDbContext ctx)
        {
            _ctx = ctx;

        }

        public IEnumerable<CustomerViewModel> Do()
        {
            return _ctx.TenantDetails.ToList().Select(x => new CustomerViewModel
            {
                Id=x.Id,
                FirstName=x.FirstName,
                LastName=x.LastName,
                PhoneNumber=x.PhoneNumber,
                Email=x.Email,
                UserName=x.UserName,
                Address=x.Address

            });

        }





        public class CustomerViewModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public long PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string UserName { get; set; }
        }


    }





}

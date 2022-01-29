using HouseRent.Database;
using HouseRent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Tenant
{
    public class CreateTenant
    {
        private ApplicationDbContext _ctx;

        public CreateTenant(ApplicationDbContext ctx)
        {
            _ctx = ctx;

        }

        public async Task<Response> Do(Request request)
        {
            var room = new TenantDetails
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                UserName = request.UserName,
                //StartingDate = request.StartingDate,

            };
            _ctx.TenantDetails.Add(room);
            await _ctx.SaveChangesAsync();

            return new Response
            {
                Id=room.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                UserName = request.UserName,
               // StartingDate = request.StartingDate.ToLongDateString(),
            };

        }

        public class Request
        {

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public long PhoneNumber { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
          //  public DateTime StartingDate { get; set; }
            //public string Comments { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public long PhoneNumber { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
           // public string StartingDate { get; set; }
        }

    }
       
}

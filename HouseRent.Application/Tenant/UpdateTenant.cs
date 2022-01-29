using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Tenant
{
   public class UpdateTenant
    {
        private ApplicationDbContext _ctx;

        public UpdateTenant(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Response> Do(Request request)
        {
            var user = _ctx.TenantDetails.FirstOrDefault(x => x.Id == request.Id);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;
            user.UserName = request.UserName;
            user.Email = request.Email;

          
            await _ctx.SaveChangesAsync();
            return new Response
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
                Email = request.Email,
            };


        }
        public class Request
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public long PhoneNumber { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
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

        }
    }
}

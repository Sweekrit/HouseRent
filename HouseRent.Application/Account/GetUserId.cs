using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseRent.Application.Account
{
    public class GetUserId
    {
        private ApplicationDbContext _ctx;

        public GetUserId(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public Response Do(string username)
        {
            var data = _ctx.TenantDetails.Where(x => x.UserName == username)
                .Select(x => new Response
                {
                    Id = x.Id,
                    Name = x.FirstName
                }).FirstOrDefault();

            return data;
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}

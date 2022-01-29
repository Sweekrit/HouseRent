using HouseRent.Database;
using HouseRent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Sublocation
{
    public class AddSublocation
    {
        private ApplicationDbContext _ctx;

        public AddSublocation(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var sublocation = new SubLocations
            {
                SubLocName = request.SubLocationName,
                LocationId = request.LocationId
            };

            _ctx.SubLocations.Add(sublocation);

            await _ctx.SaveChangesAsync();
            return new Response
            {
                Id = sublocation.Id,
                SubLocationName = sublocation.SubLocName,
                LocationId = sublocation.LocationId
            };

        }


        public class Request
        {
            public string SubLocationName { get; set; }
            public int LocationId { get; set; }
        }


        public class Response
        {
            public int Id { get; set; }
            public string SubLocationName { get; set; }
            public int LocationId { get; set; }
        }
    }
}

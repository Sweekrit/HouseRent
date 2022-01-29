using HouseRent.Database;
using HouseRent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Location
{
    public class AddLocation
    {
        private ApplicationDbContext _ctx;

        public AddLocation(ApplicationDbContext ctx)
        {
            _ctx = ctx;

        }

        public async Task<Response> Do(Request request)
        {
            var location = new Locations
            { 
                LocationName=request.LocationName
            };

            _ctx.Locations.Add(location);
            await _ctx.SaveChangesAsync();

            return new Response
            {
                Id = location.Id,
                LocationName = location.LocationName
               
            };
        }


    public class Request 
    {
        public string LocationName { get; set; }
    }

    public class Response
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
    }

    }
}

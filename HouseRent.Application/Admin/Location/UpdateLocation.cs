using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Location
{
    public class UpdateLocation
    {
        private ApplicationDbContext _ctx;

        public UpdateLocation(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }



        public async Task<Response> Do(Request request)
        {
            var location = _ctx.Locations.FirstOrDefault(x => x.Id == request.Id);
            location.LocationName = request.LocationName;

            await _ctx.SaveChangesAsync();

            return new Response
            {
                Id = location.Id,
                LocationName = location.LocationName

            };
        }


        public class Request
        {
            public int Id { get; set; }
            public string LocationName { get; set; }

        }

        public class Response
        {
            public int Id { get; set; }
            public string LocationName { get; set; }

        }
    }
    }

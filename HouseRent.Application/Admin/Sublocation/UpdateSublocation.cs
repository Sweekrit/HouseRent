using HouseRent.Database;
using HouseRent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Sublocation
{
    public class UpdateSublocation
    {
        private ApplicationDbContext _ctx;

        public UpdateSublocation(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var sublocations = new List<SubLocations>();
            foreach (var item in request.SubLocation)
            {
                sublocations.Add(new SubLocations{
                    Id = item.Id,
                    SubLocName = item.SublocationName,
                    LocationId = item.LocationId
                });
            }
            _ctx.SubLocations.UpdateRange(sublocations);
            await _ctx.SaveChangesAsync();
            return new Response
            {
                SubLocation = request.SubLocation

            };

        }

   
        public class SublocationModel
        {
            public int Id { get; set; }
            public string SublocationName { get; set; }
            public int LocationId { get; set; }
        }



    public class Request
    {
           public IEnumerable<SublocationModel> SubLocation { get; set; }
        }


    public class Response
    {
            public IEnumerable<SublocationModel> SubLocation { get; set; }

        }
    }
}


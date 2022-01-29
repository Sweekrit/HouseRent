using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseRent.Application.Admin.Location
{
    public class GetLocations
    {
        private ApplicationDbContext _ctx;

        public GetLocations(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<LocationsViewModel> Do() =>
            _ctx.Locations.ToList().Select(x => new LocationsViewModel { 
                Id=x.Id,
                LocationName=x.LocationName
            
            });
    public class LocationsViewModel
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
    }
    }
}

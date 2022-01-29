using HouseRent.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseRent.Application.Admin.Sublocation
{
    public class GetSublocations
    {
        private ApplicationDbContext _ctx;

        public GetSublocations(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public IEnumerable<LocationModel> Do()
        {
           var locationlist=  _ctx.Locations.
                Include(x => x.SubLocationsId).
                Select(x => new LocationModel
              {
                  LocationId = x.Id,
                  LocationName = x.LocationName,
                  Sublocataion = x.SubLocationsId.Select( y => new SublocationModel {
                    Id =y.Id,
                    SublocationName=y.SubLocName,
                    AvailableRooms=y.RoomsId.Select(z => new RoomModel
                    {
                        RoomId=z.Id,
                        RoomDesc=z.RoomDesc,
                        StartDay=z.StartingDate.Day
                    })
                  
                  
                  })
                
                  //Location = _ctx.Locations.ToList().Where(y => y.Id == x.LocationId).Select(z =>z.LocationName).FirstOrDefault()

              }).ToList() ;
            return locationlist;
        }


        public class LocationModel
        {
            public int LocationId { get; set; }
            public string LocationName { get; set; }

            public IEnumerable<SublocationModel> Sublocataion { get; set; }

        }
        public class SublocationModel
        {
            public int Id { get; set; }
            public string SublocationName { get; set; }

            public IEnumerable<RoomModel> AvailableRooms { get; set; }


        }
        public class RoomModel
        {
            public int RoomId { get; set; }
            public string RoomDesc { get; set; }
            public int StartDay { get; set; }
        }

      
    }
}

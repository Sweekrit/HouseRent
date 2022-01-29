using HouseRent.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static HouseRent.Application.Admin.Location.GetLocations;

namespace HouseRent.Application.Admin.RoomDetails
{
    public class GetRooms
    {
        private ApplicationDbContext _ctx;

        public GetRooms(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public IEnumerable<CustomerModel> Do()
        {
            var data =_ctx.TenantDetails.
                    Include(x=>x.Room).
                    ThenInclude(x => x.SubLocation)
                    .ThenInclude(x => x.Location).Select(y => new CustomerModel
                    {
                        CustomerId=y.Id,
                        CustomerName =y.FirstName,
                        RoomDetail = y.Room.Select(z => new RoomViewModel
                        {
                            RoomId = z.Id,
                            RoomDesc = z.RoomDesc,
                            Sublocation = z.SubLocation.SubLocName,
                            Location = z.SubLocation.Location.LocationName
                        } )

                }).ToList();
            return data;
        
        }


        public class CustomerModel
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }

            public IEnumerable<RoomViewModel> RoomDetail { get; set; }

        }
        public class RoomViewModel
        {
            public int RoomId { get; set; }
            public string RoomDesc { get; set; }

            public string Sublocation { get; set; }

            public string   Location { get; set; }

        }

    }
}

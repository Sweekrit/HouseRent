using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.RoomDetails
{
    public class GetRoom
    {
        private ApplicationDbContext _ctx;

        public GetRoom(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Response Do(int id)
        {
            var room = _ctx.Rooms.Where(x => x.Id == id).Select(room => new Response
            {

                Id = room.Id,
                RoomDesc = room.RoomDesc,
                //Rent = room.Rent,
                //PresentEReading = room.PresentEReading,
                //PreviousEReading = room.PreviousEReading,
                //WastageCost = room.WastageCost,
                //WaterCost = room.WaterCost,
                //MiscellenousCost = room.MiscellenousCost,
                TenantId = room.TenantId,
                SubLocationId = room.SubLocationId,
                locationId = room.SubLocation.LocationId,
                StartingDate=room.StartingDate
               



            }).FirstOrDefault();

            return room;


        }

        public class Response
        {
            
            public int Id { get; set; }
            public string RoomDesc { get; set; }
            //public decimal Rent { get; set; }
            //public int PreviousEReading { get; set; }
            //public int PresentEReading { get; set; }
            //public decimal WaterCost { get; set; }
            //public decimal WastageCost { get; set; } 
            //public decimal MiscellenousCost { get; set; } 
            //public string Comments { get; set; }
            public int locationId { get; set; }
            public DateTime StartingDate { get; set; }

            public int TenantId { get; set; }

            public int SubLocationId { get; set; }
        }
    }
}

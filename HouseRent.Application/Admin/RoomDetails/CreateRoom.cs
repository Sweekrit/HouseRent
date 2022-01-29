using HouseRent.Database;
using HouseRent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.RoomDetails
{
    public class CreateRoom
    {
        private ApplicationDbContext _ctx;

        public CreateRoom(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {

            var room = new Rooms
            {
                RoomDesc = request.RoomDesc,
                //Rent = request.Rent,
                //PresentEReading = request.PresentEReading,
                //PreviousEReading = request.PreviousEReading,
                //WastageCost = request.WastageCost,
                //WaterCost = request.WaterCost,
                //MiscellenousCost = request.MiscellenousCost,
                TenantId = request.TenantId,
                SubLocationId = request.SubLocationId,
                StartingDate = request.StartingDate

            };

                _ctx.Rooms.Add(room);
            await _ctx.SaveChangesAsync();
            return new Response
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
                StartingDate=room.StartingDate
            };

        }

        public class Request
        {
            public string RoomDesc { get; set; }
            //public decimal Rent { get; set; }
            //public int PreviousEReading { get; set; }
            //public int PresentEReading { get; set; }
            //public decimal WaterCost { get; set; } 
            //public decimal WastageCost { get; set; }
            //public decimal MiscellenousCost { get; set; }
            public DateTime StartingDate { get; set; }

            // public string Comments { get; set; }


            public int TenantId { get; set; }
            

            public int SubLocationId { get; set; }  
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
            public DateTime StartingDate { get; set; }

            // public string Comments { get; set; }


            public int TenantId { get; set; }


            public int SubLocationId { get; set; }

        }
    }
}

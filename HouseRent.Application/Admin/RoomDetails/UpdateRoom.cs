using HouseRent.Database;
using HouseRent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.RoomDetails
{
    public class UpdateRoom
    {
        private ApplicationDbContext _ctx;

        public UpdateRoom(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var room = _ctx.Rooms.FirstOrDefault(x => x.Id == request.Id);

            room.RoomDesc = request.RoomDesc;
            //room.Rent = request.Rent;
            //room.PresentEReading = request.PresentEReading;
            //room.PreviousEReading = request.PreviousEReading;
            //room.WastageCost = request.WastageCost;
            //room.WaterCost = request.WaterCost;
            //room.MiscellenousCost = request.MiscellenousCost;
            room.TenantId = request.TenantId;
                room.SubLocationId = request.SubLocationId;
            room.StartingDate = request.StartingDate;


           
            await _ctx.SaveChangesAsync();

            

            return new Response
            {
                Id = request.Id,
                       //RoomDesc = request.RoomDesc,
                        //Rent = request.Rent,
                        //PresentEReading = request.PresentEReading,
                        //PreviousEReading = request.PreviousEReading,
                        //WastageCost = request.WastageCost,
                        //WaterCost = request.WaterCost,
                        SubLocationId = request.SubLocationId,
                        TenantId = request.TenantId,
                        StartingDate=request.StartingDate

            };
            //var listRooms = new List<Rooms>();

            //foreach (var item in request.RoomData)
            //{
            //    listRooms.Add(new Rooms
            //    {
            //        Id = item.Id,
            //        RoomDesc = item.RoomDesc,
            //        Rent = item.Rent,
            //        PresentEReading = item.PresentEReading,
            //        PreviousEReading = item.PreviousEReading,
            //        WastageCost = item.WastageCost,
            //        WaterCost = item.WaterCost,
            //        SubLocationId = item.SubLocationId,
            //        TenantId = item.TenantId,
            //        // Id = item.Id,


            //    });
            //    }
            //    _ctx.Rooms.UpdateRange(listRooms);
            //    await _ctx.SaveChangesAsync();

            //    return new Response
            //    {
            //        RoomData = request.RoomData
            //    };

            }




        //public class RoomsViewModel
        //{
        //    public int Id { get; set; }
        //    public string RoomDesc { get; set; }
        //    public decimal Rent { get; set; }
        //    public int PreviousEReading { get; set; }
        //    public int PresentEReading { get; set; }
        //    public decimal WaterCost { get; set; } = 0;
        //    public decimal WastageCost { get; set; } = 0;
        //    public decimal MiscellenousCost { get; set; } = 0;
        //    public string Comments { get; set; }


        //    public int TenantId { get; set; }

        //    public int SubLocationId { get; set; }
        //}



        public class Request
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
            public DateTime StartingDate { get; set; }


            public int TenantId { get; set; }

            public int SubLocationId { get; set; }
            //public IEnumerable<RoomsViewModel> RoomData { get; set; }

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
            public DateTime StartingDate { get; set; }


            public int TenantId { get; set; }

            public int SubLocationId { get; set; }
            //public IEnumerable<RoomsViewModel> RoomData { get; set; }

        }

    }
        
}

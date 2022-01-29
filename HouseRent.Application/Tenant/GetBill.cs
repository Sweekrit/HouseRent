using HouseRent.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseRent.Application.Tenant
{
   public class GetBill
    {
        private ApplicationDbContext _ctx;

        public GetBill(ApplicationDbContext ctx)
        {
          _ctx = ctx;
        }

        public Response Do(int id,DateTime date)
        {
            var requiredBill = _ctx.Payments.
                Include(x=>x.Room).ThenInclude(x=>x.Tenant)
                .Where(x => x.RoomId == id && x.PaymentForMonth.Month == date.Month)
                .Select(y => new Response {
                    Id=y.Id,
                    Rent=y.Rent,
                    PresentEReading = y.PresentEReading,
                    PreviousEReading=y.PreviousEReading,
                    WastageCost=y.WastageCost,
                    WaterCost=y.WaterCost,
                    MiscellenousCost=y.MiscellenousCost,
                    Amount=y.Amount,
                    RoomId=y.RoomId,
                    PaymentForMonth = y.PaymentForMonth.Month,
                    CustomerName = y.Room.Tenant.FirstName + " " + y.Room.Tenant.LastName

                
                
                
                }).FirstOrDefault();

            return requiredBill;
            


        }
        //public class Request
        //{
        //    public int RoomId { get; set; }
        //    public DateTime Date { get; set; }
        //}

        public class Response
        {
            public int Id { get; set; }
            public decimal Rent { get; set; }
            public int PresentEReading { get; set; }
            public int PreviousEReading { get; set; }
            public decimal WaterCost { get; set; }
            public decimal WastageCost { get; set; }
            public decimal MiscellenousCost { get; set; }
            public int PaymentForMonth { get; set; }
            public decimal Amount { get; set; }
            //  public string Comments { get; set; }
            public int RoomId { get; set; }
            public string CustomerName { get; set; }

        }
    }
}

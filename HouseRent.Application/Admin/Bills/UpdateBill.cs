using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Bills
{
   public class UpdateBill
    {
        private ApplicationDbContext _ctx;

        public UpdateBill(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var bill = _ctx.Payments.FirstOrDefault(x => x.Id == request.Id);

            bill.RoomId = request.RoomId;
            bill.Rent = request.Rent;
            bill.WastageCost = request.WastageCost;
            bill.WaterCost = request.WaterCost;
            bill.PresentEReading = request.PresentEReading;
            bill.PreviousEReading = request.PreviousEReading;
            bill.MiscellenousCost = request.MiscellenousCost;
            bill.PaymentForMonth = request.PaymentForMonth;
            bill.Amount = request.Amount;


            await _ctx.SaveChangesAsync();

            return new Response
            {
                RoomId = bill.RoomId,
                Rent = bill.Rent,
                WastageCost = bill.WastageCost,
                WaterCost = bill.WaterCost,
                PresentEReading = bill.PresentEReading,
                PreviousEReading = bill.PreviousEReading,
                MiscellenousCost = bill.MiscellenousCost,
                PaymentForMonth = bill.PaymentForMonth,
                Amount = bill.Amount
            };
        }

         



        public class Request {
            public int Id { get; set; }
            public decimal Rent { get; set; }
            public int PreviousEReading { get; set; }
            public int PresentEReading { get; set; }
            public decimal WaterCost { get; set; }
            public decimal WastageCost { get; set; }
            public decimal MiscellenousCost { get; set; }
            public DateTime PaymentForMonth { get; set; }
            public decimal Amount { get; set; }
            //  public string Comments { get; set; }
            public int RoomId { get; set; }
        }


        public class Response
        {
            public int Id { get; set; }
            public decimal Rent { get; set; }
            public int PreviousEReading { get; set; }
            public int PresentEReading { get; set; }
            public decimal WaterCost { get; set; }
            public decimal WastageCost { get; set; }
            public decimal MiscellenousCost { get; set; }
            public DateTime PaymentForMonth { get; set; }
            public decimal Amount { get; set; }
            //  public string Comments { get; set; }
            public int RoomId { get; set; }
        }
    }
}

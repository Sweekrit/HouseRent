using HouseRent.Database;
using HouseRent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Bills
{
    public class CreateBill
    {
        private ApplicationDbContext _ctx;

        public CreateBill(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var bill = new Payments
            {
                RoomId = request.RoomId,
                Rent = request.Rent,
                WastageCost = request.WastageCost,
                WaterCost = request.WaterCost,
                PresentEReading = request.PresentEReading,
                PreviousEReading = request.PreviousEReading,
                MiscellenousCost = request.MiscellenousCost,
                PaymentForMonth = request.PaymentForMonth,
                Amount = request.Amount

            };
            _ctx.Payments.Add(bill);
            await _ctx.SaveChangesAsync();

            return new Response
            {
                Id = bill.Id,
                PaymentForMonth = bill.PaymentForMonth,
                Amount = bill.Amount,
                RoomId = bill.RoomId,

            };
        }





        public class Request
        {
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
            public DateTime PaymentForMonth { get; set; }
            public decimal Amount { get; set; }
            public int RoomId { get; set; }
        }
    }
}


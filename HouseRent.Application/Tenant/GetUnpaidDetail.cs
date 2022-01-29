using HouseRent.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseRent.Application.Tenant
{
    public   class GetUnpaidDetail
    {
        private ApplicationDbContext _ctx;

        public GetUnpaidDetail(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Response> Do(int id)
        {
            var data = _ctx.Rooms.Where(x => x.TenantId == id).Select(x => new Response
            {
                Id = x.Id,
                RoomDesc = x.RoomDesc,
                LocationName = x.SubLocation.Location.LocationName,
                SublocationName = x.SubLocation.SubLocName,

                Bills = x.Payment.Where(x => x.RefNo == null || x.RefNo == "" ).Select(y => new PaymentModel
                {
                    Id = y.Id,
                    StartingDate = y.PaymentForMonth,
                    Amount = y.Amount
                }).ToList()

            }).ToList();

            List<Response> newList = new List<Response>();
            foreach (var item in data)

            {
                if(item.Bills.Count() == 0)
                {
                    continue;
                }
                else
                {
                    newList.Add(item);
                }
            }

            return newList;

        }

        public class Response
        {
            public int Id { get; set; }
            public string RoomDesc { get; set; }
            public string SublocationName { get; set; }
            public string LocationName { get; set; }

            public List<PaymentModel> Bills { get; set; }

        }

        public class PaymentModel
        {
            public int Id { get; set; }
            public DateTime StartingDate { get; set; }

            public decimal Amount { get; set; }
        }


    }
}

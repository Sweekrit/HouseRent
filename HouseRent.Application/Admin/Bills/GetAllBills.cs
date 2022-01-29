using HouseRent.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseRent.Application.Admin.Bills
{
   public  class GetAllBills
    {
        private ApplicationDbContext _ctx;

        public GetAllBills(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Response> Do()
        {
            var datas = _ctx.TenantDetails
                .Include(x => x.Room)
                .Select(x => new Response
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName=x.LastName,
                    ListRooms = x.Room.Select(y => new RoomViewModel
                    {
                        RoomDesc= y.RoomDesc,
                        SublocationName=y.SubLocation.SubLocName,
                        LocationName=y.SubLocation.Location.LocationName,
                        Bills = y.Payment.Select(z=> new PaymentModel
                        {
                            Id=z.Id,
                            StartingDate=z.PaymentForMonth,
                            Amount=z.Amount,
                        }).ToList()
                        
                    }).ToList()



                }).ToList();

            return datas;

        }

        public class Response
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public IEnumerable<RoomViewModel> ListRooms { get; set; }
        }

        public class RoomViewModel
        {
            public string RoomDesc { get; set; }
            public string SublocationName { get; set; }
            public string  LocationName { get; set; }

            public IEnumerable<PaymentModel> Bills { get; set; }
        }

        public class PaymentModel
        {
            public int Id { get; set; }
            public DateTime StartingDate { get; set; }

            public decimal Amount { get; set; }
        }
    }
}

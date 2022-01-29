using HouseRent.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseRent.Application.Tenant
{
    public class GetTenant
    {
        private ApplicationDbContext _ctx;

        public GetTenant(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public TenantModel Do(int id)
        {
            var data = _ctx.TenantDetails.
                      Include(x => x.Room).
                     ThenInclude(x => x.SubLocation)
                     .ThenInclude(x => x.Location)
                   .Where(x => x.Id == id).Select(y => new TenantModel
                   {
                       Id = y.Id,
                       FirstName = y.FirstName,
                       LastName = y.LastName,
                       Address=y.Address,
                       PhoneNumber=y.PhoneNumber,
                       Email=y.Email,
                       UserName=y.UserName,
                       RoomDetail = y.Room.Select(z => new RoomViewModel
                       {
                           RoomDesc=z.RoomDesc,
                           StartDate=z.StartingDate.ToShortDateString(),
                           Location =z.SubLocation.Location.LocationName,
                           Sublocation=z.SubLocation.SubLocName
                       })


                   }).FirstOrDefault();

            return data;

        }


    }

   

    public class TenantModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        // public string Comments { get; set; }

        public IEnumerable<RoomViewModel> RoomDetail { get; set; }
    }

    public class RoomViewModel
    {
        //public int RoomId { get; set; }
        public string RoomDesc { get; set; }
        public string StartDate { get; set; }

        public string Sublocation { get; set; }

        public string Location { get; set; }

    }
}

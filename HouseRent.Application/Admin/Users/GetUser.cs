using HouseRent.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Users
{
    public class GetUser
    {
        private ApplicationDbContext _ctx;

        public GetUser(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Response Do(int id)
        {
            var user = _ctx.TenantDetails
                .Where(x => x.Id == id).Select(x => new Response
                {

                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    UserName = x.UserName,
                    Comments = x.Comments,
                    RoomAllocated = _ctx.Rooms.Where(x => x.TenantId == id).Select(y => new RoomModel
                    {
                        Id=y.Id,
                        RoomDesc=y.RoomDesc,
                        LocationName=y.SubLocation.Location.LocationName,
                        SublocationName=y.SubLocation.SubLocName
                    }).ToList()

                }).FirstOrDefault();

             return  user;

        }

        public class Response
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public long PhoneNumber { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Comments { get; set; }
            public IEnumerable<RoomModel> RoomAllocated { get; set; }
        }
        public class RoomModel
        {
            public int Id { get; set; }
            public string RoomDesc { get; set; }
            public string SublocationName { get; set; }
            public string LocationName { get; set; }
        }
    }
}

using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Location
{
   public class DeleteRoom
    {
        private ApplicationDbContext _ctx;

        public DeleteRoom(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public async Task<bool> Do(int id) 
        {
           var room = _ctx.Rooms.FirstOrDefault(x => x.Id == id);
            _ctx.Rooms.Remove(room);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}

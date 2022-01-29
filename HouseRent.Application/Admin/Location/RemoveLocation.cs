using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Location
{
   public class RemoveLocation
    {
        private ApplicationDbContext _ctx;

        public RemoveLocation(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do (int id)
        {
            var location = _ctx.Locations.FirstOrDefault(x => x.Id == id);
            _ctx.Locations.Remove(location);
            await _ctx.SaveChangesAsync();
            return true;
            
            
            
        }

      

    }
}

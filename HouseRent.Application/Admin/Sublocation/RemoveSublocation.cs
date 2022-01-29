using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Sublocation
{
   public class RemoveSublocation
    {
        private ApplicationDbContext _ctx;

        public RemoveSublocation(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var slocation = _ctx.SubLocations.FirstOrDefault(x => x.Id == id);

            _ctx.SubLocations.Remove(slocation);
            await _ctx.SaveChangesAsync();

            return true;

        }
    }
}

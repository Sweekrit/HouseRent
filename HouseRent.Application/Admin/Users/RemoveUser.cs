using HouseRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Application.Admin.Users
{
   public class RemoveUser
    {
        private ApplicationDbContext _ctx;

        public RemoveUser(ApplicationDbContext ctx)
        {
            _ctx = ctx;


        }

        public async Task<bool> Do(int id)
        {
            var room = _ctx.TenantDetails.Where(x => x.Id == id).FirstOrDefault();
            _ctx.TenantDetails.Remove(room);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}

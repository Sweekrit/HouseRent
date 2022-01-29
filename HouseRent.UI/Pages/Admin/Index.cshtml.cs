using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRent.Application.Admin.Bills;
using HouseRent.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HouseRent.UI.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx=ctx;
        }
        public IEnumerable<GetAllBills.Response> Payments { get; set; }
        public void OnGet()
        {
            Payments = new GetAllBills(_ctx).Do();
        }
    }
}

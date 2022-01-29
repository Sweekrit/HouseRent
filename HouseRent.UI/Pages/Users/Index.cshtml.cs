using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRent.Application.Account;
using HouseRent.Database;
using HouseRent.Domain.Models;
using HouseRent.UI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Stripe;

namespace HouseRent.UI.Pages.Users
{


    public class IndexModel : PageModel
    {
        public Payments payment  { get; set; }

        public string PublicKey { get; }

        private ApplicationDbContext _ctx;

        public SessionModel Sessiondata { get; set; }

        public IndexModel(ApplicationDbContext ctx,IConfiguration config)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
            _ctx = ctx;

        }
        public void OnGet()
        {
            var data = HttpContext.Session.GetString("newUser");
            Sessiondata = data != null? JsonConvert.DeserializeObject<SessionModel>(data): new SessionModel();
            var response = new GetUserId(_ctx).Do(Sessiondata.UserName);

            Sessiondata.Id = response != null ? response.Id : 0;

        }

        public IActionResult OnPost()
        {
               

                return Page();
        }

    }
}

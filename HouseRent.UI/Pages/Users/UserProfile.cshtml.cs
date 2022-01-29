using HouseRent.Application.Account;
using HouseRent.Database;
using HouseRent.UI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HouseRent.UI.Pages.Users
{
    public class UserProfileModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public SessionModel Sessiondata { get; set; }

        public UserProfileModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void OnGet()
        {
            var data = HttpContext.Session.GetString("newUser");
            Sessiondata = data != null ? JsonConvert.DeserializeObject<SessionModel>(data) : new SessionModel();
            var response = new GetUserId(_ctx).Do(Sessiondata.UserName);
            
            Sessiondata.Id = response != null ? response.Id : 0;




        }




    }
}

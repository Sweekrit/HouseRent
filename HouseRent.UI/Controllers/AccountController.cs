using System.Threading.Tasks;
using HouseRent.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseRent.UI.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _ctx;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(ApplicationDbContext ctx,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> SignOut()
        {
            HttpContext.Session.Remove("newUser");
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}

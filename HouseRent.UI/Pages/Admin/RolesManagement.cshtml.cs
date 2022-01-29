using System.Collections.Generic;
using System.Threading.Tasks;
using HouseRent.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HouseRent.UI.Pages.Admin
{
    public class CreateRolesModel : PageModel
    {
        private ApplicationDbContext _ctx;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        
        public IList<IdentityUser> UsersAvailable  { get; set; }
        public IList<IdentityUser> AdminAvailable { get; set; }

        public CreateRolesModel(ApplicationDbContext ctx, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> OnGet()
        {
            UsersAvailable = await _userManager.GetUsersInRoleAsync("User");
            AdminAvailable = await _userManager.GetUsersInRoleAsync("Admin") ;

            return Page();





        }

        public async Task<IActionResult> OnPost(string id)
        {


            var user = await _userManager.FindByIdAsync(id);

            var roles = await _userManager.IsInRoleAsync(user,"User");
            if (roles)
            {

            await _userManager.RemoveFromRoleAsync(user, "User");
            await _userManager.AddToRoleAsync(user, "Admin");


            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                await _userManager.AddToRoleAsync(user, "User");

            }

            return RedirectToPage("RolesManagement");

        }

       
     

        
    }
}

using HouseRent.Application.Account;
using HouseRent.Database;
using HouseRent.UI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HouseRent.UI.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public IndexModel(ApplicationDbContext ctx, UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
       
        [BindProperty]
        public AccountModel Account { get; set; }

        //public SessionModel SessionData { get; set; }

        public async Task<IActionResult> OnPostSignup()
        {
          if(ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByNameAsync(Account.UserName);
                if(currentUser != null)
                {
                    //ADD already exixts msg
                    return Page();
                }
              

                var user = new IdentityUser { UserName = Account.UserName, Email = Account.Email };
                var result = await _userManager.CreateAsync(user, Account.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    await _userManager.AddToRoleAsync(user,"User");


                    var SessionData = initSession(Account);
                    HttpContext.Session.SetString("newUser", JsonConvert.SerializeObject(SessionData));
                    return Page();

                }
            }
         
                return Page();
           
          
            

        }

        public async Task<IActionResult> OnPostLogin()
        {

            var user = await _userManager.FindByNameAsync(Account.UserName);
            if(user == null)
            {
                return Page();

            }
            var role = await _userManager.IsInRoleAsync(user, "User");
            if (role)
            {
            var result = await _signInManager.PasswordSignInAsync(Account.UserName, Account.Password, false,false);
                if (result.Succeeded)
                {
               
                var SessionData = initSession(Account);
                     HttpContext.Session.SetString("newUser",JsonConvert.SerializeObject(SessionData));
                    return RedirectToPage("Users/UserProfile");
                
                }

            }
           


          return Page();
        }

        public async Task<IActionResult> OnPostAdminLogin()
        {

            var user = await _userManager.FindByNameAsync(Account.UserName);
            if (user != null)
            {
             
                var role = await _userManager.IsInRoleAsync(user, "Admin");
                if(role)
                {
                    var result = await _signInManager.PasswordSignInAsync(Account.UserName, Account.Password, false, false);
                    if (result.Succeeded)
                    {
                
                        var SessionData = initSession(Account);
                        HttpContext.Session.SetString("newUser", JsonConvert.SerializeObject(SessionData));
                        return RedirectToPage("Admin/Index");

                    }
                }
                


            }

          
            




            return Page();
        }

        public void OnGet()
        {

        }

       

        public SessionModel initSession(AccountModel data)
        {
            SessionModel session = new SessionModel();
            session.UserName = data.UserName ?? "";
            session.Email = data.Email ?? "";

            return session;
           
        }


    

    }
}

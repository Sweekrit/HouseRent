using System;
using System.Threading.Tasks;
using HouseRent.Application.Tenant;
using HouseRent.Database;
using Microsoft.AspNetCore.Mvc;

namespace HouseRent.UI.Controllers
{
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private ApplicationDbContext _ctx;

        public UserController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }



        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] CreateTenant.Request request) => Ok(await new CreateTenant(_ctx).Do(request));


        [HttpGet("users/{id}")]
        public IActionResult GetUser(int id) => Ok(new GetTenant(_ctx).Do(id));

        [HttpPut("users")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateTenant.Request request) => Ok(await new UpdateTenant(_ctx).Do(request));




        [HttpGet("bills/{id}")]
        public IActionResult GetAllBills(int id) => Ok(new GetUnpaidDetail(_ctx).Do(id));

        [HttpGet("bills")]
        public IActionResult GetBill(int id, DateTime date) => Ok(new GetBill(_ctx).Do(id, date));

    }
}

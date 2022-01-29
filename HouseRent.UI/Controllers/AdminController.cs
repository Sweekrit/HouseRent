using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRent.Application.Admin.Bills;
using HouseRent.Application.Admin.Location;
using HouseRent.Application.Admin.RoomDetails;
using HouseRent.Application.Admin.Sublocation;
using HouseRent.Application.Admin.Users;
using HouseRent.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRent.UI.Controllers
{
    
    [Route("[Controller]")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public AdminController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("locations")]
        public async Task<IActionResult> AddLocations([FromBody] AddLocation.Request request) => Ok(await new AddLocation(_ctx).Do(request));

        [HttpGet("locations")]
        public IActionResult GetLocations() => Ok(new GetLocations(_ctx).Do());

        [HttpPut("locations")]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocation.Request request) => Ok(await new UpdateLocation(_ctx).Do(request));

        [HttpDelete("locations/{id}")]
        public async Task<IActionResult> DeleteLocation(int id) => Ok(await new RemoveLocation(_ctx).Do(id));





        [HttpPost("sublocations")]
        public async Task<IActionResult> AddSubLocation([FromBody] AddSublocation.Request request) => Ok(await new AddSublocation(_ctx).Do(request));


        [HttpGet("sublocations")]
        public IActionResult GetSubLocations() => Ok(new GetSublocations(_ctx).Do());


        [HttpPut("sublocations")]
        public async Task<IActionResult> UpdateSubLocation([FromBody] UpdateSublocation.Request request) => Ok(await new UpdateSublocation(_ctx).Do(request));


        [HttpDelete("sublocations/{id}")]
        public async Task<IActionResult> DeleteSubLocation(int id) => Ok(await new RemoveSublocation(_ctx).Do(id));




        [HttpGet("users")]
        public IActionResult GetAllUsers() => Ok(new GetUsers(_ctx).Do());


        [HttpPost("users/{id}")]
        public IActionResult GetUser(int id) => Ok(new GetUser(_ctx).Do(id));

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id) => Ok(await new RemoveUser(_ctx).Do(id));






        [HttpPost("rooms")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoom.Request request) => Ok(await new CreateRoom(_ctx).Do(request));


        [HttpGet("rooms")]
        public IActionResult GetAllRooms() => Ok(new GetRooms(_ctx).Do());

        [HttpPut("rooms")]
        public async Task<IActionResult> UpdateRooms([FromBody] UpdateRoom.Request request) => Ok(await new UpdateRoom(_ctx).Do(request));

        [HttpPost("rooms/{id}")]
        public IActionResult GetRoom(int id) => Ok(new GetRoom(_ctx).Do(id));


        [HttpDelete("rooms/{id}")]
        public async Task<IActionResult> DeleteRoom(int id) => Ok(await new DeleteRoom(_ctx).Do(id));





        [HttpPost("bills")]
        public async Task<IActionResult> CreateBill([FromBody] CreateBill.Request request) => Ok(await new CreateBill(_ctx).Do(request));

       

        [HttpPut("bills")]
        public async Task<IActionResult> UpdateBill([FromBody] UpdateBill.Request request) => Ok(await new UpdateBill(_ctx).Do(request));


        [HttpGet("bill")]
        public IActionResult GetBils() => Ok(new GetAllBills(_ctx).Do());

    }


}

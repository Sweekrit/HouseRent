using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRent.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;

namespace HouseRent.UI.Controllers
{
    [Route("create-payment-intent")]
    [ApiController]
    public class Payment : Controller
    {
        private ApplicationDbContext _ctx;

        public Payment(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Item request)
        {
            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                Amount = request.Amount,
                Currency = "usd",
             //  Customer= request.Customer
            }) ;

            var id = paymentIntent.Id;
            var payment = _ctx.Payments.FirstOrDefault(x => x.Id == request.Id);
            payment.RefNo = id;
            await _ctx.SaveChangesAsync();

            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }


      
        public class Item
        {
           
            public int Id { get; set; }
            
            
            public long Amount { get; set; }

           // public string Customer { get; set; }


        }
        
    }
}

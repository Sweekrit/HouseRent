using System;
using System.Collections.Generic;
using System.Text;

namespace HouseRent.Domain.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public string RefNo { get; set; }
        public decimal Rent { get; set; }
        public int PreviousEReading { get; set; }
        public int PresentEReading { get; set; }
        public decimal WaterCost { get; set; }
        public decimal WastageCost { get; set; }
        public decimal MiscellenousCost { get; set; }
        public DateTime PaymentForMonth { get; set; }
        public decimal Amount { get; set; }
        public string Comments { get; set; }

        public int RoomId { get; set; }
        public Rooms Room { get; set; }


    }
}

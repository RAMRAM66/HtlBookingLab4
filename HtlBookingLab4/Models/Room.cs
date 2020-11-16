using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtlBookingLab4.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomCount { get; set; }
        public int BedCount { get; set; }
        public decimal Price { get; set; }
        public int? RoomClassId { get; set; }
        public RoomClass RoomClass { get; set; }

    }
}
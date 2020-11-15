using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HtlBookingLab4.Models
{
    public class RmContext : DbContext
    {
        public DbSet<RoomClass> RoomClasses { get; set; }
        public DbSet<Room> Rooms{ get; set; }
    }
}
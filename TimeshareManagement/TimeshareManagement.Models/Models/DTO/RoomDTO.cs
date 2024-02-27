using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeshareManagement.Models.Models.DTO
{
    public class RoomDTO
    {
        public int roomID { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public int Nights { get; set; }
        public int Price { get; set; }
        public int Rooms { get; set; }
        public int Sleeps { get; set; }
        public TimeshareDTO? Timeshare { get; set; }
    }
}

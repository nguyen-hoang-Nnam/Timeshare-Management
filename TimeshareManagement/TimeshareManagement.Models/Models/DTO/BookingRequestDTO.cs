using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeshareManagement.Models.Models.DTO
{
    public class BookingRequestDTO
    {
        public int bookingRequestId { get; set; }
        public DateTime? bookingDate { get; set; }
        public RoomDTO? room { get; set; }
        public UserDTO? User { get; set; }
    }
}

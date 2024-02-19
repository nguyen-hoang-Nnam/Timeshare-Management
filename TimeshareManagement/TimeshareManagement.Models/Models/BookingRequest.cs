using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeshareManagement.Models.Models
{
    public class BookingRequest
    {
        [Key]
        public int bookingRequestId {  get; set; }
        public DateTime? bookingDate { get; set; }
        public int? roomID { get; set; }
        [ForeignKey("roomID")]
        public Room? room { get; set; }
        public string? Id { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser? User { get; set; }
    }
}

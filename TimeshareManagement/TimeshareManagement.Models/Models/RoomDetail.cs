using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeshareManagement.Models.Models
{
    public class RoomDetail
    {
        public int roomDetailId { get; set; }
        public string? Detail { get; set; }
        public string? image { get; set; }
        public int? roomID { get; set; }
        [ForeignKey("roomID")]
        public Room? Room { get; set; }
        public int? roomAmenitiesId { get; set; }
        [ForeignKey("roomAmenitiesId")]
        public RoomAmenities? RoomAmenities { get; set; }
    }
}

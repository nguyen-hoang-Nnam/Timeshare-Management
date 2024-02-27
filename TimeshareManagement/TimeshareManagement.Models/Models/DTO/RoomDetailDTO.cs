using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeshareManagement.Models.Models.DTO
{
    public class RoomDetailDTO
    {
        public int roomDetailId { get; set; }
        public string? Detail { get; set; }
        public string? image { get; set; }
        public RoomDTO? Room { get; set; }
    }
}

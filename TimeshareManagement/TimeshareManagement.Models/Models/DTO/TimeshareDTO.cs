﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeshareManagement.Models.Models.DTO
{
    public class TimeshareDTO
    {
        public int timeshareId { get; set; }
        public string? timeshareName { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
        public string? Address { get; set; }
        /*public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }*/
        public TimeshareStatusDTO? TimeshareStatus { get; set; }
        public PlaceDTO? Place { get; set; }
        public string? Id { get; set; }
        public UserDTO? User { get; set; }
    }
}

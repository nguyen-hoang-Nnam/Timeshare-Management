﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeshareManagement.Models.Models;

namespace TimeshareManagement.DataAccess.Repository.IRepository
{
    public interface IRoomRepository : IRepository<Room>
    {
        /*Task<IEnumerable<Room>> GetRoomAsync(int page, int pageSize, string searchTerm);*/
    }
}

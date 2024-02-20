using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TimeshareManagement.DataAccess.Data;
using TimeshareManagement.DataAccess.Repository.IRepository;
using TimeshareManagement.Models.Models;

namespace TimeshareManagement.DataAccess.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        private readonly IRepository<Room> _repository;
        public RoomRepository(ApplicationDbContext db, IMapper mapper, IRepository<Room> repository) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
            _repository = repository;
        }

        /*public async Task<IEnumerable<Room>> GetRoomAsync(int page, int pageSize, string searchTerm)
        {
            *//*Expression<Func<Room, bool>> filter = null;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                filter = item => item.Price.Contains(searchTerm);
            }*/
            /*if (int.TryParse(searchTerm, out int searchPrice))
            {
                Expression<Func<Room, bool>> filter = item => item.Price == searchPrice;

                return await _repository.GetPagedAsync(page, pageSize, filter);
            }
            else
            {
                // Handle the case where searchTerm is not a valid integer
                return Enumerable.Empty<Room>();
            }*/

            /*return await _repository.GetPagedAsync(page, pageSize, filter);*//*

            
        }*/
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TimeshareManagement.DataAccess.Data;
using TimeshareManagement.DataAccess.Migrations;
using TimeshareManagement.DataAccess.Repository.IRepository;
using TimeshareManagement.Models.Models;
using TimeshareManagement.Models.Models.DTO;

namespace TimeshareManagement.API.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly ITimeshareRepository _timeshareRepository;

        public RoomController(IConfiguration configuration, ApplicationDbContext db, IMapper mapper, IRoomRepository roomRepository, ITimeshareRepository timeshareRepository)
        {
            _configuration = configuration;
            _db = db;
            _mapper = mapper;
            _roomRepository = roomRepository;
            _timeshareRepository = timeshareRepository;
        }
        [HttpGet]
        [Route("GetAllRoom")]
        public async Task<IActionResult> GetAllRoom()
        {
            try
            {
                var room = await _roomRepository.GetAll();
                return Ok(new ResponseDTO { Result = room, IsSucceed = true, Message = "Room retrived successfully." });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpGet]
        [Route("GetRoomById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var room = await _roomRepository.GetById(id);
                if (room == null)
                {
                    return NotFound(new ResponseDTO { Result = null, IsSucceed = false, Message = "Room not found." });
                }
                else
                {
                    return Ok(new ResponseDTO { Result = room, IsSucceed = true, Message = "Room retrieved successfully." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpPost]
        [Route("CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            try
            {
                if (room == null)
                {
                    return BadRequest(new ResponseDTO { Result = null, IsSucceed = false, Message = "Timeshare object is null." });
                }

                IEnumerable<Timeshare> timeshares = _timeshareRepository.GetAllItem();
                if (room.Timeshare != null) 
                {
                    room.Timeshare = timeshares.FirstOrDefault(ts => ts.timeshareName == room.Timeshare.timeshareName);
                }
                else
                {
                    return BadRequest(new ResponseDTO { Result = null, IsSucceed = false, Message = "Timeshare object is null." });
                }
                await _roomRepository.Create(room);
                return Ok(new ResponseDTO { Result = room, IsSucceed = true, Message = "Create Room successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpPut]
        [Route("UpdateRoom/{id:int}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room room)
        {
            try
            {
                var existingRoom = await _roomRepository.GetById(id);
                if (existingRoom == null)
                {
                    return NotFound(new ResponseDTO { Result = null, IsSucceed = false, Message = "Room not found." });
                }
                else
                {
                    
                    existingRoom.Checkin = room.Checkin;
                    existingRoom.Checkout = room.Checkout;
                    existingRoom.Price = room.Price;
                    existingRoom.Rooms = room.Rooms;
                    existingRoom.Sleeps = room.Sleeps;
                    existingRoom.timeshareId = room.timeshareId;
                    
                    await _roomRepository.Update(existingRoom);
                }
                return Ok(new ResponseDTO { Result = room, IsSucceed = true, Message = "Update Room successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpDelete]
        [Route("DeleteRoom/{id:int}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                await _roomRepository.DeleteById(id);
                return Ok(new ResponseDTO { Result = null, IsSucceed = true, Message = "Delete Room successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRoom(int page, int pageSize, decimal? searchPrice)
        {
            try
            {
                Expression<Func<Room, bool>> filter = null;

                /*if (!string.IsNullOrEmpty(searchName))
                {
                    filter = entity => entity.Name.Contains(searchName);
                }*/
                if (searchPrice.HasValue)
                {
                    filter = entity => entity.Price == searchPrice.Value;
                }
                var item = await _roomRepository.GetPagedAsync(page, pageSize, filter);
                return Ok(new ResponseDTO { Result = item, IsSucceed = true, Message = "Paging Room successfully" });
            } catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
    }
}

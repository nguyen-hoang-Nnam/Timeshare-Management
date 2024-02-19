using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeshareManagement.DataAccess.Data;
using TimeshareManagement.DataAccess.Repository.IRepository;
using TimeshareManagement.Models.Models;
using TimeshareManagement.Models.Models.DTO;

namespace TimeshareManagement.API.Controllers
{
    [Route("api/roomDetail")]
    [ApiController]
    public class RoomDetailController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IRoomDetailRepository _roomDetailRepository;

        public RoomDetailController(IConfiguration configuration, ApplicationDbContext db, IMapper mapper, IRoomDetailRepository roomDetailRepository)
        {
            _configuration = configuration;
            _db = db;
            _mapper = mapper;
            _roomDetailRepository = roomDetailRepository;
        }
        [HttpGet]
        [Route("GetAllRoomDetail")]
        public async Task<IActionResult> GetAllRoomDetail()
        {
            try
            {
                var roomDetail = await _roomDetailRepository.GetAll();
                return Ok(new ResponseDTO { Result = roomDetail, IsSucceed = true, Message = "Room Detail retrived successfully." });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpGet]
        [Route("GetRoomDetailById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var roomDetail = await _roomDetailRepository.GetById(id);
                if (roomDetail == null)
                {
                    return NotFound(new ResponseDTO { Result = null, IsSucceed = false, Message = "Room Detail not found." });
                }
                else
                {
                    return Ok(new ResponseDTO { Result = roomDetail, IsSucceed = true, Message = "Room Detail retrieved successfully." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpPost]
        [Route("CreateRoomDetail")]
        public async Task<IActionResult> CreateRoomDetail([FromBody] RoomDetail roomDetail)
        {
            try
            {
                await _roomDetailRepository.Create(roomDetail);
                return Ok(new ResponseDTO { Result = roomDetail, IsSucceed = true, Message = "Create Room Detail successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpPut]
        [Route("UpdateRoom/{id:int}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomDetail roomDetail)
        {
            try
            {
                var existingRoomDetail = await _roomDetailRepository.GetById(id);
                if (existingRoomDetail == null)
                {
                    return NotFound(new ResponseDTO { Result = null, IsSucceed = false, Message = "Room not found." });
                }
                else
                {

                    existingRoomDetail.Detail = roomDetail.Detail;
                    existingRoomDetail.image = roomDetail.image;
                    //
                    existingRoomDetail.roomDetailId = roomDetail.roomDetailId;
                    existingRoomDetail.roomAmenitiesId = roomDetail.roomAmenitiesId;
                    //
                    await _roomDetailRepository.Update(existingRoomDetail);
                }
                return Ok(new ResponseDTO { Result = roomDetail, IsSucceed = true, Message = "Update Room successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpDelete]
        [Route("DeleteRoomDetail/{id:int}")]
        public async Task<IActionResult> DeleteRoomDetail(int id)
        {
            try
            {
                await _roomDetailRepository.DeleteById(id);
                return Ok(new ResponseDTO { Result = null, IsSucceed = true, Message = "Delete Room successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
    }
}

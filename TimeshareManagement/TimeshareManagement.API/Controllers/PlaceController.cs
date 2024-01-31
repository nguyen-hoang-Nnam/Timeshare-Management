using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeshareManagement.DataAccess.Data;
using TimeshareManagement.DataAccess.Repository;
using TimeshareManagement.DataAccess.Repository.IRepository;
using TimeshareManagement.Models.Models;
using TimeshareManagement.Models.Models.DTO;

namespace TimeshareManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IPlaceRepository _placeRepository;

        public PlaceController(IConfiguration configuration, ApplicationDbContext db, IMapper mapper, IPlaceRepository placeRepository)
        {
            _configuration = configuration;
            _db = db;
            _mapper = mapper;
            _placeRepository = placeRepository;
        }
        [HttpGet]
        [Route("GetAllPlace")]
        public async Task<IActionResult> GetAllPlace()
        {
            try
            {
                var place = await _placeRepository.GetAll();
                return Ok(new ResponseDTO { Result = place, IsSucceed = true, Message = "Place retrived successfully." });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpGet]
        [Route("GetPlaceById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var place = await _placeRepository.GetById(id);
                if (place == null)
                {
                    return NotFound(new ResponseDTO { Result = null, IsSucceed = false, Message = "Place not found." });
                }
                else
                {
                    return Ok(new ResponseDTO { Result = place, IsSucceed = true, Message = "Place retrieved successfully." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpPost]
        [Route("CreatePlace")]
        public async Task<IActionResult> CreatePlace([FromBody] Place place)
        {
            try
            {
                await _placeRepository.Create(place);
                return Ok(new ResponseDTO { Result = place, IsSucceed = true, Message = "Create Place successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpDelete]
        [Route("DeletePlace/{id:int}")]
        public async Task<IActionResult> DeletePlace(int id)
        {
            try
            {
                await _placeRepository.DeleteById(id);
                return Ok(new ResponseDTO { Result = null, IsSucceed = true, Message = "Delete Place successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq.Expressions;
using TimeshareManagement.DataAccess.Data;
using TimeshareManagement.DataAccess.Repository;
using TimeshareManagement.DataAccess.Repository.IRepository;
using TimeshareManagement.Models.Models;
using TimeshareManagement.Models.Models.DTO;

namespace TimeshareManagement.API.Controllers
{
    [Route("api/timeshare")]
    [ApiController]
    public class TimeshareController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ITimeshareRepository _timeshareRepository;

        public TimeshareController(IConfiguration configuration, ApplicationDbContext db, IMapper mapper, ITimeshareRepository timeshareRepository)
        {
            _configuration = configuration;
            _db = db;
            _mapper = mapper;
            _timeshareRepository = timeshareRepository;
        }
        [HttpGet]
        [Route("GetAllTimeshare")]
        public async Task<IActionResult> GetAllTimeshare()
        {
            try
            {
                var timeshare = await _timeshareRepository.GetAll();
                return Ok(new ResponseDTO { Result = timeshare, IsSucceed = true, Message = "Timeshare retrived successfully." });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpGet]
        [Route("GetTimeshareById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var timeshare = await _timeshareRepository.GetById(id);
                if (timeshare == null)
                {
                    return NotFound(new ResponseDTO { Result = null, IsSucceed = false, Message = "Timeshare not found." });
                } else
                {
                    return Ok(new ResponseDTO { Result = timeshare, IsSucceed = true, Message = "Timeshare retrieved successfully." });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpPost]
        [Route("CreateTimeshare")]
        public async Task<IActionResult> CreateTimeshare([FromBody] Timeshare timeshare)
        {
            try
            {
                await _timeshareRepository.Create(timeshare);
                return Ok(new ResponseDTO { Result = timeshare, IsSucceed = true, Message = "Create Timeshare successfully" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpPut]
        [Route("UpdateTimeshare/{id:int}")]
        public async Task<IActionResult> UpdateTimeshare(int id, [FromBody] Timeshare timeshare)
        {
            try
            {
                var existingTimeshare = await _timeshareRepository.GetById(id);
                if (existingTimeshare == null)
                {
                    return NotFound(new ResponseDTO { Result = null, IsSucceed = false, Message = "Timeshare not found." });
                } else
                {
                    existingTimeshare.timeshareName = timeshare.timeshareName;
                    existingTimeshare.Price = timeshare.Price;
                    existingTimeshare.Address = timeshare.Address;
                    existingTimeshare.Image = timeshare.Image;
                    existingTimeshare.placeId = timeshare.placeId;
                    existingTimeshare.User = timeshare.User;
                    existingTimeshare.timeshareStatusId = timeshare.timeshareStatusId;
                    //
                    /*existingTimeshare.timeshareStatusId = id;*/
                    await _timeshareRepository.Update(existingTimeshare);
                }
                return Ok(new ResponseDTO { Result = timeshare, IsSucceed = true, Message = "Update Timeshare successfully" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpDelete]
        [Route("DeleteTimeshare/{id:int}")]
        public async Task<IActionResult> DeleteTimeshare(int id)
        {
            try
            {
                await _timeshareRepository.DeleteById(id);
                return Ok(new ResponseDTO { Result = null, IsSucceed = true, Message = "Delete Timeshare successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTimeshare(int page, int pageSize, decimal? searchPrice)
        {
            try
            {
                Expression<Func<Timeshare, bool>> filter = null;

                /*if (!string.IsNullOrEmpty(searchName))
                {
                    filter = entity => entity.Name.Contains(searchName);
                }*/
                /*if (searchPrice.HasValue)
                {
                    filter = entity => entity.Price == searchPrice.Value;
                }*/
                var item = await _timeshareRepository.GetPagedAsync(page, pageSize, filter);
                return Ok(new ResponseDTO { Result = item, IsSucceed = true, Message = "Paging Room successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
    }
}


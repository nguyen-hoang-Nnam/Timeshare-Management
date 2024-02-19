using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeshareManagement.DataAccess.Data;
using TimeshareManagement.DataAccess.Repository.IRepository;
using TimeshareManagement.Models.Models.DTO;

namespace TimeshareManagement.API.Controllers
{
    [Route("api/BookingRequest")]
    [ApiController]
    public class BookingRequestController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IBookingRequestRepository _bookingRequestRepository;

        public BookingRequestController(IConfiguration configuration, ApplicationDbContext db, IMapper mapper, IBookingRequestRepository bookingRequestRepository)
        {
            _configuration = configuration;
            _db = db;
            _mapper = mapper;
            _bookingRequestRepository = bookingRequestRepository;
        }
        [HttpGet]
        [Route("GetAllBookingRequest")]
        public async Task<IActionResult> GetAllBookingRequest()
        {
            try
            {
                var bookingRequest = await _bookingRequestRepository.GetAll();
                return Ok(new ResponseDTO { Result = bookingRequest, IsSucceed = true, Message = "Room retrived successfully." });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ResponseDTO { Result = null, IsSucceed = false, Message = $"Error: {ex.Message}" });
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoldApi.DTOs;
using MoldApi.Interfaces;

namespace MoldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoldController : ControllerBase
    {
        private readonly IMoldService _service;

        public MoldController(IMoldService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllMolds();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetMoldById(id);
            return Ok(result);
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> GetDropdown()
        {
            var result = await _service.GetMoldDropdown();
            return Ok(result);
        }
        [HttpGet("PMFreqdropdown")]
        public async Task<IActionResult> GetPMDropdown()
        {
            var result = await _service.GetPMDropdown();
            return Ok(result);
        }
        [HttpGet("PMPlan")]
        public async Task<IActionResult> GetPMPlanDetails()
        {
            var result = await _service.GetPMPlanDetails();
            return Ok(result);
        }

        [HttpPost("pmschedule")]
        public async Task<IActionResult> InsertPMSchedule(CreateMoldPMScheduleDto dto)
        {
            var result = await _service.InsertMoldPMSchedule(dto);

            if (result.Contains("Already"))
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPut("pmscheduleUpdate")]
        public async Task<IActionResult> UpdatePMSchedule(UpdateMoldPMScheduleDto dto)
        {
            var result = await _service.UpdateMoldPMSchedule(dto);

            if (result.Contains("Already"))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("pmschedulebyid/{id}")]
        public async Task<IActionResult> GetPMScheduleById(int id)
        {
            var result = await _service.GetPMScheduleById(id);

            if (result == null)
                return NotFound("PM Schedule not found");

            return Ok(result);
        }

    }
}

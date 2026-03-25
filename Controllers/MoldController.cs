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

        [HttpPost("pmschedule")]
        public async Task<IActionResult> InsertPMSchedule(CreateMoldPMScheduleDto dto)
        {
            var result = await _service.InsertMoldPMSchedule(dto);

            if (result.Contains("Already"))
                return BadRequest(result);

            return Ok(result);
        }

    }
}

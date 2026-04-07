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
        [HttpGet("MoldSpecFetch")]
        public async Task<IActionResult> GetMoldSpecFetch()
        {
            var result = await _service.GetMoldSpecFetch();
            return Ok(result);
        }

        [HttpGet("alldropdowns")]
        public async Task<IActionResult> GetAllDropdowns()
        {
            var result = await _service.GetAllDropdowns();
            return Ok(result);
        }
        [HttpGet("Imgdropdown")]
        public async Task<IActionResult> GetMoldImgDropdown()
        {
            var result = await _service.GetMoldImgDropdown();
            return Ok(result);
        }
        [HttpGet("PMFreqdropdown")]
        public async Task<IActionResult> GetPMDropdown()
        {
            var result = await _service.GetPMDropdown();
            return Ok(result);
        }
        [HttpGet("PMCheckSheetFetch")]
        public async Task<IActionResult> GetPMCheckSheetFetch()
        {
            var result = await _service.GetPMCheckSheetFetch();
            return Ok(result);
        }
        [HttpGet("MouldMstFetch")]
        public async Task<IActionResult> GetMouldMstFetch()
        {
            var result = await _service.GetMouldMstFetch();
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
        [HttpPost("Insertspecentry")]
        public async Task<IActionResult> InsertMaintenanceSpecEntry(CreateMaintenanceSpecEntryDto dto)
        {
            var result = await _service.InsertMaintenanceSpecEntry(dto);

            if (result.Contains("This Orderby No Already Exists!."))
            {
                return BadRequest(new ERRORAPIDTO
                {
                    Success = false,
                    Message = result
                });
            }

            if (result.Contains("Exception") || result.Contains("Error"))
            {
                return StatusCode(500, new ERRORAPIDTO
                {
                    Success = false,
                    Message = result
                });
            }

            return Ok(new ERRORAPIDTO
            {
                Success = true,
                Message = result
            });
        }
        [HttpPost("Insert-CheckAll")]
        public async Task<IActionResult> InsertCheckMasterAsync(CheckInsertDto dto)
        {
            var result = await _service.InsertCheckMasterAsync(dto);

            if (result.Contains("Check Area already exists.") || result.Contains("Check Point already exists.")
                || result.Contains("Check Method already exists.") || result.Contains("Req Condition already exists."))
            {
                return BadRequest(new ERRORAPIDTO
                {
                    Success = false,
                    Message = result
                });
            }

            if (result.Contains("Exception") || result.Contains("Error"))
            {
                return StatusCode(500, new ERRORAPIDTO
                {
                    Success = false,
                    Message = result
                });
            }

            return Ok(new ERRORAPIDTO
            {
                Success = true,
                Message = result
            });
        }
        [HttpPost("InsertMould")]
        public async Task<IActionResult> InsertMoldMst(InsertMouldMstDto dto)
        {
            var result = await _service.InsertMoldMst(dto);

            if (result.Contains("Already Code Exist!") || result.Contains("Already Exist!, Use Edit Option"))
            {
                return BadRequest(new ERRORAPIDTO
                {
                    Success = false,
                    Message = result
                });
            }

            if (result.Contains("Exception") || result.Contains("Error"))
            {
                return StatusCode(500, new ERRORAPIDTO
                {
                    Success = false,
                    Message = result
                });
            }

            return Ok(new ERRORAPIDTO
            {
                Success = true,
                Message = result
            });
        }
        [HttpPut("pmscheduleUpdate")]
        public async Task<IActionResult> UpdatePMSchedule(UpdateMoldPMScheduleDto dto)
        {
            var result = await _service.UpdateMoldPMSchedule(dto);

            if (result.Contains("Already"))
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPut("UpdateMouldMst")]
        public async Task<IActionResult> UpdateMoldMst(UpdateMouldMstDto dto)
        {
            var result = await _service.UpdateMoldMst(dto);

            if (result.Contains("Already"))
                return BadRequest(result);

            return Ok(result);
        }
        [HttpDelete("pmplan/{id}")]
        public async Task<IActionResult> DeletePMPlan(int id)
        {
            var result = await _service.DeletePMPlan(id);
            if (result.Contains("not found") || result.Contains("Error"))
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet("mouldbyid/{id}")]
        public async Task<IActionResult> GetMouldMstById(int id)
        {
            var result = await _service.GetMouldMstById(id);

            if (result == null)
                return NotFound("not found");

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

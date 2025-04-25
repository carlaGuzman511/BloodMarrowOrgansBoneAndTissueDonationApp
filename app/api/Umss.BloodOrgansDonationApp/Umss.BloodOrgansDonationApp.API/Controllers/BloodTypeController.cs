using Microsoft.AspNetCore.Mvc;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Controllers
{
    [ApiController]
    [Route("bloodTypes")]
    public class BloodTypeController : ControllerBase
    {
        private readonly IBloodTypeService _bloodTypeService;

        public BloodTypeController(IBloodTypeService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BloodType>> Get(Guid id)
        {
            try
            {
                var response = await _bloodTypeService.Get(id);
                return Ok(response);
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _bloodTypeService.Delete(id);
                return NoContent();
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodType>>> Get()
        {
            try
            {
                var response = await _bloodTypeService.GetAll();
                return Ok(response);
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BloodType>> Create([FromBody] BloodTypeRequest bloodTypeRequest)
        {
            try 
            { 
                var response = await _bloodTypeService.Create(bloodTypeRequest);
                return Ok(response);
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BloodType>> Update(Guid id, [FromBody] BloodTypeRequest bloodTypeRequest)
        {
            try
            {
                var response = await _bloodTypeService.Update(id, bloodTypeRequest);
                return Ok(response);
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

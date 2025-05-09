using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Controllers
{
    [ApiController]
    [Route("api/blood-types")]
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
                BloodType? response = await _bloodTypeService.Get(id);
                if (response == null)
                {
                    return NotFound($"Blood type with ID {id} not found.");
                }

                return Ok(response);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        //TODO: Implement a soft delete
        [HttpDelete("{id}")]
        internal async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                BloodType? response = await _bloodTypeService.Get(id);
                if (response == null)
                {
                    return NotFound($"Blood Type with ID {id} not found.");
                }

                await _bloodTypeService.Delete(id);
                return NoContent();
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodType>>> Get()
        {
            try
            {
                IEnumerable<BloodType> response = await _bloodTypeService.GetAll();
                return Ok(response);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BloodType>> Create([FromBody] BloodTypeRequest bloodTypeRequest)
        {
            try 
            {
                BloodType response = await _bloodTypeService.Create(bloodTypeRequest);
                return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BloodType>> Update(Guid id, [FromBody] BloodTypeRequest bloodTypeRequest)
        {
            try
            {
                BloodType response = await _bloodTypeService.Update(id, bloodTypeRequest);
                return Ok(response);
            }
            catch(EntityNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}

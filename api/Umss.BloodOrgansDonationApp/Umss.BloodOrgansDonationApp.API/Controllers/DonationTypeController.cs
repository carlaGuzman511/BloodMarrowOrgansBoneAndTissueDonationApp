using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Controllers
{
    [Controller]
    [Route("api/donation-types")]
    public class DonationTypeController: ControllerBase
    {
        private readonly IDonationTypeService _donationTypeService;

        public DonationTypeController(IDonationTypeService donationTypeService)
        {
            _donationTypeService = donationTypeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DonationTypeResponse>> Get(Guid id)
        {
            try
            {
                DonationTypeResponse? response = await _donationTypeService.Get(id);
                if (response == null)
                {
                    return NotFound($"Donation Type with ID {id} not found.");
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

        [HttpDelete("{id}")]
        internal async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                DonationTypeResponse? donationType = await _donationTypeService.Get(id);
                if (donationType == null)
                {
                    return NotFound($"Donation Type with ID {id} not found.");
                }

                await _donationTypeService.Delete(id);
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
        public async Task<ActionResult<IEnumerable<DonationTypeResponse>>> Get()
        {
            try
            {
                IEnumerable<DonationTypeResponse> response = await _donationTypeService.GetAll();
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
        public async Task<ActionResult<DonationTypeResponse>> Create([FromBody] DonationTypeRequest donationTypeRequest)
        {
            try
            {
                DonationTypeResponse response = await _donationTypeService.Create(donationTypeRequest);
                return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage)});
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DonationTypeResponse>> Update(Guid id, [FromBody] DonationTypeRequest donationTypeRequest)
        {
            try
            {
                DonationTypeResponse response = await _donationTypeService.Update(id, donationTypeRequest);
                return Ok(response);
            }
            catch(EntityNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage)});
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}

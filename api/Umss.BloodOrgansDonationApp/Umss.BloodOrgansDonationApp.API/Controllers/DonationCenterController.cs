using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Controllers
{
    [Controller]
    [Route("api/donation-centers")]
    public class DonationCenterController : ControllerBase
    {
        private readonly IDonationCenterService _donationCenterService;

        public DonationCenterController(IDonationCenterService donationCenterService)
        {
            _donationCenterService = donationCenterService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationCenterResponse>> Get(Guid id)
        {
            try
            {
                DonationCenterResponse? response = await _donationCenterService.Get(id);
                if (response == null)
                {
                    return NotFound($"Donation Center with ID {id} not found.");
                }

                return Ok(response);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new {errors = exception.Errors.Select(e => e.ErrorMessage)});
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationCenterResponse>>> Get()
        {
            try
            {
                IEnumerable<DonationCenterResponse> response = await _donationCenterService.GetAll();
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

        [Authorize]
        [HttpDelete("{id}")]
        internal async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                DonationCenterResponse? response = await _donationCenterService.Get(id);
                if (response == null)
                {
                    return NotFound($"Donation Center with ID {id} not found.");
                }

                await _donationCenterService.Delete(id);
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<DonationCenterResponse>> Create([FromBody] DonationCenterRequest donationCenterRequest)
        {
            try
            {
                DonationCenterResponse response = await _donationCenterService.Create(donationCenterRequest);
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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<DonationCenterResponse>> Update(Guid id, [FromBody] DonationCenterRequest donationCenterRequest)
        {
            try
            {
                DonationCenterResponse response = await _donationCenterService.Update(id, donationCenterRequest);
                return Ok(response);
            }
            catch (EntityNotFoundException exception)
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

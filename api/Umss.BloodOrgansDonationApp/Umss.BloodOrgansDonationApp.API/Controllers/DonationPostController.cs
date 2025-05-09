using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Controllers
{
    [Controller]
    [Route("api")]
    public class DonationPostController: ControllerBase
    {
        private readonly IDonationPostService _DonationPostService;

        public DonationPostController(IDonationPostService DonationPostService)
        {
            _DonationPostService = DonationPostService;
        }

        [HttpGet("users/{userId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult<DonationPost>> Get(Guid userId, Guid donationPostId)
        {
            try
            {
                DonationPost? response = await _DonationPostService.Get(id);
                if(response == null)
                {
                    return NotFound($"Donation Post with ID {id} not found.");
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

        [HttpDelete("users/{userId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult> Delete(Guid userId, Guid donationPostId)
        {
            try
            {
                DonationPost? response = await _DonationPostService.Get(id);
                if (response == null)
                {
                    return NotFound($"Donation Post with ID {id} not found.");
                }

                await _DonationPostService.Delete(id);
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

        [HttpGet("users/{userId}/donation-posts")]
        public async Task<ActionResult<IEnumerable<DonationPost>>> Get(Guid userId)
        {
            try
            {
                IEnumerable<DonationPost> response = await _DonationPostService.GetAll();
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

        [HttpPost("users/{userId}/donation-posts")]
        public async Task<ActionResult<DonationPost>> Create(Guid userId, [FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                DonationPost response = await _DonationPostService.Create(donationPostRequest);
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

        [HttpPut("users/{userId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult<DonationPost>> Update(Guid userId, Guid donationPostId, [FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                DonationPost response = await _DonationPostService.Update(id, donationPostRequest);
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

        [HttpGet("donation-centers/{donationCenterId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult<DonationPost>> Get(Guid donationCenterId, Guid donationPostId)
        {
            try
            {
                DonationPost? response = await _DonationPostService.Get(id);
                if (response == null)
                {
                    return NotFound($"Donation Post with ID {id} not found.");
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

        [HttpDelete("donation-centers/{donationCenterId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult> Delete(Guid donationCenterId, Guid donationPostId)
        {
            try
            {
                DonationPost? response = await _DonationPostService.Get(id);
                if (response == null)
                {
                    return NotFound($"Donation Post with ID {id} not found.");
                }

                await _DonationPostService.Delete(id);
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

        [HttpGet("donation-centers/{donationCenterId}/donation-posts")]
        public async Task<ActionResult<IEnumerable<DonationPost>>> Get(Guid donationCenterId)
        {
            try
            {
                IEnumerable<DonationPost> response = await _DonationPostService.GetAll();
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

        [HttpPost("donation-centers/{donationCenterId}/donation-posts")]
        public async Task<ActionResult<DonationPost>> Create(Guid donationCenterId, [FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                DonationPost response = await _DonationPostService.Create(donationPostRequest);
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

        [HttpPut("donation-centers/{donationCenterId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult<DonationPost>> Update(Guid donationCenterId, Guid donationPostId, [FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                DonationPost response = await _DonationPostService.Update(id, donationPostRequest);
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

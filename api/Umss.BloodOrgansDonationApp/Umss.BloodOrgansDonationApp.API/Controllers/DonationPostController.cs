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
    [Route("api")]
    public class DonationPostController: ControllerBase
    {
        private readonly IDonationPostService _DonationPostService;

        public DonationPostController(IDonationPostService DonationPostService)
        {
            _DonationPostService = DonationPostService;
        }

        [Authorize]
        [HttpGet("users/{userId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult<DonationPostResponse>> GetByUser(Guid userId, Guid donationPostId)
        {
            try
            {
                DonationPostResponse? response = await _DonationPostService.GetByUser(userId, donationPostId);
                if(response == null)
                {
                    return NotFound($"Donation Post ID {donationPostId}, and User ID {userId} not found.");
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
        [HttpDelete("users/{userId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult> DeleteByUser(Guid userId, Guid donationPostId)
        {
            try
            {
                DonationPostResponse? response = await _DonationPostService.GetByUser(userId, donationPostId);
                if (response == null)
                {
                    return NotFound($"Donation Post ID {donationPostId}, and User ID {userId} not found.");
                }

                await _DonationPostService.DeleteByUser(userId, donationPostId);
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
        [HttpGet("users/{userId}/donation-posts")]
        public async Task<ActionResult<IEnumerable<DonationPostResponse>>> GetByUser(Guid userId)
        {
            try
            {
                IEnumerable<DonationPostResponse> response = await _DonationPostService.GetByUser(userId);
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
        [HttpPost("users/{userId}/donation-posts")]
        public async Task<ActionResult<DonationPostResponse>> CreateByUser(Guid userId, [FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                DonationPostResponse response = await _DonationPostService.CreateByUser(userId, donationPostRequest);
                return StatusCode(StatusCodes.Status201Created, response);
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
        [HttpPut("users/{userId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult<DonationPostResponse>> UpdateByUser(Guid userId, Guid donationPostId, [FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                DonationPostResponse response = await _DonationPostService.UpdateByUser(userId, donationPostId, donationPostRequest);
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

        [Authorize]
        [HttpGet("donation-centers/{donationCenterId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult<DonationPostResponse>> GetByDonationCenter(Guid donationCenterId, Guid donationPostId)
        {
            try
            {
                DonationPostResponse? response = await _DonationPostService.GetByDonationCenter(donationCenterId, donationPostId);
                if (response == null)
                {
                    return NotFound($"Donation Post ID {donationPostId}, and Donation Center ID {donationCenterId} not found.");
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

        [Authorize]
        [HttpDelete("donation-centers/{donationCenterId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult> DeleteByDonationCenter(Guid donationCenterId, Guid donationPostId)
        {
            try
            {
                DonationPostResponse? response = await _DonationPostService.GetByDonationCenter(donationCenterId, donationPostId);
                if (response == null)
                {
                    return NotFound($"Donation Post ID {donationPostId}, and Donation Center ID {donationCenterId} not found.");
                }

                await _DonationPostService.DeleteByDonationCenter(donationCenterId, donationPostId);
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
        [HttpGet("donation-centers/{donationCenterId}/donation-posts")]
        public async Task<ActionResult<IEnumerable<DonationPostResponse>>> GetByDonationCenter(Guid donationCenterId)
        {
            try
            {
                IEnumerable<DonationPostResponse> response = await _DonationPostService.GetByDonationCenter(donationCenterId);
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
        [HttpPost("donation-centers/{donationCenterId}/donation-posts")]
        public async Task<ActionResult<DonationPostResponse>> CreateByDonationCenter(Guid donationCenterId, [FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                DonationPostResponse response = await _DonationPostService.CreateByDonationCenter(donationCenterId, donationPostRequest);
                return StatusCode(StatusCodes.Status201Created, response);
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
        [HttpPut("donation-centers/{donationCenterId}/donation-posts/{donationPostId}")]
        public async Task<ActionResult<DonationPostResponse>> UpdateByDonationCenter(Guid donationCenterId, Guid donationPostId, [FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                DonationPostResponse response = await _DonationPostService.UpdateByDonationCenter(donationCenterId, donationPostId, donationPostRequest);
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

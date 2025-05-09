using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Controllers
{
    [Controller]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> Get(Guid id)
        {
            try
            {
                UserResponse? response = await _userService.Get(id);
                if (response == null) { 
                    return NotFound($"User with ID {id} not found.");
                }

                return Ok(response);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> Get()
        {
            try
            {
                IEnumerable<UserResponse> response = await _userService.GetAll();
                return Ok(response);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //TODO: implement a soft delete
        [HttpDelete("{id}")]
        internal async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                UserResponse? response = await _userService.Get(id);
                if (response == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                await _userService.Delete(id);
                return NoContent();
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> Create([FromBody] UserRequest userRequest)
        {
            try
            {
                UserResponse response = await _userService.Create(userRequest);
                return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
            }
            catch (ValidationException exception)
            {
                return BadRequest(new { errors = exception.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> Update(Guid id, [FromBody] UserRequest userRequest)
        {
            try
            {
                UserResponse response = await _userService.Update(id, userRequest);
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

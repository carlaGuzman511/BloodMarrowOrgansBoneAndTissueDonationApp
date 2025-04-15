using Microsoft.AspNetCore.Mvc;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Controllers
{
    [Controller]
    [Route("users")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            try
            {
                var response = await _userService.Get(id);
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                var response = await _userService.GetAll();
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
        public async Task<ActionResult<User>> Delete(Guid id)
        {
            try
            {
                await _userService.Delete(id);
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

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] UserRequest userRequest)
        {
            try
            {
                var response = await _userService.Create(userRequest);
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
        public async Task<ActionResult<User>> Update(Guid id, [FromBody] UserRequest userRequest)
        {
            try
            {
                var response = await _userService.Update(id, userRequest);
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

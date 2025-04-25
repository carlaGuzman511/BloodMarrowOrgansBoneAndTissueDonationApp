using Microsoft.AspNetCore.Mvc;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Controllers
{
    [Controller]
    [Route("donationPosts")]
    public class DonationPostController: ControllerBase
    {
        private readonly IDonationPostService _DonationPostService;

        public DonationPostController(IDonationPostService DonationPostService)
        {
            _DonationPostService = DonationPostService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DonationPost>> Get(Guid id)
        {
            try
            {
                var response = await _DonationPostService.Get(id);
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
                await _DonationPostService.Delete(id);
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
        public async Task<ActionResult<IEnumerable<DonationPost>>> Get()
        {
            try
            {
                var response = await _DonationPostService.GetAll();
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
        public async Task<ActionResult<DonationPost>> Create([FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                var response = await _DonationPostService.Create(donationPostRequest);
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
        public async Task<ActionResult<DonationPost>> Update(Guid id, [FromBody] DonationPostRequest donationPostRequest)
        {
            try
            {
                var response = await _DonationPostService.Update(id, donationPostRequest);
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

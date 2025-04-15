using Microsoft.AspNetCore.Mvc;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Controllers
{
    [Controller]
    [Route("donationTypes")]
    public class DonationTypeController: ControllerBase
    {
        private readonly IDonationTypeService _donationTypeService;

        public DonationTypeController(IDonationTypeService donationTypeService)
        {
            _donationTypeService = donationTypeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DonationType>> Get(Guid id)
        {
            try
            {
                var response = await _donationTypeService.Get(id);
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
        public async Task<ActionResult<DonationType>> Delete(Guid id)
        {
            try
            {
                await _donationTypeService.Delete(id);
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
        public async Task<ActionResult<DonationType>> Get()
        {
            try
            {
                var response = await _donationTypeService.GetAll();
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
        public async Task<ActionResult<DonationType>> Create([FromBody] DonationTypeRequest donationTypeRequest)
        {
            try
            {
                var response = await _donationTypeService.Create(donationTypeRequest);
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
        public async Task<ActionResult<DonationType>> Update(Guid id, [FromBody] DonationTypeRequest donationTypeRequest)
        {
            try
            {
                var response = await _donationTypeService.Update(id, donationTypeRequest);
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

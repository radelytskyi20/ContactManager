using ContactManager.Domain.Constants;
using ContactManager.Domain.Contracts;
using ContactManager.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class ResumesController : ControllerBase
    {
        private readonly IResumeManagerService _resumeManagerService;

        public ResumesController(IResumeManagerService resumeManagerService)
        {
            _resumeManagerService = resumeManagerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddResumeRequest request)
        {
            try
            {
                await _resumeManagerService.AddAsync(request.Name, request.BirthDate, request.Married, request.Phone, request.Salary);
                return Created();
            }
            catch (Exception)
            {
                //todo: log exception
                return StatusCode(500, ErrorMessages.InternalServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var resumes = await _resumeManagerService.GetAllAsync();
                return Ok(resumes);
            }
            catch (Exception)
            {
                //todo: log exception
                return StatusCode(500, ErrorMessages.InternalServerErrorMessage);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOneAsync([FromRoute] Guid id)
        {
            try
            {
                var resume = await _resumeManagerService.GetOneAsync(id);
                return resume is null ? NotFound() : Ok(resume);
            }
            catch (Exception)
            {
                //todo: log exception
                return StatusCode(500, ErrorMessages.InternalServerErrorMessage);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateResumeRequest request)
        {
            try
            {
                var updateResult = await _resumeManagerService.UpdateAsync(id, request.Name, request.BirthDate, request.Married,
                                request.Phone, request.Salary);

                return updateResult.IsSuccessful ? NoContent() : NotFound(updateResult.Errors);
            }
            catch (Exception)
            {
                //todo: log exception
                return StatusCode(500, ErrorMessages.InternalServerErrorMessage);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            try
            {
                var deleteResult = await _resumeManagerService.DeleteAsync(id);
                return deleteResult.IsSuccessful ? NoContent() : NotFound(deleteResult.Errors);
            }
            catch (Exception)
            {
                //todo: log exception
                return StatusCode(500, ErrorMessages.InternalServerErrorMessage);
            }
        }
    }
}

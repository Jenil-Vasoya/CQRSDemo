using CQRSDemo.Commands.CMS_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries.CMS_Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CMSController : Controller
    {
        private readonly IMediator mediator;

        public CMSController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("CMS Pagination/Search")]
        public async Task<IActionResult> FindCMS([FromQuery] Pagination dto)
        {
            if (string.IsNullOrEmpty(dto.Search) && dto.Page == 0 && dto.PageSize == 0)
            {
                return BadRequest("Fill Value");
            }
            List<Cmspage> cms = await mediator.Send(dto.ToCMSQuery());
            if (cms == null || cms.Count == 0)
            {
                return NotFound();
            }
            try
            {
                return Ok(cms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("All CMS")]
        public async Task<IActionResult> AllCMS()
        {

            var cms = await mediator.Send(new GetAllCMSQuery());

            if (cms == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(cms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Get CMS")]
        public async Task<IActionResult> GetCMSData(long CMSId)
        {
            var cms = await mediator.Send(new GetCMSDataQuery() { CMSId = CMSId });
            if (cms == null)
            {
                return NotFound();
            }
            return Ok(cms);
        }


        [HttpPost]
        [Route("Add CMS")]
        public async Task<IActionResult> AddCMS(string Title, string? Description, string Slug, bool? Status)
        {
            Cmspage cms = AddDataModel(null, Title, Description, Slug, Status);
            var command = new AddCMSDataCommand(cms);
            var result = await mediator.Send(command);

            if (cms == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(cms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private Cmspage AddDataModel(long? CMSId, string Title, string? Description, string Slug, bool? Status)
        {
            Cmspage model = new Cmspage();
            if (CMSId != null)
            {
                model.CmspageId = (long)CMSId;   
            }
            model.Title = Title;
            model.Description = Description;
            model.Slug = Slug;
            model.Status = Status;
            
            return model;
        }

        [HttpPut]
        [Route("Update CMS")]
        public async Task<IActionResult> UpdateCMS(long CMSId, string Title, string? Description, string Slug, bool? Status)
        {
            Cmspage cms = AddDataModel(CMSId, Title, Description, Slug, Status);
            var command = new EditCMSDataCommand(cms);
            var result = await mediator.Send(command);

            if (cms == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(cms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete CMS")]
        public async Task<IActionResult> DeleteCMS(long CMSId)
        {

            var command = await mediator.Send(new DeleteCMSDataCommand() { CMSId = CMSId });

            try
            {
                return Ok(command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}

using CQRSDemo.Commands.Application_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries.Application_Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CQRSDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {

        private readonly IMediator mediator;
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public ApplicationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("Application Pagination/Search")]
        public async Task<IActionResult> FindApplication([FromQuery] Pagination dto)
        {
            if (string.IsNullOrEmpty(dto.Search) && dto.Page == 0 && dto.PageSize == 0)
            {
                return BadRequest("Fill Value");
            }

            var applications = await mediator.Send(dto.ToApplicationQuery());

            //var applications = JsonSerializer.Deserialize<List<MissionApplication>>(application, options);
            if (applications == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("All Application")]
        public async Task<IActionResult> AllApplication()
        {

            var application = await mediator.Send(new GetAllApplicationQuery());

            if (application == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(application);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Get Application")]
        public async Task<IActionResult> GetApplicationData(long ApplicationId)
        {
            var application = await mediator.Send(new GetApplicationDataQuery() { ApplicationId = ApplicationId });
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }


      
        private MissionApplication AddDataModel(long? ApplicationId, string Status)
        {
            MissionApplication model = new MissionApplication();
            if (ApplicationId != null)
            {
                model.MissionApplicationId = (long)ApplicationId;
            }
            model.ApprovalStatus = Status;

            return model;
        }

        [HttpPut]
        [Route("Update Application")]
        public async Task<IActionResult> UpdateApplication(long ApplicationId, string Status)
        {
            MissionApplication application = AddDataModel(ApplicationId, Status);
            var command = new EditApplicationDataCommand(application);
            var result = await mediator.Send(command);

            if (application == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(application);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete Application")]
        public async Task<IActionResult> DeleteApplication(long ApplicationId)
        {

            var command = await mediator.Send(new DeleteApplicationDataCommand() { ApplicationId = ApplicationId });

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

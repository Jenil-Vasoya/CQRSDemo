using CQRSDemo.Commands.Story_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Queries.Story_Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {

        private readonly IMediator mediator;

        public StoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All Story")]
        public async Task<IActionResult> AllStory()
        {

            var Story = await mediator.Send(new GetAllStoryQuery());

            if (Story == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(Story);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Get Story")]
        public async Task<IActionResult> GetStoryData(long StoryId)
        {
            var Story = await mediator.Send(new GetStoryDataQuery() { StoryId = StoryId });
            if (Story == null)
            {
                return NotFound();
            }
            return Ok(Story);
        }


      
        private Story AddDataModel(long? StoryId, string Status)
        {
            Story model = new Story();
            if (StoryId != null)
            {
                model.StoryId = (long)StoryId;
            }
            model.Status = Status;

            return model;
        }

        [HttpPut]
        [Route("Update Story")]
        public async Task<IActionResult> UpdateStory(long StoryId, string Status)
        {
            Story Story = AddDataModel(StoryId, Status);
            var command = new EditStoryDataCommand(Story);
            var result = await mediator.Send(command);

            if (Story == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(Story);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete Story")]
        public async Task<IActionResult> DeleteStory(long StoryId)
        {

            var command = await mediator.Send(new DeleteStoryDataCommand() { StoryId = StoryId });

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

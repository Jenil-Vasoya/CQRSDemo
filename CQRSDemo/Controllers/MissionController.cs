using CQRSDemo.Commands.Mission_Commands;
using CQRSDemo.Controllers.DTOS;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries.Mission_Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMediator mediator;

        public MissionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Mission Add/Edit")]
        public async Task<IActionResult> AddMission([FromForm] MissionAddModel dto)
        {
            var mission = await mediator.Send(new AddMissionDataCommand(dto));
            
            return Ok(dto);
        }

        [HttpGet]
        [Route("Mission Pagination/Search")]
        public async Task<IActionResult> FindMission([FromQuery] Pagination dto)
        {
            if (string.IsNullOrEmpty(dto.Search) && dto.Page == 0 && dto.PageSize == 0)
            {
                return BadRequest("Fill Value");
            }
            List<Mission> missions = await mediator.Send(dto.ToMissionQuery());
            if (missions == null || missions.Count == 0)
            {
                return NotFound();
            }
            try
            {
                return Ok(missions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Missions")]
        public async Task<IActionResult> GetAll()
        {

            var user = await mediator.Send(new GetAllMissionQuery());

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Get Mission")]
        public async Task<IActionResult> GetMissionData(long MissionId)
        {
            var mission = await mediator.Send(new GetMissionDataQuery() { MissionId = MissionId });
            if (mission == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(mission);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete Mission")]
        public async Task<IActionResult> DeleteMission(long MissionId)
        {

            var command = await mediator.Send(new DeleteMissionDataCommand() { MissionId = MissionId });



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

using CQRSDemo.Commands.Skill_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries.Skill_Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {

        private readonly IMediator mediator;

        public SkillController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("Skill Pagination/Search")]
        public async Task<IActionResult> FindSkill([FromQuery] Pagination dto)
        {
            if (string.IsNullOrEmpty(dto.Search) && dto.Page == 0 && dto.PageSize == 0)
            {
                return BadRequest("Fill Value");
            }
            List<Skill> skills = await mediator.Send(dto.ToSkillQuery());
            if (skills == null || skills.Count == 0)
            {
                return NotFound();
            }
            try
            {
                return Ok(skills);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("All Skill")]
        public async Task<IActionResult> AllSkill()
        {

            var skill = await mediator.Send(new GetAllSkillQuery());

            if (skill == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Get Skill")]
        public async Task<IActionResult> GetSkillData(long SkillId)
        {
            var skill = await mediator.Send(new GetSkillDataQuery() { SkillId = SkillId });
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }


        [HttpPost]
        [Route("Add Skill")]
        public async Task<IActionResult> AddSkill(string Title, bool? Status)
        {
            Skill skill = AddDataModel(null, Title, Status);
            var command = new AddSkillDataCommand(skill);
            var result = await mediator.Send(command);

            if (skill == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private Skill AddDataModel(int? SkillId, string Title, bool? Status)
        {
            Skill model = new Skill();
            if (SkillId != null)
            {
                model.SkillId = (int)SkillId;
            }
            model.SkillName = Title;
            model.Status = Status;

            return model;
        }

        [HttpPut]
        [Route("Update Skill")]
        public async Task<IActionResult> UpdateSkill(int SkillId, string Title, bool? Status)
        {
            Skill skill = AddDataModel(SkillId, Title, Status);
            var command = new EditSkillDataCommand(skill);
            var result = await mediator.Send(command);

            if (skill == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete Skill")]
        public async Task<IActionResult> DeleteSkill(long SkillId)
        {

            var command = await mediator.Send(new DeleteSkillDataCommand() { SkillId = SkillId });

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

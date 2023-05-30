using CQRSDemo.Commands.Theme_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries.Theme_Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ThemeController : ControllerBase
    {

        private readonly IMediator mediator;

        public ThemeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("Theme Pagination/Search")]
        public async Task<IActionResult> FindTheme([FromQuery] Pagination dto)
        {
            if (string.IsNullOrEmpty(dto.Search) && dto.Page == 0 && dto.PageSize == 0)
            {
                return BadRequest("Fill Value");
            }
            List<MissionTheme> themes = await mediator.Send(dto.ToThemeQuery());
            if (themes == null || themes.Count == 0)
            {
                return NotFound();
            }
            try
            {
                return Ok(themes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("All Theme")]
        public async Task<IActionResult> AllTheme()
        {

            var theme = await mediator.Send(new GetAllThemeQuery());

            if (theme == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(theme);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Get Theme")]
        public async Task<IActionResult> GetThemeData(long ThemeId)
        {
            var theme = await mediator.Send(new GetThemeDataQuery() { ThemeId = ThemeId });
            if (theme == null)
            {
                return NotFound();
            }
            return Ok(theme);
        }


        [HttpPost]
        [Route("Add Theme")]
        public async Task<IActionResult> AddTheme(string Title, bool? Status)
        {
            MissionTheme theme = AddDataModel(null, Title, Status);
            var command = new AddThemeDataCommand(theme);
            var result = await mediator.Send(command);

            if (theme == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(theme);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private MissionTheme AddDataModel(long? ThemeId, string Title, bool? Status)
        {
            MissionTheme model = new MissionTheme();
            if (ThemeId != null)
            {
                model.MissionThemeId = (long)ThemeId;
            }
            model.Titile = Title;
            model.Status = Status;

            return model;
        }

        [HttpPut]
        [Route("Update Theme")]
        public async Task<IActionResult> UpdateTheme(long ThemeId, string Title, bool? Status)
        {
            MissionTheme theme = AddDataModel(ThemeId, Title, Status);
            var command = new EditThemeDataCommand(theme);
            var result = await mediator.Send(command);

            if (theme == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(theme);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete Theme")]
        public async Task<IActionResult> DeleteTheme(long ThemeId)
        {

            var command = await mediator.Send(new DeleteThemeDataCommand() { ThemeId = ThemeId });

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

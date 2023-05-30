using CQRSDemo.Commands;
using CQRSDemo.Commands.Banner_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries.Banner_Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BannerController : Controller
    {

        private readonly IMediator mediator;

        public BannerController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        [Route("Banner Pagination/Search")]
        public async Task<IActionResult> FindBanner([FromQuery] Pagination dto)
        {
            if(string.IsNullOrEmpty(dto.Search) && dto.Page == 0 && dto.PageSize == 0)
            {
                return BadRequest("Fill Value");
            }
            List<Banner> banners = await mediator.Send(dto.ToBannerQuery());
            if(banners == null || banners.Count == 0)
            {
                return NotFound();
            }
            try
            {
                return Ok(banners);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Get Banner")]
        public async Task<IActionResult> GetBannerData(long BannerId)
        {
            var banner = await mediator.Send(new GetBannerDataQuery() { BannerId = BannerId });
            if (banner == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(banner);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Banners")]
        public async Task<IActionResult> GetAll()
        {

            var banner = await mediator.Send(new GetAllBannerQuery());

            if (banner == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(banner);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        
        [HttpPost]
        [Route("Add Banner")]
        public async Task<IActionResult> AddBanner(IFormFile? img, string Text, int ShortOrder)
        {
            Banner banner = AddDataModel(null, img, Text, ShortOrder);
            var command = new AddBannerDataCommand(banner);
            var result = await mediator.Send(command);
            
        

            if (banner == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(banner);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private Banner AddDataModel(long? BannerId, IFormFile? img, string Text, int ShortOrder)
        {
            Banner model = new Banner();
            if (BannerId != null)
            {
                model.BannerId = (long)BannerId;
            }

            model.Text = Text;
            model.SortOrder = ShortOrder;
            if (img != null)
            {
                model.Image = img.FileName;
            }
            model.BannerImg = img;

            return model;
        }


        [HttpPut]
        [Route("Update Banner")]
        public async Task<IActionResult> UpdateBanner(long BannerId, IFormFile? img, string Text, int ShortOrder)
        {
            Banner banner = AddDataModel(BannerId, img, Text, ShortOrder);
            var command = new EditBannerDataCommand(banner);
            var result = await mediator.Send(command);



            if (banner == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(banner);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete Banner")]
        public async Task<IActionResult> DeleteBanner(long BannerId)
        {

            var command = await mediator.Send(new DeleteBannerDataCommand() { BannerId = BannerId });
            


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

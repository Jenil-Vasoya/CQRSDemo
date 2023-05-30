using CQRSDemo.Commands;
using CQRSDemo.Commands.User_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries.User_Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        [Route("User Pagination/Search")]
        public async Task<IActionResult> FindUser([FromQuery] Pagination dto)
        {
            if (string.IsNullOrEmpty(dto.Search) && dto.Page == 0 && dto.PageSize == 0)
            {
                return BadRequest("Fill Value");
            }
            List<User> users = await mediator.Send(dto.ToUserQuery());
            if (users == null || users.Count == 0)
            {
                return NotFound();
            }
            try
            {
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Get User")]
        public async Task<IActionResult> GetUserData(long UserId)
        {
            var user = await mediator.Send(new GetUserDataQuery() { UserId = UserId });
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
        [Route("Users")]
        public async Task<IActionResult> GetAll()
        {

            var user = await mediator.Send(new GetAllUserQuery());

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
        
        [HttpPost]
        [Route("Add User")]
        public async Task<IActionResult> AddUser(IFormFile? img, string FirstName, string LastName, string Email, string Password, string? EmployeeId,string? Department, long CityId, long CountryId, bool Status, string Role, string? ProfileText)
        {
            UserAdd user = AddDataModel(null,img,FirstName, LastName, Email, Password, EmployeeId, Department, CityId, CountryId, Status, Role, ProfileText);
            var command = new AddUserDataCommand(user);
            var result = await mediator.Send(command);
            
        

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

        private UserAdd AddDataModel(long? UserId, IFormFile? img, string? FirstName, string? LastName, string Email, string Password, string? EmployeeId, string? Department, long? CityId, long? CountryId, bool? Status, string Role, string? ProfileText)
        {
            UserAdd model = new UserAdd();
            if(UserId != null)
            {
                model.UserId = UserId;
            }
            model.FirstName = FirstName;
            model.LastName = LastName;
            model.Email = Email;
            model.Password = Password;
            model.EmployeeId = EmployeeId;
            model.Department = Department;
            model.CityId = CityId;
            model.CountryId = CountryId;
            model.Status = Status;
            model.Role = Role;
            model.UserImg = img;
            model.ProfileText = ProfileText;
            return model;
        }
        

        [HttpPut]
        [Route("Update User")]
        public async Task<IActionResult> UpdateUser(long UserId, IFormFile? img, string FirstName, string LastName, string Email, string Password, string? EmployeeId, string? Department, long CityId, long CountryId, bool Status, string Role, string? ProfileText)
        {
            UserAdd user = AddDataModel(UserId, img, FirstName, LastName, Email, Password, EmployeeId, Department, CityId, CountryId, Status, Role, ProfileText);
            var command = new EditUserDataCommand(user);
            var result = await mediator.Send(command);



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

        [HttpDelete]
        [Route("Delete User")]
        public async Task<IActionResult> DeleteUser(long UserId)
        {

            var command = await mediator.Send(new DeleteUserDataCommand() { UserId = UserId });
            


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

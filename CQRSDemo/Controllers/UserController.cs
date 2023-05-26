using CQRSDemo.Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries;
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
        [Route("All")]
        public IActionResult GetAll()
        {

            var user = mediator.Send(new GetAllUserQuery());

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
        public IActionResult AddUser(string FirstName, string LastName, string Email, string Password, string? EmployeeId,string? Department, long CityId, long CountryId, bool Status, string Role, string? ProfileText)
        {
            UserAdd user = AddDataModel(FirstName, LastName, Email, Password, EmployeeId, Department, CityId, CountryId, Status, Role, ProfileText);
            var command = new AddUserDataCommand(user);
            var result = mediator.Send(command);
            
        

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

        private UserAdd AddDataModel(string? FirstName, string? LastName, string Email, string Password, string? EmployeeId, string? Department, long? CityId, long? CountryId, bool? Status, string Role, string? ProfileText)
        {
            UserAdd model = new UserAdd();
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
            model.ProfileText = ProfileText;
            return model;
        }
    }
}

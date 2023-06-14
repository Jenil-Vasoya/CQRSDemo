using CQRSDemo.Auth;
using CQRSDemo.Commands;
using CQRSDemo.Commands.User_Commands;
using CQRSDemo.Controllers.DTOS;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Queries.User_Queries;
using CQRSDemo.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CQRSDemo.Repository.DTOs;
using DotNetCore.CAP;
using System.Net;
using System.Web;
using System.Net.Sockets;

namespace CQRSDemo.Controllers
{
    [MyTrackingActionFilter]
    [ApiController]
    [ServiceFilter(typeof(CustomExceptionFilter))]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator mediator;
        private readonly ICapPublisher _capPublisher;

        public UserController(IConfiguration config,IMediator mediator, ICapPublisher capPublisher)
        {
            _configuration = config;
            this.mediator = mediator;
            _capPublisher = capPublisher;
        }

        
        [HttpPost]
        [Route("user-login")]
        public async Task<IActionResult> LogIn(string email, string password)
        {

            //HttpContext context = HttpContext.Current;

            //// Get the client's IP address from the current request
            //string ipAddress = context.Request.UserHostAddress;

            string ipAddress1 = string.Empty;

            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress address in hostEntry.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress1 = address.ToString();
                    break;
                }
            }
            Console.WriteLine($"User IP Address: {ipAddress1}");


            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    var ip1 = ip.ToString();
                    Console.WriteLine("My IP Address is :" + ip1);
                }
            }
            string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            Console.WriteLine($"User IP Address: {ipAddress}");

            //var hostName = Dns.GetHostName(); // Retrive the Name of HOST
            //Console.WriteLine(hostName);

            //string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            //Console.WriteLine("My IP Address is :" + myIP);
            
            //string myIP1 = Dns.GetHostByName(hostName).AddressList[1].ToString();
            //Console.WriteLine("My IP Address is :" + myIP1);



            var user = await mediator.Send(new LogInUserQuery() { email = email, password = password });

            JwtTokenHelper jwt = new JwtTokenHelper();
            Jwt jwt1 = new Jwt();
            jwt1.key = _configuration["Jwt:Key"];
            jwt1.issuer = _configuration["Jwt:Issuer"];
            jwt1.audience = _configuration["Jwt:Audience"];
            var token = jwt.GenerateToken(user,jwt1);
            return Ok(token);
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

        [Authorize]
        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> GetAll([FromQuery] Paging dto)
        {

            var user = await mediator.Send(new GetAllUserQuery(dto));

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
            //var result = await mediator.Send(command);
            await mediator.Publish(command);
        

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                return Ok("User Registration Done");
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

        [HttpGet]
        [Route("division")]
        public async Task<float> Demo([FromQuery] Division dto)
        {
            //_capPublisher.Publish("helloWorld", "CodeOpinion");
            float result = await dto.dividend.CustomDivideAsync(dto.divisor);
            return result;
        }

        [HttpGet]
        [Route("~/send")]
        public IActionResult SendMessage(long id)
        {
            _capPublisher.Publish("test.show.time", id);
            
            return Ok();
        }

        

        //[Route("~/send/delay")]
        //public IActionResult SendDelayMessage([FromServices] ICapPublisher capBus)
        //{
        //    capBus.PublishDelay(TimeSpan.FromSeconds(100), "test.show.time", DateTime.Now);

        //    return Ok();
        //}

        //[HttpGet]
        //[Route("pagination")]
        //public async Task<IEnumerable<User>> Demo([FromQuery] Pagination dto)
        //{
        //    List<User> user = await mediator.Send(new GetAllUserQuery());

        //    var result = user.Pagination(dto.Page, dto.PageSize);
        //    return result;
        //}


    }
}

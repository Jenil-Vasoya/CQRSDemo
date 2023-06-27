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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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

            // Getting Ip address of local machine...
            // First get the host name of local machine.
            //string strHostName = Dns.GetHostName();
            //Console.WriteLine("Local Machine's Host Name: " + strHostName);

            //// Then using host name, get the IP address list..
            //IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            //IPAddress[] addr = ipEntry.AddressList;

            //for (int i = 0; i < addr.Length; i++)
            //{
            //    Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
            //}

            //Console.ReadLine();
            ////HttpContext context = HttpContext.Current;

            ////// Get the client's IP address from the current request
            ////string ipAddress = context.Request.UserHostAddress;

            //string ipAddress1 = string.Empty;

            //IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            //foreach (IPAddress address in hostEntry.AddressList)
            //{
            //    if (address.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        ipAddress1 = address.ToString();
            //        break;
            //    }
            //}
            //Console.WriteLine($"User IP Address: {ipAddress1}");


            //var host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (var ip in host.AddressList)
            //{
            //    if (ip.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        var ip1 = ip.ToString();
            //        Console.WriteLine("My IP Address is :" + ip1);
            //    }
            //}

            //var hostName = Dns.GetHostName(); // Retrive the Name of HOST
            //Console.WriteLine(hostName);

            //string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            //Console.WriteLine("My IP Address is :" + myIP);

            //string myIP1 = Dns.GetHostByName(hostName).AddressList[1].ToString();
            //Console.WriteLine("My IP Address is :" + myIP1);

            try
            {
                string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                Console.WriteLine($"User IP Address: {ipAddress}");

                var user = await mediator.Send(new LogInUserQuery() { email = email, password = password });

                JwtTokenHelper jwt = new JwtTokenHelper();
                Jwt jwt1 = new Jwt();
                jwt1.key = _configuration["Jwt:Key"];
                jwt1.issuer = _configuration["Jwt:Issuer"];
                jwt1.audience = _configuration["Jwt:Audience"];
                var token = jwt.GenerateToken(user, jwt1);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }

        public class Node
        {
            public string key { get; set; }
            public string name { get; set; }
            public string title { get; set; }
            public string comments { get; set; }
            public string parent { get; set; }
        }

        public class TreeModel
        {
            public string @class { get; set; }
            public List<Node> nodeDataArray { get; set; }
        }


        public static string OrgChartConverter()
        {
              string json = @"
            [
                {
                    ""levelField"": 1,
                    ""entityField"": {
                        ""idField"": ""a18e3137-6a0e-4c19-871b-0564ebbe1cca"",
                        ""typeField"": ""COMPANY"",
                        ""nameField"": ""CASELLA FAMILY BRANDS (EUROPE) PTY LIMITED"",
                        ""nameInEnglishField"": ""CASELLA FAMILY BRANDS (EUROPE) PTY LIMITED"",
                        ""hasParentField"": false
                    },
                    ""edgesField"": [
                        {
                            ""nodeIdField"": ""3134d931-22ef-48c1-af5a-18529d281850"",
                            ""typeField"": ""SHAREHOLDER"",
                            ""percentageField"": 80
                        },
                        {
                            ""nodeIdField"": ""c6481aae-ed99-4d1c-b074-0348383f679e"",
                            ""typeField"": ""SHAREHOLDER"",
                            ""percentageField"": 20
                        },
                        {
                            ""nodeIdField"": ""a6bce2ca-614e-4034-b503-58d1e923e000"",
                            ""typeField"": ""REPRESENTATIVE"",
                            ""roleField"": ""Director""
                        },
                        {
                            ""nodeIdField"": ""a6bce2ca-614e-4034-b503-58d1e923e000"",
                            ""typeField"": ""REPRESENTATIVE"",
                            ""roleField"": ""Secretary""
                        }
                    ]
                },
                {
                    ""levelField"": 2,
                    ""entityField"": {
                        ""idField"": ""a6bce2ca-614e-4034-b503-58d1e923e000"",
                        ""typeField"": ""PERSON"",
                        ""nameField"": ""GIOVANNI MARCELLO CASELLA"",
                        ""nameInEnglishField"": ""GIOVANNI MARCELLO CASELLA"",
                        ""hasParentField"": false
                    },
                    ""edgesField"": []
                },
                {
                    ""levelField"": 2,
                    ""entityField"": {
                        ""idField"": ""3134d931-22ef-48c1-af5a-18529d281850"",
                        ""typeField"": ""COMPANY"",
                        ""nameField"": ""JMCTT PTY LTD"",
                        ""nameInEnglishField"": ""JMCTT PTY LTD"",
                        ""hasParentField"": true
                    },
                    ""edgesField"": [
                        {
                            ""nodeIdField"": ""0cf62787-5ffd-4179-9f43-979e8fa15f2b"",
                            ""typeField"": ""SHAREHOLDER"",
                            ""percentageField"": 100
                        },
                        {
                            ""nodeIdField"": ""658cb808-22af-44c4-9fe1-bbca571f6ab8"",
                            ""typeField"": ""REPRESENTATIVE"",
                            ""roleField"": ""Director""
                        },
                        {
                            ""nodeIdField"": ""658cb808-22af-44c4-9fe1-bbca571f6ab8"",
                            ""typeField"": ""REPRESENTATIVE"",
                            ""roleField"": ""Secretary""
                        }
                    ]
                },
				{
                    ""levelField"": 2,
                    ""entityField"": {
                        ""idField"": ""c6481aae-ed99-4d1c-b074-0348383f679e"",
                        ""typeField"": ""COMPANY"",
                        ""nameField"": ""JCTT PTY LTD"",
                        ""nameInEnglishField"": ""JCTT PTY LTD"",
                        ""hasParentField"": true
                    },
                    ""edgesField"": [
                        {
                            ""nodeIdField"": ""18e20adf-64ee-49ba-81b6-6fa69db21d8b"",
                            ""typeField"": ""SHAREHOLDER"",
                            ""percentageField"": 100
                        },
                        {
                            ""nodeIdField"": ""2639832f-ff96-4986-aa37-7eeb0279f0e7"",
                            ""typeField"": ""REPRESENTATIVE"",
                            ""roleField"": ""Director""
                        },
                        {
                            ""nodeIdField"": ""2639832f-ff96-4986-aa37-7eeb0279f0e7"",
                            ""typeField"": ""REPRESENTATIVE"",
                            ""roleField"": ""Secretary""
                        }
                    ]
                }
            
        ]
    ";

            JArray jsonArray = JArray.Parse(json);
            TreeModel treeModel = new TreeModel
            {
                @class = "go.TreeModel",
                nodeDataArray = new List<Node>()
            };

            Dictionary<string, Node> nodeDictionary = new Dictionary<string, Node>();

            foreach (JObject item in jsonArray)
            {
                string entityId = item["entityField"]["idField"].ToString();
                string entityType = item["entityField"]["typeField"].ToString();
                string entityName = item["entityField"]["nameField"].ToString();

                Node node;
                if (nodeDictionary.ContainsKey(entityId))
                {
                    node = nodeDictionary[entityId];
                }
                else
                {
                    node = new Node();
                    node.title = entityType;
                    node.key = entityId;
                    node.name = entityName;
                    nodeDictionary.Add(entityId, node);
                }

                JArray edgeField = JArray.Parse(item["edgesField"].ToString());

                foreach (var ef in edgeField)
                {
                    string nodeIdField = ef["nodeIdField"].ToString();
                    string percentageField = ef["percentageField"]?.ToString() ?? "0";
                    entityType = ef["typeField"]?.ToString() ?? "";
                    string Role = ef["roleField"]?.ToString() ?? "";

                    if (nodeIdField != entityId && nodeDictionary.ContainsKey(nodeIdField))
                    {
                        Node childNode = nodeDictionary[nodeIdField];
                        childNode.parent = entityId;
                        if (percentageField != "0")
                        {
                            childNode.comments = "Percentage: " + percentageField;
                        }
                        if (Role != "")
                        {
                            childNode.comments = "Role: " + Role;
                        }
                    }
                }

                treeModel.nodeDataArray.Add(node);
            }

            string treeModelJson = JsonConvert.SerializeObject(treeModel, Formatting.Indented);
            return treeModelJson;
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

        [Authorize (Policy = "DeletePolicy")]
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

        [HttpGet]
        [Route("Data Json")]
        public IActionResult JsonDemo()
        {
            var data = OrgChartConverter();
            return Ok(data);
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

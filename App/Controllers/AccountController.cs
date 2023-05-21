using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.DTOs.Account;
using Services.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.SignUpAsync(model));
        }


        //[HttpPost]
        //[Route("Login")]
        //public IActionResult SignIn([FromBody] LoginDto model)
        //{
        //    var response = new Dictionary<string, string>();
        //    if (!(request.Username == "admin" && request.Password == "Admin@123"))
        //    {
        //        response.Add("Error", "Invalid username or password");
        //        return BadRequest(response);
        //    }

        //    var roles = new string[] { "Role1", "Role2" };
        //    var token = GenerateJwtToken(request.Username, roles.ToList());
        //    return Ok(token);
          
        //}

       
    }   
}


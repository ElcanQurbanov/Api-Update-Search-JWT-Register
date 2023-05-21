using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.DTOs.Account;
using Services.Helpers.Responses;
using Services.Services.Interfaces;


namespace Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AccountService(UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IMapper mapper,
                              IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _config = config;
        }

        public async Task<LoginResponse> SignInAsync(LoginDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterResponse> SignUpAsync(RegisterDto model)
        {
            AppUser user = _mapper.Map<AppUser>(model);

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return new RegisterResponse { StatusMessage = "Failed", Errors = result.Errors.Select(d => d.Description).ToList() };

            return new RegisterResponse { Errors = null, StatusMessage = "Success" };
        }

        //private string GenerateJwtToken(string username, List<string> roles)
        //{
        //    var claims = new List<Claim>
        //{
        //    new Claim(JwtRegisteredClaimNames.Sub, username),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    new Claim(ClaimTypes.NameIdentifier, username)
        //};

        //    roles.ForEach(role =>
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    });

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var expires = DateTime.Now.AddDays(Convert.ToDouble(_config["Jwt:Key"]));

        //    var token = new JwtSecurityToken(
        //        _configuration["JwtIssuer"],
        //        _configuration["JwtIssuer"],
        //        claims,
        //        expires: expires,
        //        signingCredentials: creds
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}

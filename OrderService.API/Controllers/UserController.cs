using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrderService.API.Models;
using OrderService.Application.Models;
using OrderServise.Domain.Common;
using OrderServise.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
        }
        [Authorize(Roles =UserRole.ADMIN)]
        //[Authorize(Policy ="IsAdmin")]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserDto userDto)
        {
            var newUser=_mapper.Map<AppUser>(userDto);
            var result =await _userManager.CreateAsync(newUser, userDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(err => err.Description));
            }

            return NoContent();

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto )
        {
            var user=await _userManager.FindByNameAsync(loginDto.UserName);
            if (user is null)
            {
                return BadRequest("ورود ناموفق");
            }
            var LoginResult =await _signInManager.PasswordSignInAsync(user, loginDto.PassWord,false,false);
            if (LoginResult.Succeeded)
            {
                var token =await CreateTokenRole(user, _config);
                return Ok(token);
            }
            return BadRequest("ورود ناموفق");
        }
       
        [HttpPut]
        public async Task<IActionResult> Test()
        {
            return Ok();

        }
        private async Task<LoginResponseDto> CreateTokenRole(AppUser user,IConfiguration _config)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var test = _config["SecurityKey"];
            var roles = await _userManager.GetRolesAsync(user);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim("fullName",user.FirstName +" "+ user.LastName),
       
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var expirationDate = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(issuer: null, audience: null, claims, null, expirationDate, cred);

            return new LoginResponseDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expirationDate
            }
           ;

        }

    }
}

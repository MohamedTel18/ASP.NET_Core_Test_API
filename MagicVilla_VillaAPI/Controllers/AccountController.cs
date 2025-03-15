using MagicVilla_VillaAPI.models;
using MagicVilla_VillaAPI.models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<AppUser> userManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }



        [HttpPost]
        public async Task<IActionResult> Register(UserDTO user)
        {
            if(ModelState.IsValid)
            {
                var newUser = new AppUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };

                var result = await _userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if(ModelState.IsValid)
            {
                AppUser? user = await _userManager.FindByNameAsync(login.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
                {
                    var claimes=new List<Claim>();
                    claimes.Add(new Claim("tokenNo", "75"));
                    claimes.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claimes.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claimes.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        claimes.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                    var sc= new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken
                    (
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: claimes,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: sc
                    );

                    var _token = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                    };
                    return Ok(_token);
                }
                ModelState.AddModelError("", "Username/Password invalid");
            }

            return BadRequest(ModelState);
        }
    }
}
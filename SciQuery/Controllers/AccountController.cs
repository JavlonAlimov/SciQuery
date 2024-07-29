using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SciQuery.Domain.UserModels;
using SciQuery.Domain.UserModels.AppRoles;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SciQuery.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(
    IConfiguration configuration,
    UserManager<User> userManager) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    private readonly UserManager<User> _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

    [HttpPost("register")]
    public async Task<ActionResult> Register(AddOrUpdateUserModel userModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var name = await _userManager.FindByNameAsync(userModel.UserName);

        if (name is not null)
        {
            ModelState.AddModelError("", "User already taken");
            return BadRequest(ModelState);
        }

        var user = new User()
        {
            UserName = userModel.UserName,
            Email = userModel.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
        };

        var result=  await _userManager.CreateAsync(user,userModel.Password);
        var roleResult = await _userManager.AddToRoleAsync(user, AppRoles.User);

        if (roleResult.Succeeded && result.Succeeded)
        {
            var token = GenerateToken(user,userModel.UserName);

            return Ok(new { token });
        }
        return BadRequest("Something is wrong to create user");
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginViewModel login)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByNameAsync(login.UserName);
        
        if (user != null)
        {
            var result = await _userManager.CheckPasswordAsync(user, login.Password);

            if (result)
            {
                var token = await GenerateToken(user, login.UserName);
                return Ok(new { token });
            }
        }
        
        ModelState.AddModelError("", "Invalid login or username");
        return BadRequest(ModelState);
    }

    [HttpGet]
    [Authorize(Policy = "RequireAdminstratorRole")]
    public ActionResult Get()
    {
        return Ok("77");
    }
    private async Task<string?> GenerateToken(User user, string userName)
    {
        var secret = configuration["JwtConfig:SecretKey"];
        var audience = configuration["JwtConfig:ValidAudiences"];
        var issuer = configuration["JwtConfig:ValidIssuer"];
        
        if (secret is null ||  audience is null || issuer is null)
        {
            throw new ApplicationException("Jwt is not set in the configuration");
        }
        
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var tokenHandler = new JwtSecurityTokenHandler();
        var userRoles = await _userManager.GetRolesAsync(user);
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name,userName)
        };
        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
        };
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);
        return token;
    }
}

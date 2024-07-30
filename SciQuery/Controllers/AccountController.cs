using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SciQuery.Domain.UserModels;
using SciQuery.Domain.UserModels.AppRoles;
using SciQuery.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SciQuery.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(
    IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));

    [HttpPost("register")]
    public async Task<ActionResult> Register(AddOrUpdateUserModel userModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var token = await _accountService.RegisterAsync(userModel);
        return Ok(token);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginViewModel login)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var token = _accountService.LoginAsync(login);
        return Ok(token);
    }
}

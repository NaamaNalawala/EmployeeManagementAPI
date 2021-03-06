using EmployeeManagementAPI.BAL;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;

        public AuthController(ILogger<AuthController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Dictionary<string, string> result = _userService.IsValidUserCredentials(request);
            if (result.GetValueOrDefault("isValid") == "false")
            {
                return Unauthorized();
            }

            var claims = new[]
            {
            new Claim(ClaimTypes.Name,request.UserName),
            new Claim(ClaimTypes.Role, result.GetValueOrDefault("role")),
            new Claim(ClaimTypes.NameIdentifier, result.GetValueOrDefault("id"))
        };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{request.UserName}] logged in the system.");
            return Ok(new LoginResult
            {
                UserName = request.UserName,
                Role = result.GetValueOrDefault("role"),
                UserId = result.GetValueOrDefault("id"),
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
       
    }
}

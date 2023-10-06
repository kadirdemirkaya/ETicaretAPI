using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.DTOs.Authenticate;
using ETicaretAPI.application.DTOs.Mail;
using ETicaretAPI.application.Mediators.Commands.Authenticate.Login;
using ETicaretAPI.application.Mediators.Commands.Authenticate.Register;
using ETicaretAPI.application.Mediators.Commands.Authenticate.TwoFactorAuthentication;
using ETicaretAPI.application.Mediators.Queries.Authenticate.GetRoleUser;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly List<string> _tokens;
        private readonly IEmailService _emailService;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticateController(IMediator mediator, List<string> tokens, IEmailService emailService, UserManager<AppUser> userManager)
        {
            this.mediator = mediator;
            _tokens = tokens;
            _emailService = emailService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            LoginCommandResponse response = await mediator.Send(loginCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterCommandRequest registerCommandRequest)
        {
            RegisterCommandResponse response = await mediator.Send(registerCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("LogOut")]
        public async Task<IActionResult> LogOut([FromHeader] string token)
        {
            _tokens.Add(token);
            return Ok(new
            {
                message = "LogOut Process Succesfully",
                isSuccess = true
            });
        }

        [HttpGet]
        [Route("IsValidToken")]
        public IActionResult IsValidToken([FromHeader] string token)
        {
            foreach (var tkn in _tokens)
            {
                if (tkn.Contains(token))
                {
                    return Ok(new
                    {
                        message = "Token is NOT VALID",
                        isSuccess = false
                    });
                }
            }
            return Ok(new
            {
                message = "Token is VALID",
                isSuccess = true
            });
        }

        [HttpGet]
        [Route("ConfirmedEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return Ok("E posta doğrulandı");
                }
            }
            return BadRequest("E posta doğrulanırken bir hata oluştu");
        }

        [HttpPost]
        [Route("TwoFactorAuthentication")]
        public async Task<IActionResult> TwoFactorAuthentication(TwoFactorAuthenticationRequest twoFactorAuthenticationRequest)
        {
            TwoFactorAuthenticationResponse response = await mediator.Send(twoFactorAuthenticationRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromHeader] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email! }, "Forgot Password LINK : ", forgotPasswordLink!);
                _emailService.SendEmail(message);

                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = await _emailService.ResetPassword(token, email);
            return Ok(model);
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            bool result = await _emailService.ResetPassword(resetPassword);
            return Ok(result);
        }


        [Authorize]
        [Route("GetRoleUser")]
        [HttpGet]
        public async Task<IActionResult> GetRoleUser([FromQuery] GetRoleUserQueryRequest roleUserQueryRequest)
        {
            GetRoleUserQueryResponse response = await mediator.Send(roleUserQueryRequest);
            return Ok(response);
        }
    }
}
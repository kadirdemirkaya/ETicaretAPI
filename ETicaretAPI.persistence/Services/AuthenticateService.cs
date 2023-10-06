using AutoMapper;
using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.Abstractions.Token;
using ETicaretAPI.application.DTOs.Authenticate;
using ETicaretAPI.application.DTOs.Mail;
using ETicaretAPI.application.UnitOfWorks;
using ETicaretAPI.domain.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace ETicaretAPI.persistence.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailService emailService;
        private readonly IUrlHelperFactory urlHelperFactory;
        private readonly IUnitOfWork unitOfWork;
        private readonly RoleManager<AppRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        public AuthenticateService(ITokenService tokenService, UserManager<AppUser> userManager, IMapper mapper, IEmailService emailService, IUrlHelperFactory urlHelperFactory, IUnitOfWork unitOfWork, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _mapper = mapper;
            this.emailService = emailService;
            this.urlHelperFactory = urlHelperFactory;
            this.unitOfWork = unitOfWork;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public async Task<(string token, bool isSuccess, bool? TFA)> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user.TwoFactorEnabled)
            {
                await signInManager.SignOutAsync();
                await signInManager.PasswordSignInAsync(user, loginDto.Password, false, true);
                var tokenMail = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

                var message = new Message(new string[] { user.Email! }, "OTP Confrimation", tokenMail);
                emailService.SendEmail(message);

                return (user.Email, true, true);
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password) && await _userManager.IsEmailConfirmedAsync(user))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                #region 
                //Notification notification = new() { Message = "Login process Success", MessageType = "Personal", Username = user.Email };
                //await notificationWriteRepository.AddAsync(notification);
                //await notificationWriteRepository.SaveChangesAsync();
                #endregion

                var token = _tokenService.GetToken(authClaims);
                return (new JwtSecurityTokenHandler().WriteToken(token), true, false);
            }
            return ("NO AUTHENTICATE", false, false);
        }

        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {
            var user = await _userManager.FindByEmailAsync(registerDto.Email);
            if (user is not null)
                return false;
            user = _mapper.Map<AppUser>(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!await roleManager.RoleExistsAsync("User"))
            {
                AppRole userRole = new() { Name = Statics.StaticsProperties.RoleNames.User };
                IdentityResult IResult = await roleManager.CreateAsync(userRole);
            }
            await _userManager.AddToRoleAsync(user, Statics.StaticsProperties.RoleNames.User);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string confirmationLink2 = "https://localhost:7107/api/Authentication/ConfirmedEmail?token=" + token + "&email=" + registerDto.Email;

                string emailBody = $"Hello, click on the link below to verify your email address.: <a href='{confirmationLink2}'>verification link</a>";

                var message = new Message(new string[] { user.Email! }, "Confirmation email link", emailBody);

                emailService.SendEmail(message);

                #region !!!
                await emailService.ConfirmEmailAsync(token, registerDto.Email);
                #endregion

                return true;
            }
            return false;
        }

        public async Task<(string token, bool isSuccess)> LoginWithTFA(string code, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var signIn = await signInManager.TwoFactorSignInAsync("Email", code, false, false);
            if (signIn.Succeeded)
            {
                if (user is not null)
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };
                    var token = _tokenService.GetToken(authClaims);
                    return (new JwtSecurityTokenHandler().WriteToken(token), true);
                }
            }
            return ("", false);
        }

        public async Task<List<string>> GetRolesForUser(Guid UserId)
        {
            AppUser user = await _userManager.FindByIdAsync(UserId.ToString());
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
    }
}

using ETicaretAPI.application.DTOs.Authenticate;
using ETicaretAPI.application.DTOs.Mail;
using ETicaretAPI.domain.Entites.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.application.Abstractions.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);

        Task<bool> ConfirmEmailAsync(string token, string email);

        Task<bool> LoginWithTFA(string code);

        Task<ResetPassword> ResetPassword(string token,string email);

        Task<bool> ResetPassword(ResetPassword resetPassword);
    }
}

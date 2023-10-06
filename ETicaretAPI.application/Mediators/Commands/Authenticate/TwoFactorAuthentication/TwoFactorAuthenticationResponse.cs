namespace ETicaretAPI.application.Mediators.Commands.Authenticate.TwoFactorAuthentication
{
    public class TwoFactorAuthenticationResponse
    {
        public string token { get; set; }
        public bool isSuccess { get; set; }
    }
}

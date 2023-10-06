using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.application.Mediators.Commands.Authenticate.Login
{
    public class LoginCommandResponse
    {
        public string token { get; set; }
        public bool isSuccess { get; set; }

        public bool? TFA { get; set; }
    }
}

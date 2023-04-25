using ETrade.Application.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Commands.AppUserCommands.LoginUser
{
	public class LoginUserCommandResponse
	{
        public TokenDTO Token { get; set; }
        public string Message { get; set; }
    }
}

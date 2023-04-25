using ETrade.Application.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Abstractions.Token
{
	public interface ITokenHandler
	{
		TokenDTO CreateAccessToken(int minute);
	}
}

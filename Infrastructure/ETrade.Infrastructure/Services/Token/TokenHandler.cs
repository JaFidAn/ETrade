using ETrade.Application.Abstractions.Token;
using ETrade.Application.DTOs.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Infrastructure.Services.Token
{
	public class TokenHandler : ITokenHandler
	{
		private readonly IConfiguration _configuration;

		public TokenHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public TokenDTO CreateAccessToken(int minute)
		{
			TokenDTO token = new TokenDTO();

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
			SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			token.Expiration = DateTime.UtcNow.AddMinutes(minute);
			JwtSecurityToken securityToken = new JwtSecurityToken(
				audience: _configuration["Token:Audience"],
				issuer: _configuration["Token:Issuer"],
				expires: token.Expiration,
				notBefore: DateTime.UtcNow,
				signingCredentials: signingCredentials
				);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			token.AccessToken =  tokenHandler.WriteToken(securityToken);

			return token;
		}
	}
}

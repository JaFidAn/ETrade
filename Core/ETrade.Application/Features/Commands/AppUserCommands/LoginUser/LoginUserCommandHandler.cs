using ETrade.Application.Abstractions.Token;
using ETrade.Application.DTOs.Token;
using ETrade.Application.Exceptions;
using ETrade.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Commands.AppUserCommands.LoginUser
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenHandler _tokenHandler;

		public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenHandler = tokenHandler;
		}

		public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
		{
			AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
			if (user == null)
			{
				user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
			}
			if (user == null)
			{
				throw new NotFountUserException();
			}

			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
			if (result.Succeeded)
			{
				// here we have to declare Authorization
				TokenDTO token = _tokenHandler.CreateAccessToken(10);
				return new LoginUserCommandResponse()
				{
					Token = token,
					Message = "Success"
				};
			}
			else
			{
				return new LoginUserCommandResponse()
				{
					Token = null,
					Message = "Invalid Username or Password"
				};
			}
		}
	}
}

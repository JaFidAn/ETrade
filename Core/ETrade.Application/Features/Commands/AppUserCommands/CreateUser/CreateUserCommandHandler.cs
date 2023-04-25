using ETrade.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Commands.AppUserCommands.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;

		public CreateUserCommandHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
		{
			IdentityResult result = await _userManager.CreateAsync(new AppUser()
			{
				Id = Guid.NewGuid().ToString(),
				FullName = request.FullName,
				UserName = request.Username,
				Email = request.Email
			}, request.Password);

			CreateUserCommandResponse response = new CreateUserCommandResponse() { Succeded = result.Succeeded };
			if (result.Succeeded)
			{
				response.Message = "User has created Successfully.";
			}
			else
			{
                foreach (var error in result.Errors)
                {
					response.Message += $"{error.Code} - {error.Description}";
                }
            }
			return response;
		}
	}
}

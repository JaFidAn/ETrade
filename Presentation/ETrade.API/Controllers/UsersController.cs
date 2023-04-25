using ETrade.Application.Features.Commands.AppUserCommands.CreateUser;
using ETrade.Application.Features.Commands.AppUserCommands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> CreateUser([FromBody]CreateUserCommandRequest createUserCommandRequest)
		{
			CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
			return Ok(response);
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> LoginUser([FromBody] LoginUserCommandRequest loginUserCommandRequest)
		{
			LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
			return Ok(response);
		}
	}
}

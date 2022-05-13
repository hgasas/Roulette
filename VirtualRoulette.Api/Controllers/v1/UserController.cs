using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualRoulette.Application.Settings;
using VirtualRoulette.Contracts.v1;
using VirtualRoulette.Contracts.v1.User.Requests.Commands;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Api.Controllers.v1;

public class UserController : Controller
{
    private readonly IMediator _mediator;
    private readonly JackpotSettings _jackpotSettings;

    public UserController(IMediator mediator, JackpotSettings jackpotSettings)
    {
        _mediator = mediator;
        _jackpotSettings = jackpotSettings;
    }

    [HttpPost(ApiRoutes.User.Login)]
    [ProducesResponseType(200, Type = typeof(SignInResponse))]
    [ProducesResponseType(400)] //TODO: Add more specific model
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
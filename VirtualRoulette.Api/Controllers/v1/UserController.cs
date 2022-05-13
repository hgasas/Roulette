using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1;
using VirtualRoulette.Contracts.v1.User.Requests.Commands;
using VirtualRoulette.Contracts.v1.User.Requests.Queries;
using VirtualRoulette.Contracts.v1.User.Responses;
using VirtualRoulette.Infrastructure;

namespace VirtualRoulette.Api.Controllers.v1;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserController : Controller
{
    private readonly MediatorWrapper _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = new MediatorWrapper(mediator);
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.User.Login)]
    [ProducesResponseType(200, Type = typeof(Response<SignInResponse>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Response<SignInResponse>>> SignIn([FromBody] SignInCommand command)
    {
        return (await _mediator.Send(command)).MatchActionResult();
    }
    
    [HttpGet(ApiRoutes.User.Balance)]
    [ProducesResponseType(200, Type = typeof(Response<GetUserBalanceResponse>))]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Response<GetUserBalanceResponse>>> GetUserBalance([FromQuery] GetUserBalanceQuery query)
    {
        return (await _mediator.Send(query)).MatchActionResult();
    }
    
    [HttpGet(ApiRoutes.User.GameHistory)]
    [ProducesResponseType(200, Type = typeof(Response<GetUserGameHistoryResponse>))]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Response<GetUserGameHistoryResponse>>> GetUserGameHistory(
        [FromQuery] GetUserGameHistoryQuery query)
    {
        return (await _mediator.Send(query)).MatchActionResult();
    }
    
    [HttpPost(ApiRoutes.User.Bet)]
    [ProducesResponseType(200, Type = typeof(Response<MakeBetResponse>))]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Response<MakeBetResponse>>> Bet([FromBody] MakeBetCommand command)
    {
        return (await _mediator.Send(command)).MatchActionResult();
    }
}
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1;
using VirtualRoulette.Contracts.v1.Jackpot.Requests.Queries;
using VirtualRoulette.Contracts.v1.Jackpot.Responses;
using VirtualRoulette.Infrastructure;

namespace VirtualRoulette.Api.Controllers.v1;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class JackpotController : Controller
{
    private readonly MediatorWrapper _mediator;

    public JackpotController(IMediator mediator)
    {
        _mediator = new MediatorWrapper(mediator);
    }

    [HttpGet(ApiRoutes.Jackpot.Root)]
    [ProducesResponseType(200, Type = typeof(Response<GetCurrentJackpotResponse>))]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Response<GetCurrentJackpotResponse>>> GetCurrentJackpot()
    {
        return (await _mediator.Send(new GetCurrentJackpotQuery())).MatchActionResult();
    }
}
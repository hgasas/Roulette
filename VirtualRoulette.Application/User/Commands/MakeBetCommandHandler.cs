using MediatR;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts;
using VirtualRoulette.Contracts.v1.User.Requests.Commands;
using VirtualRoulette.Contracts.v1.User.Responses;
using VirtualRoulette.Domain.Entities;
using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Application.User.Commands;

public class MakeBetCommandHandler : IRequestHandler<MakeBetCommand, Response<MakeBetResponse>>
{
    private readonly IBetRepository _betRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBetCheckingService _betCheckingService;
    private readonly IIdGenerationService _idGenerationService;
    private readonly INumberGenerationService _numberGenerationService;
    private readonly IDateTimeService _dateTimeService;

    public MakeBetCommandHandler(
        IBetRepository betRepository,
        IUserRepository userRepository,
        IBetCheckingService betCheckingService,
        IIdGenerationService idGenerationService,
        INumberGenerationService numberGenerationService,
        IDateTimeService dateTimeService)
    {
        _betRepository = betRepository;
        _userRepository = userRepository;
        _betCheckingService = betCheckingService;
        _idGenerationService = idGenerationService;
        _numberGenerationService = numberGenerationService;
        _dateTimeService = dateTimeService;
    }

    public async Task<Response<MakeBetResponse>> Handle(MakeBetCommand command, CancellationToken cancellationToken)
    {
        var all = await _userRepository.GetAllAsync();
        var user = (await _userRepository.GetByQueryAsync(u => u.Id == command.UserId)).FirstOrDefault();
        if (user is null)
        {
            return ResponseHelper<MakeBetResponse>.GetResponse(StatusCode.NotFound);
        }

        var betIsValid = Bet.IsValid(command.BetString, _betCheckingService);
        if (!betIsValid)
        {
            return ResponseHelper<MakeBetResponse>.GetResponse(StatusCode.InvalidBet);
        }
        
        var bet = new Bet(new CreateBetArgs()
        {
            User = user,
            BetString = command.BetString,
            BetCheckingService = _betCheckingService,
            IdGenerationService = _idGenerationService,
            NumberGenerationService = _numberGenerationService,
            DateTimeService = _dateTimeService
        });
        
        user.DeduceBalance(bet.BetAmountInDollarCents);
        user.AddBalance(bet.WonAmountInDollarCents);
        
        await _betRepository.CreateAsync(bet);

        return ResponseHelper<MakeBetResponse>.GetResponse(StatusCode.Success, new MakeBetResponse()
        {
            SpinId = bet.SpinId,
            WinningNumber = bet.WinningNumber,
            WonAmountInDollarCents = bet.WonAmountInDollarCents,
        });
    }
}
using MediatR;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Application.Settings;
using VirtualRoulette.Common;
using VirtualRoulette.Domain.Events;

namespace VirtualRoulette.Application.Jackpot.EventHandlers;

public class BetMadeEventHandler : INotificationHandler<DomainEventWrapper<BetMadeEvent>>
{
    private readonly IJackpotRepository _jackpotRepository;
    private readonly JackpotSettings _jackpotSettings;

    public BetMadeEventHandler(IJackpotRepository jackpotRepository, JackpotSettings jackpotSettings)
    {
        _jackpotRepository = jackpotRepository;
        _jackpotSettings = jackpotSettings;
    }

    public async Task Handle(DomainEventWrapper<BetMadeEvent> notification, CancellationToken cancellationToken)
    {
        var jackpot = (await _jackpotRepository.GetAllAsync()).First();
        var increaseAmount = Convert.ToInt64(MathHelper
            .CalculatePercentageOfNumber(
                notification.DomainEvent.UserBetAmount, 
                _jackpotSettings.JackpotIncreasePercentageFromBet));

        jackpot.IncreaseAmount(increaseAmount);

        await _jackpotRepository.UpdateAsync(jackpot);
    }
}
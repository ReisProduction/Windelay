namespace ReisProduction.Windelay;
/// <inheritdoc cref="IDelayAction"/>
/// <param name="DelayMilisecond">The duration of the <see cref="DelayAction"/> <see langword="in"/> milliseconds.</param>
/// <param name="Token">The <see cref="CancellationToken"/> to cancel the <see cref="DelayAction"/>.</param>
/// <param name="DelayType">The <see langword="typeof"/> <see cref="DelayAction"/> to use.</param>
public record DelayAction(
    int DelayMilisecond,
    CancellationToken Token,
    DelayType DelayType = DelayType.HybridDelay
) : IDelayAction;
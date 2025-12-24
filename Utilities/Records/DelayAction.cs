namespace ReisProduction.Windelay.Utilities;
/// <inheritdoc cref="IDelayAction"/>
/// <param name="DelayMilisecond">The duration of the delay in milliseconds.</param>
/// <param name="Token">The cancellation token to cancel the delay.</param>
/// <param name="DelayType">The type of delay to use.</param>
public record DelayAction(
    int DelayMilisecond,
    CancellationToken Token,
    DelayType DelayType = DelayType.HybridDelay
) : IDelayAction;
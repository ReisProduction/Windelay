namespace ReisProduction.Windelay.Utilities;
/// <summary> Represents a delay action with a specified duration and cancellation token. </summary>
public interface IDelayAction
{
    /// <summary> The duration of the delay in milliseconds. </summary>
    int DelayMilisecond { get; }
    /// <summary> The cancellation token to cancel the delay. </summary>
    CancellationToken Token { get; }
    /// <summary> The type of delay to use. </summary>
    DelayType DelayType { get; }
}
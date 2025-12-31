namespace ReisProduction.Windelay;
/// <summary> Represents a <see cref="DelayAction"/> with a specified duration <see langword="and"/> <see cref="CancellationToken"/>. </summary>
public interface IDelayAction
{
    /// <summary> The duration of the <see cref="DelayAction"/> <see langword="in"/> milliseconds. </summary>
    int DelayMilisecond { get; }

    /// <summary> The <see cref="CancellationToken"/> to cancel the <see cref="DelayAction"/>. </summary>
    CancellationToken Token { get; }
    
    /// <summary> The type of <see cref="DelayAction"/> to use. </summary>
    DelayType DelayType { get; }
}
namespace ReisProduction.Windelay;
/// <summary> <see cref="DelayType"/>s enumeration representing various <see cref="DelayExecutor"/> <see langword="method"/>s. </summary>
public enum DelayType : ushort
{
    /// <inheritdoc cref="DelayExecutor.HybridDelay(DelayAction)"/>
    HybridDelay = 0x01,

    /// <inheritdoc cref="DelayExecutor.HighResSpin(DelayAction)"/>
    HighResSpin = 0x02,
    
    /// <inheritdoc cref="DelayExecutor.SpinDelay(DelayAction)"/>
    SpinDelay = 0x03,
    
    /// <inheritdoc cref="DelayExecutor.WaitableTimer(DelayAction)"/>
    WaitableTimer = 0x04,
    
    /// <inheritdoc cref="DelayExecutor.HighResSleep(DelayAction)"/>
    HighResSleep = 0x05,
    
    /// <inheritdoc cref="DelayExecutor.SleepDelay(DelayAction)"/>
    SleepDelay = 0x06,
    
    /// <inheritdoc cref="DelayExecutor.TaskDelay(DelayAction)"/>
    TaskDelay = 0x07,
    
    /// <inheritdoc cref="DelayExecutor.TaskDelayWait(DelayAction)"/>
    TaskDelayWait = 0x08,
    
    /// <inheritdoc cref="DelayExecutor.EventWaitHandle(DelayAction)"/>
    EventWaitHandle = 0x09,
    
    /// <inheritdoc cref="DelayExecutor.TimersTimerDelay(DelayAction)"/>
    TimersTimerDelay = 0x0A,
    
    /// <inheritdoc cref="DelayExecutor.TimerDelay(DelayAction)"/>
    TimerDelay = 0x0B,
    
    /// <inheritdoc cref="DelayExecutor.FormsTimerDelay(DelayAction)"/>
    FormsTimerDelay = 0x0C
}
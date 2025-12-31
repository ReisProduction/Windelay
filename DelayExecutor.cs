namespace ReisProduction.Windelay;
/// <summary> Sensitive <see cref="DelayExecutor"/> handling various <see cref="DelayType"/>s. </summary>
public static class DelayExecutor
{
    /// <summary>
    /// <see cref="Thread.SpinWait(int)"/> iterations per loop. <para/>
    /// The <see langword="default"/> value <see langword="is"/> 200 / <see cref="Environment.ProcessorCount"/>, <see cref="Math.Clamp(byte, byte, byte)"/> between 25 <see langword="and"/> 100.
    /// </summary>
    public static int SpinWaitIterations { get; set; } = Math.Clamp(200 / Environment.ProcessorCount, 25, 100);

    /// <summary>
    /// Spin ahead time <see langword="in"/> milliseconds <see langword="for"/> <see cref="HybridDelay(DelayAction)"/>. <para/>
    /// The <see langword="default"/> value <see langword="is"/> <see langword="&quot;200&quot;"/>.
    /// </summary>
    public static int SpinAheadMilisecond { get; set; } = 200;

    /// <summary> General <see langword="method"/> to handle various <see cref="DelayType"/>s. </summary>
    public static async Task HandleDelay(DelayAction delay)
    {
        switch (delay.DelayType)
        {
            case DelayType.HybridDelay: await HybridDelay(delay); break;
            case DelayType.HighResSpin: HighResSpin(delay); break;
            case DelayType.SpinDelay: SpinDelay(delay); break;
            case DelayType.WaitableTimer: WaitableTimer(delay); break;
            case DelayType.HighResSleep: HighResSleep(delay); break;
            case DelayType.SleepDelay: SleepDelay(delay); break;
            case DelayType.TaskDelay: await TaskDelay(delay); break;
            case DelayType.TaskDelayWait: TaskDelayWait(delay); break;
            case DelayType.EventWaitHandle: EventWaitHandle(delay); break;
            case DelayType.TimersTimerDelay: await TimersTimerDelay(delay); break;
            case DelayType.TimerDelay: await TimerDelay(delay); break;
            case DelayType.FormsTimerDelay: await FormsTimerDelay(delay); break;
        }
    }

    /// <summary>
    /// Combined <see langword="method"/> <see langword="using"/> <see cref="Task.Delay(int)"/> <see langword="and"/> <see cref="Thread.SpinWait(int)"/> <see langword="for"/> timing. <para/>
    /// Better <see langword="for"/> medium to <see cref="long"/> delays <see langword="while"/> maintaining accuracy.
    /// </summary>
    public static async Task HybridDelay(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        var sw = Stopwatch.StartNew();
        int delayTime = delay.DelayMilisecond - Math.Min(SpinAheadMilisecond, delay.DelayMilisecond);
        if (delayTime > 0) try { await Task.Delay(delayTime, delay.Token); } catch (TaskCanceledException) { return; }
        while (sw.Elapsed.TotalMilliseconds < delay.DelayMilisecond && !delay.Token.IsCancellationRequested)
            Thread.SpinWait(SpinWaitIterations);
    }

    /// <summary>
    /// High-resolution <see cref="Thread.SpinWait(int)"/> <see langword="method"/> <see langword="ushort"/> <see cref="Stopwatch"/> <see langword="for"/> timing. <para/>
    /// Blocks the <see cref="Thread"/> but provides better accuracy <see langword="for"/> <see cref="short"/> delays. <para/>
    /// <see langword="do"/> <see langword="not"/> use <see langword="for"/> <see cref="long"/> delays to avoid high CPU usage <see langword="and"/> block <see cref="Thread"/>.
    /// </summary>
    public static void HighResSpin(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        long freq = Stopwatch.Frequency,
           target = Stopwatch.GetTimestamp() + delay.DelayMilisecond * freq / 1000;
        while (Stopwatch.GetTimestamp() < target && !delay.Token.IsCancellationRequested)
            Thread.SpinWait(SpinWaitIterations);
    }

    /// <summary>
    /// <see cref="Thread.SpinWait(int)"/> <see langword="method"/> <see langword="for"/> timing. <para/>
    /// Blocks the <see cref="Thread"/> but provides better accuracy <see langword="for"/> <see cref="short"/> delays. <para/>
    /// <see langword="do"/> <see langword="not"/> use <see langword="for"/> <see cref="long"/> delays to avoid high CPU usage <see langword="and"/> block <see cref="Thread"/>.
    /// </summary>
    public static void SpinDelay(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        var sw = Stopwatch.StartNew();
        while (sw.Elapsed.TotalMilliseconds < delay.DelayMilisecond && !delay.Token.IsCancellationRequested)
            Thread.SpinWait(SpinWaitIterations);
    }

    /// <summary> <see cref="WaitableTimer(DelayAction)"/> <see langword="method"/> <see langword="using"/> Windows API (kernel32) <see langword="for"/> timing. </summary>
    public static void WaitableTimer(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        nint handle = CreateWaitableTimer(nint.Zero, true, null);
        if (handle == nint.Zero) return;
        try
        {
            long due = -1 * delay.DelayMilisecond * 10000;
            SetWaitableTimer(handle, ref due, 0, nint.Zero, nint.Zero, false);
            _ = WaitForSingleObject(handle, (uint)delay.DelayMilisecond);
        }
        finally { CloseHandle(handle); }
    }

    /// <summary> <see cref="Thread.Sleep(int)"/> <see langword="method"/> <see langword="using"/> <see cref="timeBeginPeriod(uint)"/> <see langword="and"/> <see cref="timeEndPeriod(uint)"/> <see langword="for"/> timing. </summary>
    public static void HighResSleep(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        _ = timeBeginPeriod(1);
        Thread.Sleep(delay.DelayMilisecond);
        _ = timeEndPeriod(1);
    }
    
    /// <inheritdoc cref="Thread.Sleep(int)"/>
    public static void SleepDelay(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        Thread.Sleep(delay.DelayMilisecond);
    }
    
    /// <inheritdoc cref="Task.Delay(int)"/>
    public static async Task TaskDelay(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        await Task.Delay(delay.DelayMilisecond, delay.Token);
    }
    
    /// <inheritdoc cref="Task.Wait(CancellationToken)"/>
    public static void TaskDelayWait(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        Task.Delay(delay.DelayMilisecond, delay.Token).Wait(delay.Token);
    }
    
    /// <summary> <see langword="using"/> <see cref="ManualResetEventSlim.Wait(int, CancellationToken)"/> <see langword="for"/> timing. </summary>
    public static void EventWaitHandle(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        using ManualResetEventSlim ev = new(false);
        ev.Wait(delay.DelayMilisecond, delay.Token);
    }
    
    /// <summary> <see langword="using"/> <see cref="System.Timers.Timer"/> <see langword="for"/> timing. </summary>
    public static async Task TimersTimerDelay(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        TaskCompletionSource tcs = new();
        using System.Timers.Timer timer = new(delay.DelayMilisecond) { AutoReset = false };
        timer.Elapsed += (_, __) => tcs.TrySetResult();
        timer.Start();
        using (delay.Token.Register(() => tcs.TrySetCanceled()))
            await tcs.Task;
    }
    
    /// <summary> <see langword="using"/> <see cref="Timer"/> <see langword="for"/> timing. </summary>
    public static async Task TimerDelay(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        TaskCompletionSource tcs = new();
        using Timer timer = new(_ => tcs.TrySetResult(), null, delay.DelayMilisecond, Timeout.Infinite);
        using (delay.Token.Register(() => tcs.TrySetCanceled()))
            await tcs.Task;
    }
    
    /// <summary> <see langword="using"/> <see cref="System.Windows.Forms.Timer"/> <see langword="for"/> timing. </summary>
    public static async Task FormsTimerDelay(DelayAction delay)
    {
        if (delay.DelayMilisecond <= 0) return;
        TaskCompletionSource tcs = new();
        using System.Windows.Forms.Timer timer = new() { Interval = delay.DelayMilisecond };
        timer.Tick += (_, __) => { timer.Stop(); tcs.TrySetResult(); };
        timer.Start();
        using (delay.Token.Register(() => tcs.TrySetCanceled()))
            await tcs.Task;
    }
}
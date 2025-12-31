using System.Runtime.InteropServices;
namespace ReisProduction.Windelay.Services;
/// <summary> Provides access to native <see langword="method"/>s from Windows API. </summary>
internal static class NativeMethods
{
    #region Kernel32
    /// <summary> Closes an open <see cref="object"/> handle. </summary>
    /// <param name="hObject">A handle to the <see cref="object"/> to close.</param>
    /// <returns><see langword="true"/> <see langword="if"/> successful, <see langword="false"/> otherwise.</returns>
    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern bool CloseHandle(nint hObject);

    /// <summary> Creates <see langword="or"/> opens a waitable timer <see langword="object"/>. </summary>
    /// <param name="lpTimerAttributes">A pointer to a SECURITY_ATTRIBUTES structure that determines whether the <see langword="return"/>ed handle can be inherited by child processes. <para/>
    /// <see langword="if"/> <see langword="this"/> parameter <see langword="is"/> <see langword="null"/>, the handle can<see langword="not"/> be inherited.</param>
    /// <param name="bManualReset"><see langword="if"/> <see langword="true"/>, the timer <see langword="is"/> a manual-reset timer. <see langword="if"/> <see langword="false"/>, the timer <see langword="is"/> <see langword="an"/> auto-reset timer.</param>
    /// <param name="lpTimerName">The <see langword="nameof"/> the timer <see cref="object"/>.</param>
    /// <returns>A handle to the waitable timer <see cref="object"/>.</returns>
    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern nint CreateWaitableTimer(nint lpTimerAttributes, bool bManualReset, string? lpTimerName);

    /// <summary> <see langword="set"/>s the specified waitable timer. </summary>
    /// <param name="hTimer">A <paramref name="hTimer"/> to the timer to <see langword="set"/>.</param>
    /// <param name="pDueTime">The time at which the timer <see langword="is"/> to be <see langword="set"/>, in 100-nanosecond intervals.</param>
    /// <param name="lPeriod">The timer period, <see langword="in"/> milliseconds.</param>
    /// <param name="pfnCompletionRoutine">The completion routine to be called <see langword="when"/> the timer elapses.</param>
    /// <param name="lpArgToCompletionRoutine">An optional argument to be passed to the completion routine.</param>
    /// <param name="fResume"><see langword="if"/> <see langword="true"/>, the timer <see langword="is"/> resumed <see langword="if"/> it <see langword="is"/> currently suspended.</param>
    /// <returns><see langword="true"/> <see langword="if"/> successful, <see langword="or"/> <see langword="false"/> otherwise.</returns>
    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern bool SetWaitableTimer(nint hTimer, ref long pDueTime, int lPeriod, nint pfnCompletionRoutine, nint lpArgToCompletionRoutine, bool fResume);

    /// <summary> Waits until the specified <see cref="object"/> <see langword="is"/> <see langword="in"/> the signaled state <see langword="or"/> the time-out interval elapses. </summary>
    /// <param name="hHandle">A <paramref name="hHandle"/> to the <see cref="object"/> to wait <see langword="for"/>.</param>
    /// <param name="dwMilliseconds">The time-out interval, <see langword="in"/> <paramref name="dwMilliseconds"/>.</param>
    /// <returns>One of the wait result values.</returns>
    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern uint WaitForSingleObject(nint hHandle, uint dwMilliseconds);
    #endregion

    #region Winmm
    /// <summary> Sets the global timer resolution to the specified period. </summary>
    /// <param name="uMilliseconds">The period <see langword="in"/> <paramref name="uMilliseconds"/>.</param>
    /// <returns>Zero <see langword="if"/> successful, <see langword="or"/> an error code otherwise.</returns>
    [DllImport("winmm", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern uint timeBeginPeriod(uint uMilliseconds);

    /// <summary> Sets the global timer resolution to the specified period. </summary>
    /// <param name="uMilliseconds">The period <see langword="in"/> <paramref name="uMilliseconds"/>.</param>
    /// <returns>Zero <see langword="if"/> successful, <see langword="or"/> an error code otherwise.</returns>
    [DllImport("winmm", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern uint timeEndPeriod(uint uMilliseconds);
    #endregion
}
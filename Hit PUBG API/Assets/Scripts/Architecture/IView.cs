using System;
using UniRx;

namespace Architecture
{
    public interface IView
    {
        IObservable<Unit> ViewEnabled { get; }
        IObservable<Unit> ViewDisabled { get; }
        IObservable<Unit> ViewCleanup { get; }
    }
}
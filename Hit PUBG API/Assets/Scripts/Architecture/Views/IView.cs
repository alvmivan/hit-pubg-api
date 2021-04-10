using System;
using UniRx;

namespace Architecture.Views
{
    public interface IView
    {
        IObservable<Unit> ViewEnabled { get; }
        IObservable<Unit> ViewDisabled { get; }
        IObservable<Unit> ViewCleanup { get; }
    }
}
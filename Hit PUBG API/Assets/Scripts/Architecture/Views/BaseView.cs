using System;
using UniRx;
using UnityEngine;

namespace Architecture.Views
{
    public class BaseView : MonoBehaviour
    {
        private readonly ISubject<Unit> viewCleanup = new Subject<Unit>();
        private readonly ISubject<Unit> viewDisabled = new Subject<Unit>();
        private readonly ISubject<Unit> viewEnabled = new Subject<Unit>();


        public IObservable<Unit> ViewEnabled => viewEnabled;
        public IObservable<Unit> ViewDisabled => viewDisabled;
        public IObservable<Unit> ViewCleanup => viewCleanup;

        protected virtual void OnEnable()
        {
            viewEnabled.OnNext(Unit.Default);
        }

        protected virtual void OnDisable()
        {
            viewEnabled.OnNext(Unit.Default);
        }

        protected virtual void OnDestroy()
        {
            viewCleanup.OnNext(Unit.Default);
        }
    }
}
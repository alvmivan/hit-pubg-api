using Tournaments.Core.Services;
using UniRx;

namespace Tournaments.Presentation
{
    public class TournamentListPresenter
    {
        private readonly CompositeDisposable disposables = new CompositeDisposable();
        private readonly ITournamentGateway gateway;
        private readonly ITournamentListView view;

        public TournamentListPresenter(ITournamentListView view, ITournamentGateway gateway)
        {
            this.view = view;
            this.gateway = gateway;
            BindToViewEvents();
        }

        private void BindToViewEvents()
        {
            // when view is enabled then present the info
            view.ViewEnabled
                .Subscribe(_ => Present())
                .AddTo(disposables);

            // hide the view on disabled
            view.ViewDisabled
                .Subscribe(_ => Hide())
                .AddTo(disposables);

            // perform cleanup on view disposed
            view.ViewCleanup
                .Subscribe(_ => CleanUp())
                .AddTo(disposables);
        }

        private void Present()
        {
            gateway
                .GetEntries()
                .ObserveOnMainThread()
                .Subscribe(view.ShowTournaments)
                .AddTo(disposables);
        }

        private void Hide()
        {
            view.OnHide();
        }

        private void CleanUp()
        {
            disposables.Clear();
        }
    }
}
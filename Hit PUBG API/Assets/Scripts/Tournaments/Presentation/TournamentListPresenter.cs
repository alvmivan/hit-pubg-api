using Tournaments.Core.Services;
using UniRx;

namespace Tournaments.Presentation
{
    public class TournamentListPresenter
    {
        private readonly ITournamentListView view;
        private readonly CompositeDisposable disposables = new CompositeDisposable();
        private ITournamentGateway gateway;

        public TournamentListPresenter(ITournamentListView view, ITournamentGateway gateway)
        {
            this.view = view;
            this.gateway = gateway;
            BindToViewEvents();
        }

        private void BindToViewEvents()
        {
            view.ViewEnabled
                .Subscribe(_ => Present())
                .AddTo(disposables);
            view.ViewDisabled
                .Subscribe(_ => Hide())
                .AddTo(disposables);
            view.ViewCleanup
                .Subscribe(_ => CleanUp())
                .AddTo(disposables);
        }

        private void Present()
        {
            gateway
                .GetEntries()
                .ObserveOnMainThread()
                .Subscribe(view.ShowTournaments);
        }

        private void Hide()
        {
        }

        private void CleanUp()
        {
            disposables.Clear();
        }
    }
}
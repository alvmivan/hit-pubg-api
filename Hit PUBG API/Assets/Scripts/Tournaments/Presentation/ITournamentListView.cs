using System.Collections.Generic;
using Architecture;
using Architecture.Views;
using Tournaments.Core.Domain;

namespace Tournaments.Presentation
{
    public interface ITournamentListView : IView
    {
        void ShowTournaments(IReadOnlyList<Tournament> tournaments);
        void OnHide();
    }
}
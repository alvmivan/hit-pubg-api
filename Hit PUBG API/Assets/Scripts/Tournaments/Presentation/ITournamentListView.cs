using System;
using System.Collections.Generic;
using Architecture;
using Tournaments.Core.Domain;
using UniRx;

namespace Tournaments.Presentation
{
    public interface ITournamentListView : IView
    {
        void ShowTournaments(IReadOnlyList<Tournament> tournaments);
    }
}
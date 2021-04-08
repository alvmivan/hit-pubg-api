using System;
using System.Collections.Generic;
using Tournaments.Core.Domain;

namespace Tournaments.Core.Services
{
    public interface ITournamentGateway
    {
        IObservable<IReadOnlyList<Tournament>> GetEntries();
    }
}
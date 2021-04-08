using System;
using System.Collections.Generic;

namespace Tournaments.Core.Domain
{
    
    public class Tournament
    {
        public string TournamentId { get; }
        public DateTime CreationTime { get; }

        public Tournament(string tournamentId, DateTime creationTime)
        {
            TournamentId = tournamentId;
            CreationTime = creationTime;
        }
    }
}
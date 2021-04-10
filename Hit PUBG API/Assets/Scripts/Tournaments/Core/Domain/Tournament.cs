using System;

namespace Tournaments.Core.Domain
{
    public class Tournament
    {
        public Tournament(string tournamentId, DateTime creationTime)
        {
            TournamentId = tournamentId;
            CreationTime = creationTime;
        }

        public string TournamentId { get; }
        public DateTime CreationTime { get; }
    }
}
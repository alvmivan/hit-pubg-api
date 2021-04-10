using System;

namespace Tournaments.Infrastructure.DTOs
{
    [Serializable]
    public struct TournamentEntryDTO
    {
        public string type;
        public string id;
        public TournamentAttributesDTO attributes;
    }
}
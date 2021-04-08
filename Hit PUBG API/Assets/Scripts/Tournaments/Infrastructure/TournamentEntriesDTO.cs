﻿using System;

namespace Tournaments.Infrastructure
{
    [Serializable]
    public struct TournamentEntriesDTO
    {
        public TournamentEntryDTO[] data;
    }

    [Serializable]
    public struct TournamentEntryDTO
    {
        public string type;
        public string id;
        public TournamentAttributesDTO attributes;
    }

    [Serializable]
    public struct TournamentAttributesDTO
    {
        public string createdAt;
    }

    //example json:
    /*
    {
        "data": [
            {
                "type": "tournament",
                "id": "sea-pwstw",
                "attributes": {
                    "createdAt": "2021-03-31T11:33:02Z"
                }
            },
            {
                "type": "tournament",
                "id": "as-aplas",
                "attributes": {
                    "createdAt": "2021-03-31T09:13:23Z"
                }
            },
            {
                "type": "tournament",
                "id": "as-pgiwf6",
                "attributes": {
                    "createdAt": "2021-03-27T10:42:45Z"
                }
            }
        ],
        "links": {
            "self": "https://api.pubg.com/tournaments"
        },
        "meta": {}
    }
     */
}
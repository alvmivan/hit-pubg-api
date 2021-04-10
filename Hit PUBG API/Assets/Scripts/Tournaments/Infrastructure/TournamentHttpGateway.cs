using System;
using System.Collections.Generic;
using System.Linq;
using Architecture.WebClient;
using Tournaments.Core.Domain;
using Tournaments.Core.Services;
using Tournaments.Infrastructure.DTOs;
using UniRx;
using UnityEngine;

namespace Tournaments.Infrastructure
{
    public class TournamentHttpGateway : ITournamentGateway
    {
        private const string Server = "https://api.pubg.com";
        private const string Endpoint = "/tournaments";

        private const string Uri = Server + Endpoint;

        private static readonly (string key, string value)[] Headers =
        {
            ("accept", "application/vnd.api+json"),
            ("Authorization", " Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI5Y2NmZWRmMC03YTgzLTAxMzktMzQ5OS0wNzE2M2MzNTk3YmEiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjE3ODc3OTM2LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6Ii1kMzZjMWU3Ni1kYWEyLTRkYTAtYWEyYi0yYmJmZjFmOTU3NTMifQ.wVbimEHIW_hCnwCnTY2f3aXABUx4ny2VxyxEZesrSy4"),
            ("content-type", "application/json")
        };

        private readonly IWebClient webClient;

        public TournamentHttpGateway(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public IObservable<IReadOnlyList<Tournament>> GetEntries()
        {
            return webClient
                .Get(Uri, Headers)
                .Select(ToDomain);
        }

        private static IReadOnlyList<Tournament> ToDomain(string json)
        {
            var dto = JsonUtility.FromJson<TournamentEntriesDTO>(json);
            return dto.data.Select(ToDomain).ToList();
        }

        private static Tournament ToDomain(TournamentEntryDTO entry)
        {
            DateTime.TryParse(entry.attributes.createdAt, out var date);
            return new Tournament(entry.id, date);
        }
    }
}
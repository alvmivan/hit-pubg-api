using System;
using System.Collections.Generic;
using Architecture;
using Architecture.WebClient;
using Tournaments.Core.Domain;
using Tournaments.Infrastructure;
using Tournaments.Presentation;
using UniRx;
using UnityEngine;
using Utils;

namespace Tournaments.View
{
    public class TournamentListView : BaseView, ITournamentListView
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private TournamentEntryView entryPrefab;

        private void Awake()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new TournamentListPresenter(this, new TournamentHttpGateway(new ObservableWebClient()));
        }

        public void ShowTournaments(IReadOnlyList<Tournament> tournaments)
        {
            content.CleanChildren();

            var contentSize = content.sizeDelta;
            var entryPosition = Vector2.zero;
            contentSize.y = 0f;

            foreach (var tournament in tournaments)
            {
                var entryView = Instantiate(entryPrefab, content);

                entryView.Init(tournament.TournamentId, tournament.CreationTime);

                var entryHeight = entryView.GetHeight();

                entryView.SetWidth(contentSize.x);

                entryView.SetPosition(entryPosition);

                contentSize.y += entryHeight;

                entryPosition.y -= entryHeight;
            }

            content.sizeDelta = contentSize;
        }
    }
}
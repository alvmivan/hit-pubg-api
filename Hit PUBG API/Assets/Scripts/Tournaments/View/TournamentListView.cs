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

        private TournamentListPresenter presenter;

        private void Awake()
        {
            presenter = new TournamentListPresenter(this, new TournamentHttpGateway(new ObservableWebClient()));
        }

        public void ShowTournaments(IReadOnlyList<Tournament> tournaments)
        {
            content.CleanChildren();
            var totalHeight = 0f;
            var sizeDelta = content.sizeDelta;

            var topX = 0f;
            var topY = 0f;

            foreach (var tournament in tournaments)
            {
                var entryView = Instantiate(entryPrefab, content);

                var entryHeight = entryView.GetHeight();

                entryView.SetWidth(sizeDelta.x);
                
                entryView.SetPosition(new Vector2(topX, topY));
                
                totalHeight += entryHeight;
                
                topY -= entryHeight;


                entryView.Init(tournament.TournamentId, tournament.CreationTime);
            }

            sizeDelta.y = totalHeight;
            content.sizeDelta = sizeDelta;
        }
    }
}
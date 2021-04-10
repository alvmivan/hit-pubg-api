using System.Collections;
using System.Collections.Generic;
using Architecture;
using Architecture.Views;
using Architecture.WebClient;
using Tournaments.Core.Domain;
using Tournaments.Infrastructure;
using Tournaments.Presentation;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Tournaments.View
{
    public class TournamentListView : BaseView, ITournamentListView
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private TournamentEntryView entryPrefab;
        [SerializeField] private ScrollRect scrollRect;

        [SerializeField] private int entriesToLoadWithDelay = 6;
        [SerializeField] private float loadingEffectDuration;


        private readonly CompositeDisposable disposables = new CompositeDisposable();

        private void Awake()
        {
            scrollRect.gameObject.SetActive(false);
            // using dependencies injector on this little project could be overkill
            new TournamentListPresenter(this, new TournamentHttpGateway(new UnityWebClient()));
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            disposables.Clear();
        }

        public void ShowTournaments(IReadOnlyList<Tournament> tournaments)
        {
            content.CleanChildren();

            LoadTournaments(tournaments)
                .ToObservable()
                .Subscribe()
                .AddTo(disposables);
        }

        public void OnHide()
        {
            scrollRect.gameObject.SetActive(false);
        }

        private IEnumerator LoadTournaments(IReadOnlyList<Tournament> tournaments)
        {
            var contentSize = content.sizeDelta;
            var entryPosition = Vector2.zero;
            contentSize.y = 0f;

            //active again the scroll
            scrollRect.gameObject.SetActive(true);
            //but disable scrolling
            scrollRect.enabled = false;

            //setup a delay to wait on the first iterations
            var delay = new WaitForSecondsRealtime(loadingEffectDuration / entriesToLoadWithDelay);

            for (var i = 0; i < tournaments.Count; i++)
            {
                var tournament = tournaments[i];

                // create the tournament entry
                var entryView = Instantiate(entryPrefab, content);
                entryView.Init(tournament.TournamentId, tournament.CreationTime);

                // setup rect and update custom layout
                var entryHeight = entryView.GetHeight();
                entryView.SetWidth(contentSize.x);
                entryView.SetPosition(entryPosition);
                contentSize.y += entryHeight;
                entryPosition.y -= entryHeight;


                // throw a delay for the first entriesToLoadWithDelay entries
                if (i < entriesToLoadWithDelay)
                {
                    yield return delay;
                    //update the size delta on each delayed iteration to see the effect of the bar growing up
                    content.sizeDelta = contentSize;
                }
            }

            //enable scrolling again
            scrollRect.enabled = true;
            yield return null;

            //setup size delta again to avoid glitches 
            content.sizeDelta = contentSize;
        }
    }
}
using System;
using TMPro;
using UnityEngine;

namespace Tournaments.View
{
    public class TournamentEntryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tournamentIdLabel;
        [SerializeField] private TextMeshProUGUI creationTimeLabel;
        [SerializeField] private RectTransform container;
        [SerializeField] private RectTransform bottomLine;

        public float GetHeight()
        {
            return container.rect.height;
        }

        public void Init(string tournamentId, DateTime creationTime)
        {
            tournamentIdLabel.text = tournamentId;
            creationTimeLabel.text = creationTime.ToString("dd-MM-yy");
        }

        public void SetWidth(float width)
        {
            var sizeDelta = container.sizeDelta;
            sizeDelta.x = width;
            container.sizeDelta = sizeDelta;
        }

        public void SetPosition(Vector2 position)
        {
            container.localPosition = position;
        }

        public void ShowBottomLine(bool show)
        {
            bottomLine.gameObject.SetActive(show);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UI;
using UnityEngine;

namespace GameOver
{
    public class GameOverPanel : UiPanel
    {
        [SerializeField] private TextMeshProUGUI titleContainer;
        [SerializeField] private TextMeshProUGUI reasonContainer;
        [SerializeField] private List<ReasonTranslationData> reasonsTranslation;

        private void Start()
        {
            GameOverObserver.OnGameOver += SetupAndEnable;
        }

        private void OnDestroy()
        {
            GameOverObserver.OnGameOver -= SetupAndEnable;
        }

        private void SetupAndEnable(GameOverReason reason)
        {
            ReasonTranslationData matchingTranslation = reasonsTranslation.FirstOrDefault(translation => translation.Reason == reason);
            string translatedReason = matchingTranslation.Equals(default(ReasonTranslationData))
                ? string.Empty
                : matchingTranslation.Translation;
            string translatedTitle = matchingTranslation.Equals(default(ReasonTranslationData))
                ? string.Empty
                : matchingTranslation.Title;

            reasonContainer.text = translatedReason;
            titleContainer.text = translatedTitle;
            Enable();
        }
    }
}
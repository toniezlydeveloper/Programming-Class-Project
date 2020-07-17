using System;
using UnityEngine;

namespace GameOver
{
    [Serializable]
    public struct ReasonTranslationData
    {
        [SerializeField] private GameOverReason reason;
        [SerializeField] private string title;
        [SerializeField] private string translation;

        public GameOverReason Reason => reason;
        public string Title => title;
        public string Translation => translation;
    }
}
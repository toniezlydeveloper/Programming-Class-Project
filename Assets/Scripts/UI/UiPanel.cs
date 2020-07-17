using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class UiPanel : MonoBehaviour
    {
        [SerializeField] private float toggleDuration;
        [SerializeField] private CanvasGroup canvasGroup;
        
        public void Enable()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(canvasGroup.DOFade(1f, toggleDuration))
                .AppendCallback(() => canvasGroup.blocksRaycasts = true).SetUpdate(true).Play();
        }

        public void Disable()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
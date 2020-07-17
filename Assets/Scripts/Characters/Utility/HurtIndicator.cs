using System.Collections;
using Characters.Interfaces;
using UnityEngine;

namespace Characters.Utility
{
    public class HurtIndicator : MonoBehaviour
    {
        [SerializeField] private float blinkDuration;
        [SerializeField] private Color blinkColor;
        [SerializeField] private SpriteRenderer rendererToBlink;

        private void Awake()
        {
            IDamageable damageable = GetComponent<IDamageable>();
            
            if (damageable == null)
            {
                return;
            }

            damageable.OnTookDamage += BlinkWithRenderer;
        }

        private void BlinkWithRenderer()
        {
            StartCoroutine(BlinkCoroutine());
        }

        private IEnumerator BlinkCoroutine()
        {
            Color initialColor = rendererToBlink.color;
            float firstBlinkEndTime = Time.time + blinkDuration;

            while (Time.time < firstBlinkEndTime)
            {
                rendererToBlink.color = Color.Lerp(rendererToBlink.color, blinkColor, Time.deltaTime);
                yield return null;
            }
            
            float secondBlinkEndTime = Time.time + blinkDuration;
            
            while (Time.time < secondBlinkEndTime)
            {
                rendererToBlink.color = Color.Lerp(rendererToBlink.color, initialColor, Time.deltaTime);
                yield return null;
            }

            rendererToBlink.color = Color.white;
        }
    }
}
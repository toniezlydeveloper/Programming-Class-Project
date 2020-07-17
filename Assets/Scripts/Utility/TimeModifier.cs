using UnityEngine;

namespace Utility
{
    public static class TimeModifier
    {
        private const float DefaultFixedDeltaTime = 0.02f;

        public static float TimeScale
        {
            set
            {
                float valueToApply = Mathf.Clamp(value, 0f, 1f);
                Time.timeScale = valueToApply;
                Time.fixedDeltaTime = DefaultFixedDeltaTime * valueToApply;
            }
        }
    }
}

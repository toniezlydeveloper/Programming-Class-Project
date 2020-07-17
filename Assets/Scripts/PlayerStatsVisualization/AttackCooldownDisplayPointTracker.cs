using UnityEngine;

namespace PlayerStatsVisualization
{
    public class AttackCooldownDisplayPointTracker : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Transform displayPointTransform;

        private static Camera staticMainCamera;
        private static Transform staticDisplayPointTransform;

        public static Vector2 DisplayPoint =>
            staticMainCamera.WorldToScreenPoint(staticDisplayPointTransform.position);

        private void Awake()
        {
            staticMainCamera = mainCamera != null ? mainCamera : Camera.main;
            staticDisplayPointTransform = displayPointTransform != null ? displayPointTransform : transform;
        }
    }
}
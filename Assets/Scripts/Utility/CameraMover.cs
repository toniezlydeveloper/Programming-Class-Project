using UnityEngine;

namespace Utility
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float trackingSpeed;
        [SerializeField] private float maxX;
        [SerializeField] private float maxY;
        [SerializeField] private float minX;
        [SerializeField] private float minY;

        private float defaultZ;

        private void Start()
        {
            defaultZ = transform.position.z;
        }

        private void FixedUpdate()
        {
            if (playerTransform == null)
            {
                return;
            }
            
            Vector3 fixedTrackedPosition =
                new Vector3(playerTransform.position.x, playerTransform.position.y, defaultZ);
            
            Vector3 desiredPosition = Vector3.Lerp(transform.position, fixedTrackedPosition,
                trackingSpeed * Time.deltaTime);

            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

            transform.position = Vector3.Lerp(transform.position, desiredPosition, trackingSpeed * Time.deltaTime);
        }
    }
}
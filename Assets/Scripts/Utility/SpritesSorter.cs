using UnityEngine;

namespace Utility
{
    public class SpritesSorter : MonoBehaviour
    {
        [SerializeField] private bool isStatic;
        [SerializeField] private Transform positionReferencePoint;
        [SerializeField] protected Renderer mainRenderer;

        private void Awake()
        {
            if (isStatic)
            {
                UpdateSortingOrder();
                Destroy(this);
            }
            else
            {
                InvokeRepeating(nameof(UpdateSortingOrder), 0.1f, 0.1f);
            }
        }

        private void UpdateSortingOrder()
        {
            mainRenderer.sortingOrder = (int) (-1000 * positionReferencePoint.position.y);
        }
    }
}

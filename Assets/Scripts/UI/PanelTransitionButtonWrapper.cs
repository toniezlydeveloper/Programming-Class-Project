using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class PanelTransitionButtonWrapper : MonoBehaviour
    {
        [SerializeField] private UiPanel panelToEnable;
        [SerializeField] private UiPanel panelToDisable;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(TogglePanels);
        }

        private void TogglePanels()
        {
            panelToEnable.Enable();
            panelToDisable.Disable();
        }
    }
}
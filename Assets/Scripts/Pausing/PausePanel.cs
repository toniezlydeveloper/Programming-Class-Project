using System;
using UI;

namespace Pausing
{
    public class PausePanel : UiPanel
    {
        private void Start()
        {
            Pauser.OnPauseToggled += TogglePanel;
        }

        private void OnDestroy()
        {
            Pauser.OnPauseToggled -= TogglePanel;
        }

        private void TogglePanel(bool pauseState)
        {
            if (pauseState)
            {
                Enable();
            }
            else
            {
                Disable();
            }
        }
    }
}
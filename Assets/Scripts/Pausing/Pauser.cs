using System;
using GameOver;
using UnityEngine;
using Utility;

namespace Pausing
{
    public class Pauser : MonoBehaviour
    {
        public static event Action<bool> OnPauseToggled;
        
        private bool isPaused;

        private void Start()
        {
            GameOverObserver.OnGameOver += PauseTimeAndDisable;
        }

        private void OnDestroy()
        {
            TimeModifier.TimeScale = 1f;
            GameOverObserver.OnGameOver -= PauseTimeAndDisable;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause(!isPaused);
            }
        }

        private void TogglePause(bool newState)
        {
            TimeModifier.TimeScale = newState ? 0f : 1f;
            OnPauseToggled?.Invoke(newState);
            isPaused = newState;
        }

        private void PauseTimeAndDisable(GameOverReason reason)
        {
            TimeModifier.TimeScale = 0f;
            enabled = false;
        }
    }
}

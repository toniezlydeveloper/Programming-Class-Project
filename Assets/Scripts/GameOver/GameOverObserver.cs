using System;
using Characters;
using Characters.Enemies;
using UnityEngine;

namespace GameOver
{
    public class GameOverObserver : MonoBehaviour
    {
        public static event Action<GameOverReason> OnGameOver;

        [SerializeField] private Character player;
        
        private int enemyCount;

        private const float GameOverDelay = 2.5f;
        
        private void Start()
        {
            SetupGameOverConditions();
        }

        private void SetupGameOverConditions()
        {
            foreach (Enemy enemy in FindObjectsOfType<Enemy>())
            {
                enemy.OnDeath += ProcessEnemyDeath;
                enemyCount++;
            }

            player.OnDeath += () => Invoke(nameof(PlayerDied), GameOverDelay);
        }

        private void ProcessEnemyDeath()
        {
            enemyCount--;

            if (enemyCount <= 0)
            {
                Invoke(nameof(AllEnemiesDied), GameOverDelay);
            }
        }

        private void AllEnemiesDied()
        {
            OnGameOver?.Invoke(GameOverReason.AllEnemiesDied);
        }

        private void PlayerDied()
        {
            OnGameOver?.Invoke(GameOverReason.PlayedDied);
        }
    }
}

using System;
using Characters.Enemies;
using Characters.Interfaces;
using UnityEngine;
using Weapons.Interfaces;

namespace Weapons.HitDetectors
{
    public class EnemyHitDetector : MonoBehaviour, IHitDetector
    {
        public event Action<IDamageable> OnDamageableHit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                OnDamageableHit?.Invoke(enemy);
            }
        }
    }
}
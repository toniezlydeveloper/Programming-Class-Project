using System;
using Characters.Interfaces;
using Characters.Player;
using UnityEngine;
using Weapons.Interfaces;

namespace Weapons.HitDetectors
{
    public class PlayerHitDetector : MonoBehaviour, IHitDetector
    {
        public event Action<IDamageable> OnDamageableHit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayableCharacter player = other.GetComponent<PlayableCharacter>();

            if (player != null)
            {
                OnDamageableHit?.Invoke(player);
            }
        }
    }
}
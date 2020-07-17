using System;
using Characters.Interfaces;
using UnityEngine;

namespace Characters
{
    public abstract class Character : MonoBehaviour, IDamageable
    {
        public event Action OnDeath;
        public event Action OnTookDamage;

        [SerializeField] protected Animator animator;

        protected abstract bool IsAlive { get; }
        private static readonly int DeathHash = Animator.StringToHash("Death");

        private bool didCharacterDie;

        public virtual void TakeDamage(float damageAmount)
        {
            if (IsAlive)
            {
                OnTookDamage?.Invoke();
                return;
            }

            Die();
        }

        private void Die()
        {
            if (didCharacterDie)
            {
                return;
            }

            didCharacterDie = true;
            
            animator.SetTrigger(DeathHash);
            Invoke(nameof(Destroy), 2f);
            OnDeath?.Invoke();
        }
        
        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
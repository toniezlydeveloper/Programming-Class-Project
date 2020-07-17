using System;
using Characters.Player;
using UnityEngine;

namespace Characters.Enemies
{
    public abstract class Enemy : Character
    {
        [SerializeField] protected float maxHealth;
        [SerializeField] protected float attackRange;
        [SerializeField] protected PlayableCharacter playableCharacter;
        
        protected float currentHealth;
        protected StateMachine stateMachine;

        private void Start()
        {
            currentHealth = maxHealth;
            ConstructStateMachine();
        }
        
        private void Update()
        {
            stateMachine?.Tick();
        }

        public override void TakeDamage(float damageAmount)
        {
            if (damageAmount < 1)
            {
                return;
            }

            currentHealth -= damageAmount;
            base.TakeDamage(damageAmount);
        }

        protected abstract void ConstructStateMachine();
    }
}

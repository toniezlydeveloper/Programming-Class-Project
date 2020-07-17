using Characters.Interfaces;
using UnityEngine;
using Weapons.Interfaces;

namespace Weapons
{
    public class AttackWave : Weapon
    {
        private IHitDetector hitDetector;

        private void Awake()
        {
            hitDetector = GetComponent<IHitDetector>();
            hitDetector.OnDamageableHit += DealDamage;
        }

        private void OnDestroy()
        {
            hitDetector.OnDamageableHit -= DealDamage;
        }

        public override void Attack()
        {
            base.Attack();
            
            animator.SetTrigger(AttackHash);
        }

        private void DealDamage(IDamageable damageableToHurt)
        {
            damageableToHurt.TakeDamage(attackValue);
        }
    }
}
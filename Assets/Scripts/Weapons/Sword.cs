using Characters.Interfaces;
using UnityEngine;
using Weapons.Interfaces;

namespace Weapons
{
    public class Sword : AdvancedWeapon
    {
        private void Awake()
        {
            foreach (IHitDetector hitDetector in GetComponentsInChildren<IHitDetector>())
            {
                hitDetector.OnDamageableHit += DealDamage;
            }
        }

        public override void Attack()
        {
            base.Attack();
            
            animator.SetTrigger(AttackHash);
            wasAdvancedAttack = false;
        }

        public override void AdvancedAttack()
        {
            base.AdvancedAttack();
            
            animator.SetTrigger(AdvancedAttackHash);
            wasAdvancedAttack = true;
        }

        private void DealDamage(IDamageable damageableToHurt)
        {
            damageableToHurt.TakeDamage(DamageToDeal);
        }
    }
}
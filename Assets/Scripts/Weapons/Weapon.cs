using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected int attackValue;
        [SerializeField] protected float attackCooldown;
        [SerializeField, HideInInspector] private bool isDuringAttackAnimation;

        protected float attackTime;
        protected readonly int AttackHash = Animator.StringToHash("Attack");

        public bool IsOnCooldown => Time.time < attackTime;
        public bool IsDuringAttackAnimation => isDuringAttackAnimation;

        public virtual void Attack()
        {
            attackTime = Time.time + attackCooldown;
        }
    }
}
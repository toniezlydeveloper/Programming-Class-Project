using System;
using System.Xml.Linq;
using UnityEngine;
using Weapons.Enums;

namespace Weapons
{
    public abstract class AdvancedWeapon : Weapon
    {
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private float usageCost;
        [SerializeField] protected float advancedAttackMultiplier;

        protected bool wasAdvancedAttack;
        protected readonly int AdvancedAttackHash = Animator.StringToHash("AdvancedAttack");
        protected float DamageToDeal => wasAdvancedAttack ? advancedAttackMultiplier * attackValue : attackValue;

        public WeaponType WeaponType => weaponType;
        public float UsageCost => wasAdvancedAttack ? usageCost * advancedAttackMultiplier : usageCost;
        public float AttackCooldown => wasAdvancedAttack ? attackCooldown * advancedAttackMultiplier : attackCooldown;
        
        public virtual void AdvancedAttack()
        {
            attackTime = Time.time + attackCooldown;
        }
    }
}
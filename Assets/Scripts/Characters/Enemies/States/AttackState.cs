using System;
using Characters.Player.Interfaces;
using UnityEngine;
using Weapons;

namespace Characters.Enemies.States
{
    public class AttackState : State
    {
        private Weapon weapon;
        private float attackRange;
        private ITargetable target;
        private Transform attackingTransform;

        public AttackState(ITargetable target, Transform attackingTransform, Weapon weapon, float attackRange)
        {
            this.target = target;
            this.weapon = weapon;
            this.attackRange = attackRange;
            this.attackingTransform = attackingTransform;
        }

        public override Type Update()
        {
            if (weapon.IsOnCooldown)
            {
                return null;
            }
            
            if (!IsInRange())
            {
                return typeof(ChaseState);
            }

            FaceTarget();
            weapon.Attack();
            return null;
        }

        private bool IsInRange()
        {
            return ((Vector2) attackingTransform.position - target.Position).magnitude <= attackRange;
        }

        private void FaceTarget()
        {
            Vector2 difference = target.Position - (Vector2) attackingTransform.position;
            Vector3 chasingTransformScale = attackingTransform.localScale;

            attackingTransform.localScale = difference.x > 0
                ? new Vector3(Mathf.Abs(chasingTransformScale.x), chasingTransformScale.y, chasingTransformScale.z)
                : new Vector3(-Mathf.Abs(chasingTransformScale.x), chasingTransformScale.y, chasingTransformScale.z);
        }
    }
}
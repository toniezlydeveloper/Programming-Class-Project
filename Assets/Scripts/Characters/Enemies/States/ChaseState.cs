using System;
using Characters.Enemies.Interfaces;
using Characters.Player.Interfaces;
using UnityEngine;

namespace Characters.Enemies.States
{
    public class ChaseState : State
    {
        private IChaser chaser;
        private Animator animator;
        private ITargetable target;
        private Transform chasingTransform;
        
        private static readonly int SpeedHash = Animator.StringToHash("Speed");

        public ChaseState(IChaser chaser, Animator animator, ITargetable target, Transform chasingTransform)
        {
            this.chaser = chaser;
            this.target = target;
            this.animator = animator;
            this.chasingTransform = chasingTransform;
        }

        public override void OnEnter()
        {
            chaser.StartChasing(target);
        }

        public override void OnExit()
        {
            chaser.StopChasing();
        }

        public override Type Update()
        {
            if (chaser.ReachedTarget)
            {
                return typeof(AttackState);
            }

            UpdateAnimator();
            FaceMovingDirection();
            return null;
        }

        private void UpdateAnimator()
        {
            animator.SetFloat(SpeedHash, Mathf.Abs(chaser.TargetDirection));
        }

        private void FaceMovingDirection()
        {
            Vector3 chasingTransformScale = chasingTransform.localScale;

            chasingTransform.localScale = chaser.TargetDirection > 0
                ? new Vector3(Mathf.Abs(chasingTransformScale.x), chasingTransformScale.y, chasingTransformScale.z)
                : new Vector3(-Mathf.Abs(chasingTransformScale.x), chasingTransformScale.y, chasingTransformScale.z);
        }
    }
}
using Characters.Enemies.States;
using Characters.Enemies.Utility;
using UnityEngine;
using Weapons;

namespace Characters.Enemies
{
    public class ChasingEnemy : Enemy
    {
        [SerializeField] private AstarChaser astarChaser;
        [SerializeField] private AttackWave weapon;
        
        protected override bool IsAlive => currentHealth > 0;

        private void Awake()
        {
            OnDeath += astarChaser.StopChasing;
        }
        
        protected override void ConstructStateMachine()
        {
            State chaseState = new ChaseState(astarChaser, animator, playableCharacter, transform);
            State attackState = new AttackState(playableCharacter, transform, weapon, attackRange);
            
            stateMachine = new StateMachine(chaseState);
            stateMachine.AddTransition(typeof(ChaseState), chaseState);
            stateMachine.AddTransition(typeof(AttackState), attackState);
        }
    }
}
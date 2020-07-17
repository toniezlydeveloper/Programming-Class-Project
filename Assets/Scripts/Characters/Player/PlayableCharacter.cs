using System;
using Characters.Player.Data;
using Characters.Player.Interfaces;
using UnityEngine;
using Weapons;

namespace Characters.Player
{
    public class PlayableCharacter : Character, ITargetable
    {
        public static event Action<float> OnAttackWentOnCooldown;
        public static event Action<AdvancedWeapon> OnWeaponSet;

        [SerializeField] private PlayerStats stats;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private AdvancedWeapon weapon;
        [SerializeField] private new Rigidbody2D rigidbody;

        private PlayerInput input = new PlayerInput();
        private readonly int SpeedHash = Animator.StringToHash("Speed");
        private readonly int AttackHash = Animator.StringToHash("Attack");
        private readonly int MoveDirectionHash = Animator.StringToHash("MoveDirection");

        protected override bool IsAlive => stats.CurrentHealth > 0f;
        public Vector2 Position => transform.position;
        public AdvancedWeapon Weapon
        {
            set
            {
                weapon.gameObject.SetActive(false);
                weapon = value;
                weapon.gameObject.SetActive(true);
                OnWeaponSet?.Invoke(weapon);
            }
        }

        private void Awake()
        {
            OnWeaponSet?.Invoke(weapon);
            stats.Construct();
        }

        private void Update()
        {
            HandleAttacking();
            stats.UpdateValues();
            TurnAccordingToMousePosition();
        }
        
        private void FixedUpdate()
        {
            HandleMovement();
            LimitVelocity();
        }

        public override void TakeDamage(float damageAmount)
        {
            if (damageAmount < 1)
            {
                return;
            }

            stats.CurrentHealth -= damageAmount;
            base.TakeDamage(damageAmount);
        }

        private void HandleAttacking()
        {
            if (weapon.IsOnCooldown)
            {
                return;
            }

            if (stats.CurrentSecondaryResource < weapon.UsageCost)
            {
                return;
            }

            if (input.AttackInput)
            {
                weapon.Attack();
                UpdateAttackValues();
            }
            else if (input.AdvancedAttackInput)
            {
                UpdateAttackValues();
                weapon.AdvancedAttack();
            }
        }

        private void UpdateAttackValues()
        {
            animator.SetTrigger(AttackHash);
            stats.CurrentSecondaryResource -= weapon.UsageCost;
            OnAttackWentOnCooldown?.Invoke(weapon.AttackCooldown);
        }

        private void HandleMovement()
        {
            Vector2 directionVector = new Vector2(input.HorizontalInput, input.VerticalInput).normalized;
            rigidbody.AddForce(stats.MoveSpeed * directionVector);
            animator.SetFloat(SpeedHash, rigidbody.velocity.sqrMagnitude);
        }

        private void LimitVelocity()
        {
            Vector2 limitedVelocity = rigidbody.velocity;
            limitedVelocity.x = stats.ClampMoveSpeed(limitedVelocity.x);
            limitedVelocity.y = stats.ClampMoveSpeed(limitedVelocity.y);
            rigidbody.velocity = limitedVelocity * 0.75f;
        }

        private void TurnAccordingToMousePosition()
        {
            if (weapon.IsDuringAttackAnimation)
            {
                return;
            }
            
            float positionScreenPointX = mainCamera.WorldToScreenPoint(transform.position).x;
            bool isMouseOnRight = positionScreenPointX < input.MouseHorizontalPosition;
            bool isLookingAtMoveDirection = (isMouseOnRight && input.HorizontalInput >= 0f) ||
                                          (!isMouseOnRight && input.HorizontalInput <= 0f);
            Vector3 currentScale = transform.localScale;
            
            transform.localScale = isMouseOnRight
                ? new Vector3(Mathf.Abs(currentScale.x), currentScale.y, currentScale.z)
                : new Vector3(-Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
            
            animator.SetFloat(MoveDirectionHash, isLookingAtMoveDirection ? 1f : -1f);
        }
    }
}
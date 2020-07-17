using System;
using System.Collections;
using Characters.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerStatsVisualization
{
    public class AttackCooldownPanel : MonoBehaviour
    {
        [SerializeField] private Image attackCooldownFill;
        [SerializeField] private TextMeshProUGUI attackCooldownTimer;
        
        private void Awake()
        {
            PlayableCharacter.OnAttackWentOnCooldown += UpdateAttackCooldownTimer;
            Toggle(false);
        }

        private void OnDestroy()
        {
            
            PlayableCharacter.OnAttackWentOnCooldown -= UpdateAttackCooldownTimer;
        }

        private void Update()
        {
            UpdatePosition();
        }

        private void UpdateAttackCooldownTimer(float attackCooldown)
        {
            Toggle(true);
            StartCoroutine(AttackCooldownCountDownCoroutine(attackCooldown));
        }

        private void UpdatePosition()
        {
            transform.position = AttackCooldownDisplayPointTracker.DisplayPoint;
        }

        private void Toggle(bool newState)
        {
            if (newState)
            {
                UpdatePosition();
            }
            else
            {
                attackCooldownTimer.text = "0";
                attackCooldownFill.fillAmount = 0f;
            }
            
            gameObject.SetActive(newState);
        }

        private IEnumerator AttackCooldownCountDownCoroutine(float attackCooldown)
        {
            float timer = attackCooldown;

            while (timer >= 0f)
            {
                attackCooldownTimer.text = timer.ToString("0.00");
                attackCooldownFill.fillAmount = timer / attackCooldown;
                timer -= Time.deltaTime;
                yield return null;
            }

            Toggle(false);
        }
    }
}
using System;
using UnityEngine;

namespace Characters.Player.Data
{
    [Serializable]
    public struct PlayerStats
    {
        public static event Action<float> OnHealthPercentageChanged;
        public static event Action<float> OnSecondResourcePercentageChanged;
        
        [SerializeField] private float moveSpeed;
        [SerializeField] private float maxMoveSpeed;
        [SerializeField] private float maxHealth;
        [SerializeField] private float maxSecondaryResource;
        [SerializeField] private float secondaryResourceRenovationFactor;

        private float currentHealth;
        private float currentSecondaryResource;
        
        public float MoveSpeed => moveSpeed;
        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
                OnHealthPercentageChanged?.Invoke(currentHealth / maxHealth);
            }
        }

        public float CurrentSecondaryResource
        {
            get => currentSecondaryResource;
            set
            {
                currentSecondaryResource = value;
                OnSecondResourcePercentageChanged?.Invoke(currentSecondaryResource / maxSecondaryResource);
            }
        }

        public void Construct()
        {
            CurrentHealth = maxHealth;
            CurrentSecondaryResource = maxSecondaryResource;
        }

        public void UpdateValues()
        {
            if (currentSecondaryResource == maxSecondaryResource)
            {
                return;
            }
            
            currentSecondaryResource += secondaryResourceRenovationFactor * Time.deltaTime;

            if (currentSecondaryResource > maxSecondaryResource)
            {
                currentSecondaryResource = maxSecondaryResource;
            }
            
            OnSecondResourcePercentageChanged?.Invoke(currentSecondaryResource / maxSecondaryResource);
        }
        
        public float ClampMoveSpeed(float speedToClamp)
        {
            return Mathf.Clamp(speedToClamp, -maxMoveSpeed, maxMoveSpeed);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Characters.Player;
using Characters.Player.Data;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace PlayerStatsVisualization
{
    public class PlayerStatsPanel : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private Slider secondResourceBar;
        [SerializeField] private Image secondResourceBarFill;
        [SerializeField] private List<SecondaryBarDisplayData> secondResourceBarColors;
        
        private void Awake()
        {
            PlayableCharacter.OnWeaponSet -= UpdateSecondResourceBarColor;
            PlayerStats.OnHealthPercentageChanged += UpdateHealthBar;
            PlayerStats.OnSecondResourcePercentageChanged += UpdateSecondResourceBar;
        }

        private void OnDestroy()
        {
            PlayableCharacter.OnWeaponSet -= UpdateSecondResourceBarColor;
            PlayerStats.OnHealthPercentageChanged -= UpdateHealthBar;
            PlayerStats.OnSecondResourcePercentageChanged -= UpdateSecondResourceBar;
        }

        private void UpdateSecondResourceBarColor(AdvancedWeapon weapon)
        {
            secondResourceBarFill.color =
                secondResourceBarColors.First(color => color.MatchingWeaponType == weapon.WeaponType).BarColor;
        }

        private void UpdateHealthBar(float healthPercentage)
        {
            healthBar.value = healthPercentage;
        }

        private void UpdateSecondResourceBar(float secondResourcePercentage)
        {
            secondResourceBar.value = secondResourcePercentage;
        }
    }
}
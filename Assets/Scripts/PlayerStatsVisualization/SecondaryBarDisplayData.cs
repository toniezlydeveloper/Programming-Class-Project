using System;
using UnityEngine;
using Weapons.Enums;

namespace PlayerStatsVisualization
{
    [Serializable]
    public struct SecondaryBarDisplayData
    {
        [SerializeField] private Color barColor;
        [SerializeField] private WeaponType matchingWeaponType;

        public Color BarColor => barColor;
        public WeaponType MatchingWeaponType => matchingWeaponType;
    }
}
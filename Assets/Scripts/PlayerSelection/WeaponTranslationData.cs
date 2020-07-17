using System;
using UnityEngine;
using Weapons;
using Weapons.Enums;

namespace PlayerSelection
{
    [Serializable]
    public struct WeaponTranslationData
    {
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private AdvancedWeapon weapon;

        public WeaponType WeaponType => weaponType;
        public AdvancedWeapon Weapon => weapon;
    }
}
using UnityEngine;
using Weapons.Enums;

namespace PlayerSelection
{
    [CreateAssetMenu(fileName = "NewPlayerConfiguration", menuName = "Player Configuration")]
    public class PlayerConfiguration : ScriptableObject
    {
        public Sprite Sprite { get; private set; }
        public WeaponType WeaponType { get; private set; }
        public RuntimeAnimatorController AnimationController { get; private set; }

        public void Construct(WeaponType weaponType, RuntimeAnimatorController animationController, Sprite sprite)
        {
            WeaponType = weaponType;
            AnimationController = animationController;
            Sprite = sprite;
        }
    }
}
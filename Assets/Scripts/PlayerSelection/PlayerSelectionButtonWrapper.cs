using System;
using UnityEngine;
using UnityEngine.UI;
using Weapons.Enums;

namespace PlayerSelection
{
    public class PlayerSelectionButtonWrapper : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private Sprite sprite;
        [SerializeField] private PlayerConfiguration playerConfiguration;
        [SerializeField] private RuntimeAnimatorController animationController;
        
        private void Awake()
        {
            button.onClick.AddListener(SetupPlayerConfiguration);
        }

        private void SetupPlayerConfiguration()
        {
            playerConfiguration.Construct(weaponType, animationController, sprite);
        }
    }
}
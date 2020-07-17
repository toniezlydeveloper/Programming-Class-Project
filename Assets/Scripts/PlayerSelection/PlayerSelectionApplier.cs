using System.Collections.Generic;
using System.Linq;
using Characters.Player;
using UnityEngine;
using Weapons.Enums;

namespace PlayerSelection
{
    public class PlayerSelectionApplier : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer playerRenderer;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private PlayableCharacter player;
        [SerializeField] private PlayerConfiguration playerConfiguration;
        [SerializeField] private List<WeaponTranslationData> weaponsTranslationData;

        private void Start()
        {
            ApplySelectionData();
        }

        private void ApplySelectionData()
        {
            if (playerConfiguration.AnimationController == null)
            {
                return;
            }
            
            playerRenderer.sprite = playerConfiguration.Sprite;
            playerAnimator.runtimeAnimatorController = playerConfiguration.AnimationController;

            WeaponTranslationData matchingTranslationData =
                weaponsTranslationData.FirstOrDefault(selectionData =>
                    selectionData.WeaponType == playerConfiguration.WeaponType);

            if (matchingTranslationData.Equals(default(WeaponTranslationData)))
            {
                return;
            }

            player.Weapon = matchingTranslationData.Weapon;
        }
    }
}
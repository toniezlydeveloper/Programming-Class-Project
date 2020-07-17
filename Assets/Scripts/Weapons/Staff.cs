using System;
using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class Staff : AdvancedWeapon
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform shootingPointTransform;
        [SerializeField] private Camera mainCamera;
        [SerializeField, HideInInspector] private bool isReachingShootingPoint;

        private void Awake()
        {
            mainCamera = mainCamera != null ? mainCamera : Camera.main;
        }
        
        public override void Attack()
        {
            base.Attack();

            wasAdvancedAttack = false;
            animator.SetTrigger(AttackHash);
            StartCoroutine(ShootProjectileWhenReachedAttackPosition(true));
        }

        public override void AdvancedAttack()
        {
            base.AdvancedAttack();
            
            wasAdvancedAttack = true;
            animator.SetTrigger(AdvancedAttackHash);
            StartCoroutine(ShootProjectileWhenReachedAttackPosition(false));
        }

        private IEnumerator ShootProjectileWhenReachedAttackPosition(bool preExploded)
        {
            Vector2 targetPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            yield return new WaitForSeconds(0.125f);
            
            while (isReachingShootingPoint)
            {
                yield return null;
            }
            
            GameObject projectileObject = Instantiate(projectilePrefab, shootingPointTransform.position, Quaternion.identity);
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            if (projectile == null)
            {
                yield break;
            }

            projectile.Construct(targetPoint, DamageToDeal, preExploded);
        }
    }
}
using Characters.Interfaces;
using UnityEngine;
using Weapons.Interfaces;

namespace Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float lifeTime;
        [SerializeField] private float flightSpeed;
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private GameObject explosion;
        [SerializeField] private GameObject flightParticles;
        
        private float damage;
        private Vector2 flightDirection;

        private void Awake()
        {
            IHitDetector hitDetector = explosion.GetComponent<IHitDetector>();

            if (hitDetector != null)
            {
                hitDetector.OnDamageableHit += DealDamage;
            }
            else
            {
                Debug.Log($"Hit detector is missing on {name}");
            }
            
            Destroy(gameObject, lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Explode();
        }

        public void Construct(Vector2 targetPoint, float damageToDeal, bool preExploded)
        {
            damage = damageToDeal;

            if (preExploded)
            {
                transform.position = targetPoint;
                Explode();
            }
            else
            {
                flightDirection = (targetPoint - (Vector2) transform.position).normalized;
            }
            
            rigidbody.velocity = flightDirection * flightSpeed;
        }

        private void Explode()
        {
            rigidbody.velocity = Vector2.zero;
            
            flightParticles.SetActive(false);
            explosion.SetActive(true);
            Destroy(gameObject, 1f);
        }
        
        private void DealDamage(IDamageable damageableToHurt)
        {
            damageableToHurt.TakeDamage(damage);
        }
    }
}
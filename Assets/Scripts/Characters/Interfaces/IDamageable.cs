using System;

namespace Characters.Interfaces
{
    public interface IDamageable
    {
        event Action OnTookDamage;
        
        void TakeDamage(float damageAmount);
    }
}
using System;
using Characters.Interfaces;

namespace Weapons.Interfaces
{
    public interface IHitDetector
    {
        event Action<IDamageable> OnDamageableHit;
    }
}
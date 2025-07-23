using Code.Gameplay.Features.Abilities;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IArmamentFactory
    {
        GameEntity CreateVegetableBolt(int level, Vector3 at);
        GameEntity CreateMushroom(int level, Vector3 at, float phase);
        GameEntity CreateScatteringProjectile(int level, Vector3 at);
        GameEntity CreateScatteringProjectileSmall(GameEntity entity);
        GameEntity CreateEffectAura(AbilityId parentAbilityId, int producer, int level);
    }
}
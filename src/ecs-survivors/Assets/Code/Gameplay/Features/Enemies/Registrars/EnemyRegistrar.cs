using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        public float HP = 3;
        public float Damage = 1;
        public float Speed = 0.5f;
        
        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddCurrentHp(HP)
                .AddMaxHp(HP)
                .AddDamage(Damage)
                .AddTargetsBuffer(new List<int>(1))
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0f)
                .AddRadius(0.3f)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }

        public override void UnregisterComponents()
        {
        }
    }
}
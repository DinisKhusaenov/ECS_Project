using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        public float Speed = 0.5f;
        
        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMoving = true)
                ;
        }

        public override void UnregisterComponents()
        {
        }
    }
}
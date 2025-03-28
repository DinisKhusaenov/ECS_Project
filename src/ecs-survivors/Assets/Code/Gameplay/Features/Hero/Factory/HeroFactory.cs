using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private const float MaxHP = 100;
        private const float Speed = 2;
        
        private readonly IIdentifierService _identifiers;

        public HeroFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity Create(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddCurrentHp(MaxHP)
                .AddMaxHp(MaxHP)
                .AddViewPath("Gameplay/Hero/hero")
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}
using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private const float HP = 3;
        private const float Damage = 1;
        private const float Speed = 0.5f;
        
        private readonly IIdentifierService _identifierService;

        public EnemyFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
        {
            switch (typeId)
            {
                case EnemyTypeId.Goblin:
                    return CreateGoblin(at);
                
                default:
                    throw new Exception($"Enemy with type id {typeId} does not exist");
            }
        }

        private GameEntity CreateGoblin(Vector3 at)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddEnemyTypeId(EnemyTypeId.Goblin)
                    .AddWorldPosition(at)
                    .AddDirection(Vector2.zero)
                    .AddSpeed(Speed)
                    .AddCurrentHp(HP)
                    .AddMaxHp(HP)
                    .AddEffectSetups(new List<EffectSetup> {new(){EffectTypeId = EffectTypeId.Damage, Value = 1}})
                    .AddTargetsBuffer(new List<int>(1))
                    .AddCollectTargetsInterval(0.5f)
                    .AddCollectTargetsTimer(0f)
                    .AddRadius(0.3f)
                    .AddLayerMask(CollisionLayer.Hero.AsMask())
                    .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue")
                    .With(x => x.isEnemy = true)
                    .With(x => x.isTurnedAlongDirection = true)
                    .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}
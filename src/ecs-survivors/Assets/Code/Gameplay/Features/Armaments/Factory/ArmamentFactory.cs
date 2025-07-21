using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentFactory : IArmamentFactory
    {
        private const int TargetsBufferSize = 16;
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public ArmamentFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateVegetableBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                .AddParentAbility(AbilityId.VegetableBolt)
                .With(x => x.isRotationAlignedAlongDirection = true);
        }
        
        public GameEntity CreateMushroom(int level, Vector3 at, float phase)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                    .AddParentAbility(AbilityId.OrbitingMushroom)
                    .AddOrbitPhase(phase)
                    .AddOrbitRadius(setup.OrbitRadius)
                ;
        }

        private GameEntity CreateProjectileEntity(Vector3 at, AbilityLevel abilityLevel, ProjectileSetup setup)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .With(x => x.isArmament = true)
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .AddWorldPosition(at)
                .AddSpeed(setup.Speed)
                .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when:!abilityLevel.StatusSetups.IsNullOrEmpty())
                .AddRadius(setup.ContactRadius)
                .AddTargetsBuffer(new List<int>(TargetsBufferSize))
                .AddProcessedTargets(new List<int>(TargetsBufferSize))
                .With(x => x.AddTargetLimit(setup.Pierce), when: setup.Pierce > 0)
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContinuously = true)
                .AddSelfDestructTimer(setup.Lifetime);
        }

        public GameEntity CreateScatteringProjectile(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ScatteringProjectile, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .With(x => x.isArmament = true)
                    .AddViewPrefab(abilityLevel.ViewPrefab)
                    .AddWorldPosition(at)
                    .AddSpeed(setup.Speed)
                    .AddEffectSetups(abilityLevel.EffectSetups)
                    .AddRadius(setup.ContactRadius)
                    .AddTargetsBuffer(new List<int>(TargetsBufferSize))
                    .AddProcessedTargets(new List<int>(TargetsBufferSize))
                    .AddTargetLimit(setup.Pierce)
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .AddScatteringCount(abilityLevel.ScatteringCount)
                    .AddScatteringSize(abilityLevel.ScatteringSize)
                    .With(x => x.isMovementAvailable = true)
                    .With(x => x.isReadyToCollectTargets = true)
                    .With(x => x.isCollectingTargetsContinuously = true)
                    .With(x => x.isRotationAlignedAlongDirection = true)
                    .AddSelfDestructTimer(setup.Lifetime)
                ;
        }

        public GameEntity CreateScatteringProjectileSmall(GameEntity entity)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .With(x => x.isArmament = true)
                    .AddViewPrefab(entity.ViewPrefab)
                    .AddWorldPosition(entity.WorldPosition)
                    .AddSpeed(entity.Speed)
                    .AddDamage(1)
                    .AddRadius(entity.Radius * entity.ScatteringSize)
                    .AddSizeAdjustable(entity.ScatteringSize)
                    .AddTargetsBuffer(new List<int>(TargetsBufferSize))
                    .AddProcessedTargets(new List<int>(TargetsBufferSize))
                    .AddTargetLimit(1)
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .With(x => x.isMovementAvailable = true)
                    .With(x => x.isReadyToCollectTargets = true)
                    .With(x => x.isCollectingTargetsContinuously = true)
                    .With(x => x.isRotationAlignedAlongDirection = true)
                    .AddSelfDestructTimer(entity.SelfDestructTimer)
                ;
        }
    }
}
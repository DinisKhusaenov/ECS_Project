using Code.Common.Destruct;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Lifetime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());
            
            Add(systems.Create<HeroFeature>());
            Add(systems.Create<EnemyFeature>());
            Add(systems.Create<DeathFeature>());
            
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<AbilityFeature>());
            Add(systems.Create<ArmamentFeature>());
            
            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<EffectApplicationFeature>());
            
            Add(systems.Create<EffectFeature>());
            Add(systems.Create<StatusFeature>());
            Add(systems.Create<StatsFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
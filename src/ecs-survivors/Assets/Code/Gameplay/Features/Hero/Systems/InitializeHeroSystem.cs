using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class InitializeHeroSystem : IInitializeSystem
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IStatusApplier _statusApplier;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public InitializeHeroSystem(
            IHeroFactory heroFactory, 
            ILevelDataProvider levelDataProvider, 
            IStatusApplier statusApplier,
            IAbilityUpgradeService abilityUpgradeService)
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _statusApplier = statusApplier;
            _abilityUpgradeService = abilityUpgradeService;
        }
        
        public void Initialize()
        {
            GameEntity hero = _heroFactory.Create(_levelDataProvider.StartPoint);
            _abilityUpgradeService.InitializeAbility(AbilityId.VegetableBolt);
            
            _statusApplier.ApplyStatus(new StatusSetup()
            {
                StatusTypeId = StatusTypeId.ExplosiveEnchant,
                Duration = 10
            }, hero.Id, hero.Id);
        }
    }
}
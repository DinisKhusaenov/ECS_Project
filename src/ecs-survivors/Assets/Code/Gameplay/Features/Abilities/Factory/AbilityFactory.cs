using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public AbilityFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateVegetableBoltAbility(int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
            
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAbilityId(AbilityId.VegetableBolt)
                .AddCooldown(abilityLevel.Cooldown)
                .With(x => x.isVegetableBoltAbility = true)
                .PutOnCooldown();
        }
        
        public GameEntity CreateOrbitingMushroomAbility(int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
            
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAbilityId(AbilityId.OrbitingMushroom)
                .AddCooldown(abilityLevel.Cooldown)
                .With(x => x.isOrbitingMushroomAbility = true)
                .PutOnCooldown();
        }
        
        public GameEntity CreateGarlicAuraAbility(int level)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAbilityId(AbilityId.GarlicAura)
                .With(x => x.isGarlicAuraAbility = true);
        }
        
        public GameEntity CreateScatteringProjectileAbility(int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ScatteringProjectile, level);
            
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAbilityId(AbilityId.ScatteringProjectile)
                .AddCooldown(abilityLevel.Cooldown)
                .With(x => x.isScatteringProjectileAbility = true)
                .PutOnCooldown();
        }
    }
}
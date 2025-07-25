namespace Code.Gameplay.Features.Abilities.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreateVegetableBoltAbility(int level);
        GameEntity CreateOrbitingMushroomAbility(int level);
        GameEntity CreateScatteringProjectileAbility(int level);
        GameEntity CreateGarlicAuraAbility(int level);
    }
}
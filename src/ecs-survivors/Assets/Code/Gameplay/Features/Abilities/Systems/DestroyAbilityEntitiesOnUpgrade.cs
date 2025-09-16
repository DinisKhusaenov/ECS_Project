using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DestroyAbilityEntitiesOnUpgradeSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _updateRequests;
        private readonly IGroup<GameEntity> _abilities;

        public DestroyAbilityEntitiesOnUpgradeSystem(GameContext game)
        {
            _game = game;
            _updateRequests = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.UpgradeRequest,
                    GameMatcher.AbilityId));
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RecreatedOnUpgrade,
                    GameMatcher.AbilityId));
        }

        public void Execute()
        {
            foreach (GameEntity request in _updateRequests)
            foreach (GameEntity ability in _abilities)
            {
                if (ability.AbilityId == request.AbilityId)
                {
                    foreach (GameEntity entity in _game.GetEntitiesWithParentAbility(ability.AbilityId))
                        entity.isDestructed = true;

                    ability.isActive = false;
                }
            }
        }
    }
}
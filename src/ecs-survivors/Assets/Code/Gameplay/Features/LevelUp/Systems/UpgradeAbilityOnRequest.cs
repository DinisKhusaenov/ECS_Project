using Code.Gameplay.Features.Abilities.Upgrade;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public class UpgradeAbilityOnRequestSystem : IExecuteSystem
    {
        private readonly IAbilityUpgradeService _upgradeService;
        private readonly IGroup<GameEntity> _upgradeRequests;
        private readonly IGroup<GameEntity> _levelUps;

        public UpgradeAbilityOnRequestSystem(GameContext game, IAbilityUpgradeService upgradeService)
        {
            _upgradeService = upgradeService;
            
            _levelUps = game.GetGroup(GameMatcher.LevelUp);
            
            _upgradeRequests = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.UpgradeRequest,
                    GameMatcher.AbilityId));
        }

        public void Execute()
        {
            foreach (GameEntity request in _upgradeRequests)
            foreach (GameEntity levelUp in _levelUps)
            {
                _upgradeService.UpgradeAbility(request.AbilityId);

                levelUp.isProcessed = true;
                request.isDestructed = true;
            }
        }
    }
}
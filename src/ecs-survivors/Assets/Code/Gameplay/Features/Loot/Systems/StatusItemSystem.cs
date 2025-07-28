using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class StatusItemSystem : IExecuteSystem
    {
        private readonly IStatusApplier _statusApplier;
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;

        public StatusItemSystem(GameContext game, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _collected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Collected,
                    GameMatcher.StatusSetups));
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity collected in _collected)
            foreach (StatusSetup status in collected.StatusSetups)
            {
                _statusApplier.ApplyStatus(status, hero.Id, hero.Id);
            }
        }
    }
}
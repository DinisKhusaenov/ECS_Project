using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class SetHeroDirectionByInput : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _inputs;

        public SetHeroDirectionByInput(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.MovementAvailable));
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var hero in _heroes)
            {
                hero.isMoving = input.hasAxisInput;

                if (input.hasAxisInput)
                    hero.ReplaceDirection(input.AxisInput.normalized);
            }
        }
    }
}
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.System
{
    public class MoveByDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly IGroup<GameEntity> _targets;

        public MoveByDirectionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher.Enemy);
            _targets = game.GetGroup(GameMatcher.Target);
        }
        
        public void Execute()
        {
            foreach (var hero in _targets)
            foreach (var mover in _movers)
            {
                mover.ReplaceDirection(((Vector2)hero.WorldPosition - (Vector2)mover.WorldPosition).normalized);
            }
        }
    }
}
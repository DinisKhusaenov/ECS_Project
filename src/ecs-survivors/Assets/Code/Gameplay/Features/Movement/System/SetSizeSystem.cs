using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Movement.System
{
    public class SetSizeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _sizes;
        private readonly List<GameEntity> _buffer = new(32);

        public SetSizeSystem(GameContext game)
        {
            _sizes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.SizeAdjustable));
        }
        
        public void Execute()
        {
            foreach (var size in _sizes.GetEntities(_buffer))
            {
                size.Transform.localScale *= size.SizeAdjustable;
                size.RemoveSizeAdjustable();
            }
        }
    }
}
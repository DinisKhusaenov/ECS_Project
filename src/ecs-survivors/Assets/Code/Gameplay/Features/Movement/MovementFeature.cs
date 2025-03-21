using Code.Gameplay.Features.Movement.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<DirectionalDeltaMoveSystem>());
            Add(systems.Create<UpdateTransformPositionSystem>());
            Add(systems.Create<TurnAlongDirectionSystem>());
            Add(systems.Create<MoveByDirectionSystem>());
        }
    }
}
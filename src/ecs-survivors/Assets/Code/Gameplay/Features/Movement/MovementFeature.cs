using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Movement.System;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(GameContext gameContext, ITimeService timeService)
        {
            Add(new DirectionalDeltaMoveSystem(gameContext, timeService));
        }
    }
}
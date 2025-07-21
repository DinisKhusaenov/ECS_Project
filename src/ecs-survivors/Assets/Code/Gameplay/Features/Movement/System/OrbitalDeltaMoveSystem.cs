using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.System
{
    public class OrbitalDeltaMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;

        public OrbitalDeltaMoveSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.OrbitPhase,
                    GameMatcher.OrbitCenterPosition,
                    GameMatcher.OrbitRadius,
                    GameMatcher.WorldPosition,
                    GameMatcher.Speed,
                    GameMatcher.MovementAvailable,
                    GameMatcher.Moving));
        }
        
        public void Execute()
        {
            foreach (var mover in _movers)
            {
                var phase = mover.OrbitPhase + _time.DeltaTime * mover.Speed;
                mover.ReplaceOrbitPhase(phase);

                Vector3 newRelativePosition = new Vector3(
                    Mathf.Cos(phase) * mover.OrbitRadius,
                    Mathf.Sin(phase) * mover.OrbitRadius,
                    0
                );

                Vector3 newPosition = newRelativePosition + mover.OrbitCenterPosition;
                mover.ReplaceWorldPosition(newPosition);
            }
        }
    }
}
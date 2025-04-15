using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class LaunchingProjectilesInDifferentDirectionsSystem : IExecuteSystem
    {
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _armaments;
        private List<GameEntity> _buffer = new (16);

        public LaunchingProjectilesInDifferentDirectionsSystem(GameContext game, IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;
            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.ScatteringCount,
                    GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments.GetEntities(_buffer))
            {
                for (int i = 0; i < armament.ScatteringCount; i++)
                {
                    _armamentFactory.CreateScatteringProjectileSmall(armament)
                        .AddDirection(GetDirectionByCircle(i, armament.ScatteringCount).normalized)
                        .With(x => x.isMoving = true);
                }
            }
        }

        private Vector2 GetDirectionByCircle(int id, int count)
        {
            float angle = (360f / count) * id;
            float radians = angle * Mathf.Deg2Rad;

            return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
        }
    }
}
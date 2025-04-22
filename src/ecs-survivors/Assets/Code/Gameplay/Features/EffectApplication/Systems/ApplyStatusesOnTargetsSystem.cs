using Code.Common.Extensions;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
    public class ApplyStatusesOnTargetsSystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _entities;

        public ApplyStatusesOnTargetsSystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.StatusSetups));
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetId in entity.TargetsBuffer)
            foreach (StatusSetup effectSetup in entity.StatusSetups)
            {
                _statusFactory.CreateStatus(effectSetup, ProducerId(entity), targetId)
                    .With(x => x.isApplied = true);
            }
        }

        private int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public class AfkGoldGameSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _ticks;
        private readonly IGroup<MetaEntity> _storage;

        public AfkGoldGameSystem(MetaContext meta)
        {
            _ticks = meta.GetGroup(MetaMatcher.Tick);
            _storage = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Storage,
                MetaMatcher.Gold,
                MetaMatcher.GoldPerSecond));
        }

        public void Execute()
        {
            foreach (MetaEntity tick in _ticks)
            foreach (MetaEntity storage in _storage)
            {
                storage.ReplaceGold(storage.Gold + tick.Tick * storage.GoldPerSecond);
            }
        }
    }
}
using Code.Gameplay.Common.Visuals.Enchants;

namespace Code.Infrastructure.View.Registrars
{
    public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents();
        public abstract void UnregisterComponents();
    }
}
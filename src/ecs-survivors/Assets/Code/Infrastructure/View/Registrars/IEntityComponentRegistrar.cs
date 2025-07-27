using Code.Gameplay.Common.Visuals.Enchants;

namespace Code.Infrastructure.View.Registrars
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponents();
        void UnregisterComponents();
    }
}
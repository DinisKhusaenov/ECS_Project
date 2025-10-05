using Code.Infrastructure.Systems;
using Code.Meta.UI.GoldHolder.Systems;
using Code.Meta.UI.Shop;

namespace Code.Meta
{
  public sealed class HomeUIFeature : Feature
  {
    public HomeUIFeature(ISystemFactory systems)
    {
      Add(systems.Create<ShopFeature>());
      Add(systems.Create<RefreshGoldSystem>());
    }
  }
}
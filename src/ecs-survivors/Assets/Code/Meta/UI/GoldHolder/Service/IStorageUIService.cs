using System;

namespace Code.Meta.UI.GoldHolder.Service
{
  public interface IStorageUIService
  {
    event Action GoldChanged;
    event Action GoldBoostChanged;
    float CurrentGold { get; }
    float GoldGainBoost { get; }
    void UpdateCurrentGold(float gold);
    void Cleanup();
    void UpdateGoldGainBoost(float boost);
  }
}
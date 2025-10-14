using System;

namespace Code.Meta.UI.GoldHolder.Service
{
  public class StorageUIService : IStorageUIService
  {
    public event Action GoldBoostChanged;
    public event Action GoldChanged;
    
    public float CurrentGold { get; private set; }
    public float GoldGainBoost { get; private set; }
    
    public void UpdateCurrentGold(float gold)
    {
      if (MathF.Abs(gold - CurrentGold) > float.Epsilon)
      {
        CurrentGold = gold;
        GoldChanged?.Invoke();
      }
    }

    public void Cleanup()
    {
      CurrentGold = 0;
      GoldGainBoost = 0;
      
      GoldChanged = null;
      GoldBoostChanged = null;
    }

    public void UpdateGoldGainBoost(float boost)
    {
      GoldGainBoost = boost;
      GoldBoostChanged?.Invoke();
    }
  }
}
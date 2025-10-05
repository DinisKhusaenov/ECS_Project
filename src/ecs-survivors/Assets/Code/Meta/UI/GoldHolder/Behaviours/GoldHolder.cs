using System;
using Code.Meta.UI.GoldHolder.Service;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.GoldHolder.Behaviours
{
  public class GoldHolder : MonoBehaviour
  {
    public TextMeshProUGUI Amount;
    public TextMeshProUGUI Boost;
    
    private IStorageUIService _storage;

    [Inject]
    private void Construct(IStorageUIService storageUIService) => 
      _storage = storageUIService;

    private void Start()
    {
      _storage.GoldChanged += UpdateGold;
      
      UpdateGold();
    }

    private void OnDestroy()
    {
      _storage.GoldChanged -= UpdateGold;
    }

    private void UpdateGold()
    {
      Amount.text = _storage.CurrentGold.ToString("0");
    }
  }
}
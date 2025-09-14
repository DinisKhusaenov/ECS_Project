using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class Enchant : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        
        public EnchantTypeId Id;

        public void Set(EnchantConfig config)
        {
            Id = config.TypeId;
            _icon.sprite = config.Icon;
        }
    }
}
using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using UnityEngine;
using EntityBehaviour = Code.Infrastructure.View.EntityBehaviour;

namespace Code.Gameplay.Features.Loot.Configs
{
    [CreateAssetMenu(menuName = "Configs/LootConfig", fileName = "LootConfig")]
    public class LootConfig : ScriptableObject
    {
        public LootTypeId LootTypeId;
        public float Experience;
        public EntityBehaviour ViewPrefab;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}
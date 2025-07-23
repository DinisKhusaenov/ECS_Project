using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    public class AbilityLevel
    {
        public float Cooldown;

        public int ScatteringCount;
        
        public float ScatteringSize;

        public EntityBehaviour ViewPrefab;

        public ProjectileSetup ProjectileSetup;
        public AuraSetup AuraSetup;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp
{
    [CreateAssetMenu(menuName = "Configs/LevelUpConfig", fileName = "LevelUpConfig")]
    public class LevelUpConfig : ScriptableObject
    {
        public int MaxLevel;
        public List<float> ExperienceForLevel;
    }
}
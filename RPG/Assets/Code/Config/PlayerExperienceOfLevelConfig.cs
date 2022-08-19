using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu(menuName = "Configs/PlayerExperienceCfg")]
    public class PlayerExperienceOfLevelConfig:ScriptableObject
    {
        public int[] Experience;
    }
}
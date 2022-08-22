using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu(menuName = "Configs/SoundsCfg")]
    public class SoundsConfig:ScriptableObject
    {
        public AudioClip PlayerStep;
        public AudioClip PlayerAttack;
        public AudioClip EnemyAttack;
    }
}
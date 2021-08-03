using Code.Model;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName ="BulletConfig", menuName = "Assets/Config")]
    public class BulletConfig:ScriptableObject
    {
        public GameObject BulletPrefab;
        [SerializeField] internal FireBall Bullet;
        public int PoolCount;
        
    }
}
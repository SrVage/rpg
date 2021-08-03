using Code.Interface;
using DefaultNamespace;
using UnityEngine;

namespace Code.Model
{
    internal abstract class Bullet:MonoBehaviour
    {
        public static IBulletFactory BulletFactory;
        private Transform _rootPool;
        private float _damage;


        public Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(NameManger.BULLET_POOL);
                    _rootPool = find == null ? null : find.transform;
                }
                return _rootPool;
            }
        }

        public static FireBall CreateBulletFireBall(BulletConfig bulletConfig)
        {
            var bullet = Instantiate(bulletConfig.Bullet);
            return bullet;
        }

        public void CreateBullet(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.parent = null;
        }

        public void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(_rootPool);
            if (_rootPool == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
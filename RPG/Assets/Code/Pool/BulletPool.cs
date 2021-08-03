using System.Collections.Generic;
using Code.Model;
using UnityEngine;

namespace DefaultNamespace
{
    public sealed class BulletPool
    {
        private readonly Queue<Bullet> _bulletPool;
        private int _poolCount;
        private Transform _rootPool;
        private GameObject _bulletPrefab;
        private BulletConfig _bulletConfig;

        public BulletPool(BulletConfig bulletConfig)
        {
            _bulletConfig = bulletConfig;
            _bulletPrefab = bulletConfig.BulletPrefab;
            _poolCount = bulletConfig.PoolCount;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManger.BULLET_POOL).transform;
            }
        }

        private Bullet GetFireball()
        {
            var fireball = _bulletPool.Dequeue();
            if (fireball == null)
            {
                for (int i = 0; i < _poolCount; i++)
                {
                    var bullet = Object.Instantiate(_bulletConfig.Bullet);
                    bullet.ReturnToPool();
                    _bulletPool.Enqueue(bullet);
                }

                GetFireball();
            }
            return fireball;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }
    }
}
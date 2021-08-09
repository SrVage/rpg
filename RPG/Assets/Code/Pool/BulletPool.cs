using System.Collections.Generic;
using System.Linq;
using Code.Extensions;
using Code.Interface;
using Code.Model;
using Code.ServiceLocator;
using UnityEngine;

namespace Code.Pool
{
    public class BulletPool:IService
    {
        private readonly Queue<GameObject> _bulletPool;
        private int _poolCount;
        private Transform _rootPool;
        private GameObject _bulletPrefab;

        public BulletPool(int poolCount)
        {
            _poolCount = poolCount;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManger.BULLET_POOL).transform;
                _bulletPool = new Queue<GameObject>();
            }
        }

        public GameObject GetFireball()
        {
            var fireball = _bulletPool.LastOrDefault(a => !a.gameObject.activeSelf);
            
            if (fireball==null)
            {
                for (int i = 0; i < _poolCount; i++)
                {
                    var bullet = GameObject.Instantiate(Resources.Load("fireBall") as GameObject, Vector3.zero, Quaternion.identity);
                    bullet.AddTrail(Color.red).AddTrigger();
                    bullet.GetComponent<Bullet>().ReturnToPool();
                    
                    _bulletPool.Enqueue(bullet);
                }
                GetFireball();
            }

            fireball = _bulletPool.Dequeue();
            fireball.SetActive(true);
            fireball.transform.parent = null;
            fireball.GetComponent<Bullet>().Create();
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
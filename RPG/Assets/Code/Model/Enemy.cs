using System;
using System.Runtime.CompilerServices;
using Code.Extensions;
using Code.Interface;
using UnityEngine;

//Bridge Pattern
namespace Code.Model
{
    [Serializable]
    public abstract class Enemy:MonoBehaviour, IAttack, IDamage
    {
        private float _health;
        private float _forceOfAttack;
        [SerializeField] private GameObject _gameObject;

        public static SkeletonWarrior CreateSkeleton(float heatlh, float forceOfAttack, Vector3 position)
        {
            var skeleton = Instantiate(Resources.Load<SkeletonWarrior>("Skeleton"));
            skeleton.transform.position = position;
            skeleton._health = heatlh;
            skeleton._forceOfAttack = forceOfAttack;
            return skeleton;
        }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void GetDamage(float damage)
        {
            _health -= damage;
            if (_health<=0) Death();
        }

        private void Death()
        {
            gameObject.SetActive(false);
        }
    }
}
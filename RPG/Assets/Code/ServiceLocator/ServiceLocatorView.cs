using Code.Controller;
using Code.Pool;
using UnityEngine;

namespace Code.ServiceLocator
{
    public class ServiceLocatorView:MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.SetService<IService>(new BulletPool(20));
        }

        private void Start()
        {
            ServiceLocator.Resolve<IService>();
        }
    }
}
using UnityEngine;
using Zenject;

namespace Code.MonoBehaviours
{
    public class StartGame:MonoBehaviour
    {
        [Inject] private DiContainer _container;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _container.ResolveId<IInitializable>("Startup").Initialize();
            }
        }
    }
}
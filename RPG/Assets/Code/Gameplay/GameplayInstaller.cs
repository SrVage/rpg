using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
    internal class GameplayInstaller : MonoInstaller
    {
        //[SerializeField] private GameObject _startup;
        [SerializeField] private EcsStartup _startup;
        public override void InstallBindings()
        {
            //Debug.Log("start");
            Application.targetFrameRate = 60;
            //Container.Bind<EcsStartup>().FromInstance(_startup).AsSingle().NonLazy();
            //Container.InstantiatePrefab(_startup);
            var startup = Container.InstantiatePrefabForComponent<IInitializable>(_startup);
            Container.Bind<IInitializable>().WithId("Startup").FromInstance(startup).NonLazy();
        }
    }
}
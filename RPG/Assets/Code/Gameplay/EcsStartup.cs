using Code.Abstract.Interfaces;
using Code.Components.Create;
using Code.Components.Input;
using Code.Components.Navigation;
using Code.Gameplay.Initialize;
using Code.Gameplay.Move;
using Code.Gameplay.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Code.Gameplay {
    sealed class EcsStartup : MonoBehaviour, IInitializable
    {
        [Inject] private ILoadLevelService _loadLevelService;
        [Inject] private EcsWorld _world;
        
        EcsSystems _systems;

        public void Initialize () {
            // void can be switched to IEnumerator for support coroutines.
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new LoadLevelSystem())
                .Add(new BindCameraSystem())
                .Add (new InputSystem())
                .Add (new ClickPointHandlerSystem(Camera.main))
                .Add(new RaycastHandlerSystem())
                .Add(new SetTargetSystem())
                
                .OneFrame<ClickPoint> ()
                .OneFrame<RaycastHits> ()
                .OneFrame<LoadLevelDone>()
                .OneFrame<TargetPoint>()

                .Inject (_loadLevelService)
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}
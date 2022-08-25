using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Animations;
using Code.Components.Audio;
using Code.Components.Common;
using Code.Components.Create;
using Code.Components.Enemy;
using Code.Components.Input;
using Code.Components.Navigation;
using Code.Config;
using Code.Gameplay.Battle;
using Code.Gameplay.Character;
using Code.Gameplay.Enemy;
using Code.Gameplay.Experience;
using Code.Gameplay.Initialize;
using Code.Gameplay.Move;
using Code.Gameplay.Network;
using Code.Gameplay.Systems;
using Code.Gameplay.UI;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;
using AnimationEvent = Code.Components.Animations.AnimationEvent;

namespace Code.Gameplay {
    sealed class EcsStartup : MonoBehaviour, IInitializable
    {
        [Inject] private ILoadLevelService _loadLevelService;
        [Inject] private IEnemySpawnService _enemySpawnService;
        [Inject] private IGameplayUIService _gameplayUIService;
        [Inject] private IChangePlayerLevel _changePlayerLevel;
        [Inject] private SoundsConfig _soundsConfig;
        [Inject] private EcsWorld _world;
        
        EcsSystems _systems;

        public void Initialize () {
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
                .Add(new SetEnemyTargetSystem())
                .Add(new PlayerAttackSystem<PlayerTag, EnemyTag>())
                .Add(new PlayerAttackSystem<EnemyTag, PlayerTag>())
                .Add(new PlayerAttackSystem<OtherPlayerTag, PlayerTag>())
                .Add(new PlayerAttackSystem<PlayerTag, OtherPlayerTag>())
                .Add(new NetworkAttackSystem())
                .Add(new DamageSystem())
                .Add(new DelTargetSystem())
                .Add(new CheckEndMoveSystem())
                .Add(new EnemySpawnTimerSystem())
                .Add(new EnemySpawnSystem())
                .Add(new EnemyDeathSystem())
                .Add(new PlayerAnimationSystem())
                .Add(new UIHealthSystem())
                .Add(new PlayerUIHealthSystem())
                .Add(new ChangeExperienceSystem())
                .Add(new PlayAudioSystem())
                .Add(new DeathSystem())
                //.Add(new DeleteAttackTargetSystem())
                
                .OneFrame<ClickPoint> ()
                .OneFrame<RaycastHits> ()
                .OneFrame<LoadLevelDone>()
                .OneFrame<TargetPoint>()
                .OneFrame<SpawnSignal>()
                //.OneFrame<AttackTarget>()
                .OneFrame<StartMove>()
                .OneFrame<EndMove>()
                .OneFrame<Punch>()
                .OneFrame<AnimationEvent>()
                .OneFrame<Strike>()
                .OneFrame<AddExperience>()
                .OneFrame<StepAudio>()
                .OneFrame<AttackAudio>()

                .Inject (_loadLevelService)
                .Inject (_enemySpawnService)
                .Inject (_gameplayUIService)
                .Inject (_changePlayerLevel)
                .Inject (_soundsConfig)
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
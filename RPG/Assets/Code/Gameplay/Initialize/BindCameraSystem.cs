using Cinemachine;
using Code.Abstract;
using Code.Components;
using Code.Components.Create;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Initialize
{
    internal sealed class BindCameraSystem:IEcsRunSystem
    {
        private readonly EcsFilter<LoadLevelDone> _signal = null;
        private readonly EcsFilter<GameObjectRef, PlayerTag> _player = null;
        private readonly EcsFilter<VirtualCamera> _camera= null;
        
        public void Run()
        {
            if (_signal.IsEmpty())
                return;
            foreach (var pdx in _player)
            {
                ref var playerTransform = ref _player.Get1(pdx).Transform;
                foreach (var cdx in _camera)
                {
                    ref var camera = ref _camera.Get1(cdx).Value;
                    var cameras = Object.FindObjectsOfType<CinemachineVirtualCamera>();
                    foreach (var cam in cameras)
                    {
                        if (cam == camera)
                            continue;
                        cam.enabled = false;
                    }
                    camera.m_Follow = playerTransform;
                    camera.m_LookAt = playerTransform;
                    camera.DestroyCinemachineComponent<CinemachineTransposer>();
                    var transposer = camera.AddCinemachineComponent<CinemachineTransposer>();
                    transposer.m_BindingMode = CinemachineTransposer.BindingMode.LockToTarget;
                    transposer.m_FollowOffset.Set(0,20,-30);
                    transposer.m_YawDamping = 15;
                    camera.enabled = true;
                }
            }
        }
    }
}
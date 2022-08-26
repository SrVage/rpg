using Cinemachine;
using Code.Components;
using Leopotam.Ecs;

namespace Code.Gameplay.CameraSystems
{
    internal sealed class LockCameraRotateSystem:IEcsRunSystem
    {
        private readonly EcsFilter<CameraRotate> _signal = null;
        private readonly EcsFilter<VirtualCamera> _camera= null;

        public void Run()
        {
            if (_signal.IsEmpty())
                return;
            foreach (var cdx in _camera)
            {
                ref var camera = ref _camera.Get1(cdx).Value;
                var transposer = camera.GetCinemachineComponent<CinemachineTransposer>();
                if (transposer.m_BindingMode == CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp)
                    transposer.m_BindingMode = CinemachineTransposer.BindingMode.LockToTarget;
                else
                    transposer.m_BindingMode = CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp;
                transposer.m_FollowOffset.Set(0,20,-30);
                transposer.m_YawDamping = 15;
            }
        }
    }
}
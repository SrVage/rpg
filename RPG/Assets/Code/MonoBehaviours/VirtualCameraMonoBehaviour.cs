using Cinemachine;
using Code.Abstract;
using Code.Components;
using Leopotam.Ecs;

namespace Code.MonoBehaviours
{
    public class VirtualCameraMonoBehaviour:MonoBehaviourToEntity
    {
        public CinemachineVirtualCamera _vrtualCamera;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<VirtualCamera>().Value = _vrtualCamera;
        }
    }
}
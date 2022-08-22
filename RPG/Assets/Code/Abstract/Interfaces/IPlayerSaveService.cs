using Leopotam.Ecs;

namespace Code.Abstract.Interfaces
{
    public interface IPlayerSaveService
    {
        void Save();
        void SetPlayer(EcsEntity entity);
    }
}
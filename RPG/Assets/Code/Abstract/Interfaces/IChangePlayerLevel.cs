using Leopotam.Ecs;

namespace Code.Abstract.Interfaces
{
    public interface IChangePlayerLevel
    {
        void ChangeExperience(int change);
        void SetPlayer(EcsEntity entity);
    }
}
using Leopotam.Ecs;

namespace Code.Abstract.Interfaces
{
    public interface IGameplayUIService
    {
        void ChangeHealth(float percent);
        void ChangeExperience(float experience);
        void ChangeLevel(int level);
    }
}
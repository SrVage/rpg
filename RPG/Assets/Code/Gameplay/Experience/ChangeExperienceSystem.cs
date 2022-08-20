using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Common;
using Leopotam.Ecs;

namespace Code.Gameplay.Experience
{
    internal sealed class ChangeExperienceSystem:IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, AddExperience> _player = null;
        private readonly IChangePlayerLevel _changePlayerLevel = null;

        public void Run()
        {
            foreach (var pdx in _player)
            {
                var experience = _player.Get2(pdx).Value;
                _changePlayerLevel.ChangeExperience(experience);
            }
        }
    }
}
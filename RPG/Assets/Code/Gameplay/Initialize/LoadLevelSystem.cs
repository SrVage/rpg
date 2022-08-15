using Code.Abstract.Interfaces;
using Leopotam.Ecs;

namespace Code.Gameplay.Initialize
{
    internal sealed class LoadLevelSystem:IEcsInitSystem
    {
        private readonly ILoadLevelService _loadLevelService;
        
        public void Init()
        {
            _loadLevelService.LoadMainLevel();
        }
    }
}
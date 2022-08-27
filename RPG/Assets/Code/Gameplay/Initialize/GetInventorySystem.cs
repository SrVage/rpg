using Code.Abstract.Interfaces;
using Code.Components.Create;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Initialize
{
    internal sealed class GetInventorySystem:IEcsRunSystem
    {
        private readonly EcsFilter<LoadLevelDone> _signal = null;
        private readonly IGetThingsFromChest _getThingsFromChest = null;
        
        public void Run()
        {
            if (_signal.IsEmpty())
                return;
            Debug.Log("Get");
            _getThingsFromChest.GetInventory();
        }
    }
}
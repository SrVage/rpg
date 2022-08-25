using Code.Components.Input;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Systems
{
    internal sealed class InputSystem:IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        public void Run()
        {
            if (Input.GetMouseButtonDown(0)) 
                _world.NewEntity().Get<ClickPoint>().Value = Input.mousePosition;
        }
    }
}
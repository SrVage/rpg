using Code.Components.Input;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input
{
    internal sealed class InputSystem:IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EventSystem _eventSystem = null;

        public InputSystem()
        {
            _eventSystem = Object.FindObjectOfType<EventSystem>();
        }
        public void Run()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                if (!_eventSystem.IsPointerOverGameObject())
                    _world.NewEntity().Get<ClickPoint>().Value = UnityEngine.Input.mousePosition;
            }
        }
    }
}
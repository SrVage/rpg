using Code.Components.Common;
using Code.Components.UI;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.UI
{
    internal sealed class UIHealthSystem:IEcsRunSystem
    {
        private readonly EcsFilter<HealthUI, Health> _health = null;
        private readonly Camera _camera;

        public UIHealthSystem() => 
            _camera = Camera.main;

        public void Run()
        {
            foreach (var hdx in _health)
            {
                ref var image = ref _health.Get1(hdx).Value;
                var health = _health.Get2(hdx).Percent;
                ref var healthTransform = ref _health.Get1(hdx).Transform;
                image.fillAmount = health;
                healthTransform.LookAt(_camera.transform);
            }
        }
    }
}
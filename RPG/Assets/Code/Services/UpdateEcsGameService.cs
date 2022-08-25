using System.Threading.Tasks;
using Code.Abstract;
using Code.Abstract.Interfaces;
using Leopotam.Ecs;
using Photon.Pun;
using UnityEngine;

namespace Code.Services
{
    internal sealed class UpdateEcsGameService:IUpdateEcsGameService
    {
        private readonly EcsWorld _world = null;

        public UpdateEcsGameService(EcsWorld world)
        {
            _world = world;
        }

        public async void Update()
        {
            Debug.Log(this);
            await Task.Delay(2000);
            var gameObjects = Object.FindObjectsOfType<MonoBehaviourToEntity>();
            foreach (var gameObject in gameObjects)
            {
                gameObject.Initial(_world.NewEntity(), _world);
            }
        }
    }
}
using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Common;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace Code.Gameplay.Character
{
    internal sealed class DeathSystem:IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GameObjectRef, Death> _player = null;
        private readonly EcsFilter<OtherPlayerTag, GameObjectRef, Death> _otherPlayer = null;
        private readonly IUpdateEcsGameService _updateEcsGameService = null;
        private readonly IChoosePlayerService _choosePlayerService = null;
        private readonly IPlayerSaveService _playfabSaveService = null;
        
        public void Run()
        {
            foreach (var odx in _otherPlayer)
            {
                //ref var gameObject = ref _otherPlayer.Get2(odx).GameObject;
                _choosePlayerService.GetPlayer.BattlesWin += 1;
                _playfabSaveService.Save();
                //_updateEcsGameService.Destroy(gameObject);
                _otherPlayer.GetEntity(odx).Destroy();
            }

            foreach (var pdx in _player)
            {
                ref var gameObject = ref _player.Get2(pdx).GameObject;
                _updateEcsGameService.Destroy(gameObject);
                SceneManager.LoadScene(2);
            }
        }
    }
}
using Code.Abstract.Interfaces;
using Code.Components.Common;
using Code.Components.Player;
using Leopotam.Ecs;

namespace Code.Services
{
    internal sealed class PlayerSaveService:IPlayerSaveService
    {
        private readonly IChoosePlayerService _choosePlayerService = null;
        private readonly IPlayfabCharacterService _playfabCharacterService = null;
        private EcsEntity _player;

        public PlayerSaveService(IChoosePlayerService choosePlayerService, IPlayfabCharacterService playfabCharacterService)
        {
            _choosePlayerService = choosePlayerService;
            _playfabCharacterService = playfabCharacterService;
        }
        
        public void SetPlayer(EcsEntity entity) => 
            _player = entity;

        public void Save()
        {
            var player = _choosePlayerService.GetPlayer;
            player.Damage = _player.Get<Damage>().Value;
            player.Health = _player.Get<Health>().Maximum;
            player.Level = _player.Get<Experience>().Level;
            player.XP = _player.Get<Experience>().Value;
            _choosePlayerService.SetPlayer(player);
            _playfabCharacterService.UpdateCharacterStatistics();
        }
    }
}
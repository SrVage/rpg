using Code.Abstract;
using Code.Abstract.Interfaces;

namespace Code.Services
{
    internal sealed class ChoosePlayerService:IChoosePlayerService
    {
        private PlayerClass _playerClass;

        public void SetPlayer(PlayerClass playerClass) => 
            _playerClass = playerClass;

        public PlayerClass GetPlayer =>
            _playerClass;
    }
}
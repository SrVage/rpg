using Code.Abstract.Interfaces;
using Code.UI.Presenter;
using Zenject;

namespace Code.Services
{
    internal sealed class GameplayUIService:IGameplayUIService
    {
        private readonly GameplayUIPresenter _gameplayUIPresenter = null;

        [Inject]
        public GameplayUIService(GameplayUIPresenter gameplayUIPresenter) => 
            _gameplayUIPresenter = gameplayUIPresenter;

        public void ChangeHealth(float percent)
        {
            _gameplayUIPresenter.ChangeHealth(percent);
        }
    }
}